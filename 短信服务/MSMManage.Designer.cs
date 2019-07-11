namespace 短信服务
{
    partial class MSMManage
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_MSG = new System.Windows.Forms.TextBox();
            this.txt_CallId = new System.Windows.Forms.TextBox();
            this.btn_Command = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.txt_Message = new System.Windows.Forms.TextBox();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.txt_Reg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_MSG
            // 
            this.txt_MSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MSG.BackColor = System.Drawing.SystemColors.Window;
            this.txt_MSG.Location = new System.Drawing.Point(12, 274);
            this.txt_MSG.Multiline = true;
            this.txt_MSG.Name = "txt_MSG";
            this.txt_MSG.ReadOnly = true;
            this.txt_MSG.Size = new System.Drawing.Size(449, 109);
            this.txt_MSG.TabIndex = 0;
            // 
            // txt_CallId
            // 
            this.txt_CallId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CallId.BackColor = System.Drawing.SystemColors.Window;
            this.txt_CallId.Location = new System.Drawing.Point(12, 128);
            this.txt_CallId.Multiline = true;
            this.txt_CallId.Name = "txt_CallId";
            this.txt_CallId.ReadOnly = true;
            this.txt_CallId.Size = new System.Drawing.Size(449, 140);
            this.txt_CallId.TabIndex = 1;
            // 
            // btn_Command
            // 
            this.btn_Command.Location = new System.Drawing.Point(12, 12);
            this.btn_Command.Name = "btn_Command";
            this.btn_Command.Size = new System.Drawing.Size(75, 23);
            this.btn_Command.TabIndex = 2;
            this.btn_Command.Text = "打开连接";
            this.btn_Command.UseVisualStyleBackColor = true;
            this.btn_Command.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "初始化短信服务";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(364, 12);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 4;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_Number
            // 
            this.txt_Number.Location = new System.Drawing.Point(195, 14);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(163, 21);
            this.txt_Number.TabIndex = 5;
            this.txt_Number.Text = "18627104360";
            // 
            // txt_Message
            // 
            this.txt_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Message.Location = new System.Drawing.Point(12, 41);
            this.txt_Message.Multiline = true;
            this.txt_Message.Name = "txt_Message";
            this.txt_Message.Size = new System.Drawing.Size(449, 81);
            this.txt_Message.TabIndex = 6;
            this.txt_Message.Text = "测试啊车市啊";
            // 
            // btn_Reg
            // 
            this.btn_Reg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Reg.Location = new System.Drawing.Point(386, 391);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(75, 23);
            this.btn_Reg.TabIndex = 7;
            this.btn_Reg.Text = "注册";
            this.btn_Reg.UseVisualStyleBackColor = true;
            this.btn_Reg.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_Reg
            // 
            this.txt_Reg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Reg.Location = new System.Drawing.Point(12, 391);
            this.txt_Reg.Name = "txt_Reg";
            this.txt_Reg.Size = new System.Drawing.Size(368, 21);
            this.txt_Reg.TabIndex = 8;
            this.txt_Reg.Text = "zwdigital";
            // 
            // MSMManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 424);
            this.Controls.Add(this.txt_Reg);
            this.Controls.Add(this.btn_Reg);
            this.Controls.Add(this.txt_Message);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Command);
            this.Controls.Add(this.txt_CallId);
            this.Controls.Add(this.txt_MSG);
            this.Name = "MSMManage";
            this.Text = "短信服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSMManage_FormClosing);
            this.Load += new System.EventHandler(this.MSMManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_MSG;
        private System.Windows.Forms.TextBox txt_CallId;
        private System.Windows.Forms.Button btn_Command;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.TextBox txt_Message;
        private System.Windows.Forms.Button btn_Reg;
        private System.Windows.Forms.TextBox txt_Reg;

    }
}

