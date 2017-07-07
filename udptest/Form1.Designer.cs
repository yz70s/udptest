namespace udptest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tosendaddr = new System.Windows.Forms.TextBox();
            this.sendcount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tosendport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.receivecount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toreceiveport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(22, 129);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(303, 148);
            this.button1.TabIndex = 0;
            this.button1.Text = "SEND";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 129);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(303, 148);
            this.button2.TabIndex = 1;
            this.button2.Text = "RECEIVE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tosendaddr
            // 
            this.tosendaddr.Location = new System.Drawing.Point(176, 9);
            this.tosendaddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tosendaddr.Name = "tosendaddr";
            this.tosendaddr.Size = new System.Drawing.Size(148, 26);
            this.tosendaddr.TabIndex = 2;
            this.tosendaddr.Text = "137.204.48.1";
            // 
            // sendcount
            // 
            this.sendcount.Enabled = false;
            this.sendcount.Location = new System.Drawing.Point(176, 89);
            this.sendcount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendcount.Name = "sendcount";
            this.sendcount.Size = new System.Drawing.Size(148, 26);
            this.sendcount.TabIndex = 3;
            this.sendcount.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Destinazione:";
            // 
            // tosendport
            // 
            this.tosendport.Location = new System.Drawing.Point(176, 49);
            this.tosendport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tosendport.Name = "tosendport";
            this.tosendport.Size = new System.Drawing.Size(148, 26);
            this.tosendport.TabIndex = 5;
            this.tosendport.Text = "23456";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Porta Destinazione:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero pacchetti:";
            // 
            // receivecount
            // 
            this.receivecount.Location = new System.Drawing.Point(488, 89);
            this.receivecount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.receivecount.Name = "receivecount";
            this.receivecount.Size = new System.Drawing.Size(148, 26);
            this.receivecount.TabIndex = 8;
            this.receivecount.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Numero pacchetti:";
            // 
            // toreceiveport
            // 
            this.toreceiveport.Location = new System.Drawing.Point(488, 49);
            this.toreceiveport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toreceiveport.Name = "toreceiveport";
            this.toreceiveport.Size = new System.Drawing.Size(148, 26);
            this.toreceiveport.TabIndex = 10;
            this.toreceiveport.Text = "22981";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Porta Ricezione:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(488, 9);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 30);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Salva Dati";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 298);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toreceiveport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.receivecount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tosendport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendcount);
            this.Controls.Add(this.tosendaddr);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "fpga udptest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tosendaddr;
        private System.Windows.Forms.TextBox sendcount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tosendport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox receivecount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox toreceiveport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

