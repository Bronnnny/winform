namespace 投简历
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLJCK = new System.Windows.Forms.Button();
            this.btnJSSJ = new System.Windows.Forms.Button();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblststus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 337);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(969, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(12, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(197, 71);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "连接";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(197, 71);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLJCK
            // 
            this.btnLJCK.Location = new System.Drawing.Point(484, 12);
            this.btnLJCK.Name = "btnLJCK";
            this.btnLJCK.Size = new System.Drawing.Size(197, 71);
            this.btnLJCK.TabIndex = 1;
            this.btnLJCK.Text = "打开串口";
            this.btnLJCK.UseVisualStyleBackColor = true;
            this.btnLJCK.Click += new System.EventHandler(this.btnLJCK_Click);
            // 
            // btnJSSJ
            // 
            this.btnJSSJ.Location = new System.Drawing.Point(715, 12);
            this.btnJSSJ.Name = "btnJSSJ";
            this.btnJSSJ.Size = new System.Drawing.Size(197, 71);
            this.btnJSSJ.TabIndex = 1;
            this.btnJSSJ.Text = "发送接收数据";
            this.btnJSSJ.UseVisualStyleBackColor = true;
            this.btnJSSJ.Click += new System.EventHandler(this.btnJSSJ_Click);
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(28, 156);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(80, 18);
            this.lblTemp.TabIndex = 2;
            this.lblTemp.Text = "当前温度";
            // 
            // lblststus
            // 
            this.lblststus.AutoSize = true;
            this.lblststus.Location = new System.Drawing.Point(28, 213);
            this.lblststus.Name = "lblststus";
            this.lblststus.Size = new System.Drawing.Size(44, 18);
            this.lblststus.TabIndex = 2;
            this.lblststus.Text = "状态";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 572);
            this.Controls.Add(this.lblststus);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.btnJSSJ);
            this.Controls.Add(this.btnLJCK);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnLJCK;
        private System.Windows.Forms.Button btnJSSJ;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblststus;
        private System.Windows.Forms.Timer timer1;
    }
}

