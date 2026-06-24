using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using EasyModbus;
using Modbus.Device;
using 投简历.models;

namespace 投简历
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;

        SerialPort sp = new SerialPort();

        ModbusReader modbus = new ModbusReader();

        DataTable table = new DataTable();

        Sqlsever sqlsever = new Sqlsever();

        CancellationTokenSource cts;

        private List<double> temps = new List<double>();

        private readonly object lockobj = new object();
        public Form1()
        {
            InitializeComponent();

            Init();
            Initial();

            btnStop.Enabled = false;
        } 
        private void Init()
        {
            table.Columns.Add("温度");
            table.Columns.Add("状态");
            table.Columns.Add("时间");

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnLJCK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我点了按钮");
            try
            {
                if (sp.IsOpen)
                {
                    MessageBox.Show("串口已经打开"); return;
                }

                sp.PortName = "COM6";
                sp.BaudRate = 9600;
                sp.DataBits = 8;
                sp.StopBits = StopBits.One;
                sp.Parity = Parity.None;

                sp.DataReceived -= Sp_data;
                sp.DataReceived += Sp_data;

                sp.Open();

                MessageBox.Show("COM6已经打开");
            }
            catch(Exception ex)
            {
                MessageBox.Show("COM6打开失败" + ex.Message);
            }
        }
        private void Sp_data(object sender,SerialDataReceivedEventArgs e)
        {
            while (sp.BytesToRead > 0)
            {
                try
                {
                    string text = sp.ReadLine();

                    if (text.Contains("TEMP:"))
                    {
                        string tempStr = text.Replace("TEMP:", "").Trim();

                        if (double.TryParse(tempStr, out double temperature))
                        {
                            lock (lockobj)
                            {
                                temps.Add(temperature);
                            }
                        }
                    }

                }
                catch
                {
                    break;
                }
            }
                     
        }
        private void btnJSSJ_Click(object sender, EventArgs e)
        {
            if (!sp.IsOpen)
            {
                MessageBox.Show("请先打开COM6");return;
            }
            sp.WriteLine("hello");
        }
        private void Initial()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender,EventArgs e)
        {
            List<double> copy;

            lock (lockobj)
            {
                if (temps.Count == 0) return;

                copy = new List<double>(temps);

                temps.Clear();
            }

            foreach (double d in copy)
            {
                string status = d > 50 ? "温度高得一批" : "温度正常";
                this.Invoke(new Action(() =>
                {
                    lblTemp.Text = "当前温度" + d + "℃";
                    lblTemp.Text = status;
                    lblststus.ForeColor = d > 50 ? Color.Green : Color.Red;
                    table.Rows.Add(d, status, DateTime.Now);
                }));

                sqlsever.Sqladd(d, status, DateTime.Now);

                while (table.Rows.Count > 200)
                {
                    table.Rows.RemoveAt(0);
                }
            }
            
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                MessageBox.Show("已经在采集中");return;
            }

            cts = new CancellationTokenSource();
            
            btnGo.Enabled = false;
            btnStop.Enabled = true;

            Task.Run(() => Cancellect(cts.Token));
        }
        private async Task Cancellect(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                List<double> temps;
                try
                {
                    temps = modbus.ReadTemperature();
                }
                catch(Exception ex)
                {
                    lblststus.Text = "连接失败" + ex.Message;
                    lblststus.ForeColor = Color.Red;

                    break;
                }
                foreach (double temp in temps)
                {
                    string status;
                        Color color;
                    if (temp > 50)
                {
                       
                    status = "警告 温度很高";
                    color = Color.Red;
                }
                else
                {
                    status = "温度正常";
                    color = Color.Green;
                }
                    this.Invoke(new Action(() =>
                         {
                             lblTemp.Text = "当前温度" + temp + "℃";
                             lblststus.Text = status;
                             lblststus.ForeColor = color;

                             table.Rows.Add(temp, status, DateTime.Now);
                         }));
                    try
                    {
                        sqlsever.Sqladd(temp, status, DateTime.Now);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("数据库连接失败" + ex.Message);
                        //MessageBox.Show("保存失败" + ex.Message + "\n\n" + ex.StackTrace);

                        lblststus.Text = "数据库保存失败" + ex.Message;
                        lblststus.ForeColor = Color.Red;

                    }
                }
                try
                {
                    await Task.Delay(1000,token);
                }
                catch
                {
                    break;
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cts == null) return;

            cts.Cancel();
            cts = null;

            btnGo.Enabled = true;
            btnStop.Enabled = false;

            lblTemp.Text = "停止采集";
            lblststus.ForeColor = Color.Red;
        }
    }
}
