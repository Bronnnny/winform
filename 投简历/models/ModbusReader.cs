using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 投简历.models
{
    public class ModbusReader
    {
        private ModbusClient client;

        public bool isconnectde
        {
            get
            {
                return client != null && client.Connected;
            }
        }
        public void Connect()
        {
            if (client != null && client.Connected) return;

            client=new ModbusClient("127.0.0.1",502);

            client.UnitIdentifier = 1;

            client.Connect();
        }
        public void Close()
        {
            if (client != null && client.Connected)
                client.Connect();
        }
        public List<double> ReadTemperature()
        {
            if (client == null || !client.Connected)
            {
                Connect();
            }

            int[] values = client.ReadHoldingRegisters(0, 1);

            List<double> temps = new List<double>();

            foreach(int i in values)
            {
                double temp = i / 10.0;
                temps.Add(temp);
            }
            return temps;
        }
    }
}
