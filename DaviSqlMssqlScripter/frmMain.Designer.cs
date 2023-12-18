namespace DaviSqlMssqlScripter
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtServerAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUseIntegrated = new System.Windows.Forms.CheckBox();
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstDatabase = new System.Windows.Forms.ListBox();
            this.lstObjectTypesToScript = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1513, 56);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 34);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "작업시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnConnect_Start);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(30, 590);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(1448, 428);
            this.txtResult.TabIndex = 1;
            this.txtResult.WordWrap = false;
            // 
            // txtServerAddr
            // 
            this.txtServerAddr.Location = new System.Drawing.Point(121, 34);
            this.txtServerAddr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServerAddr.Name = "txtServerAddr";
            this.txtServerAddr.Size = new System.Drawing.Size(314, 28);
            this.txtServerAddr.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(121, 80);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 28);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "1433";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUseIntegrated);
            this.groupBox1.Controls.Add(this.btnConnect2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLoginId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServerAddr);
            this.groupBox1.Location = new System.Drawing.Point(30, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(681, 284);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Info";
            // 
            // chkUseIntegrated
            // 
            this.chkUseIntegrated.AutoSize = true;
            this.chkUseIntegrated.Checked = true;
            this.chkUseIntegrated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseIntegrated.Location = new System.Drawing.Point(121, 147);
            this.chkUseIntegrated.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseIntegrated.Name = "chkUseIntegrated";
            this.chkUseIntegrated.Size = new System.Drawing.Size(233, 22);
            this.chkUseIntegrated.TabIndex = 4;
            this.chkUseIntegrated.Text = "Integrated Authentication";
            this.chkUseIntegrated.UseVisualStyleBackColor = true;
            this.chkUseIntegrated.CheckedChanged += new System.EventHandler(this.chkUseIntegrated_CheckedChanged);
            // 
            // btnConnect2
            // 
            this.btnConnect2.Location = new System.Drawing.Point(480, 30);
            this.btnConnect2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(107, 34);
            this.btnConnect2.TabIndex = 7;
            this.btnConnect2.Text = "Connect";
            this.btnConnect2.UseVisualStyleBackColor = true;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 220);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(314, 28);
            this.txtPassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 226);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(121, 180);
            this.txtLoginId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(314, 28);
            this.txtLoginId.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 188);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // lstDatabase
            // 
            this.lstDatabase.FormattingEnabled = true;
            this.lstDatabase.ItemHeight = 18;
            this.lstDatabase.Location = new System.Drawing.Point(30, 310);
            this.lstDatabase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstDatabase.Name = "lstDatabase";
            this.lstDatabase.Size = new System.Drawing.Size(378, 202);
            this.lstDatabase.TabIndex = 7;
            // 
            // lstObjectTypesToScript
            // 
            this.lstObjectTypesToScript.FormattingEnabled = true;
            this.lstObjectTypesToScript.ItemHeight = 18;
            this.lstObjectTypesToScript.Location = new System.Drawing.Point(769, 32);
            this.lstObjectTypesToScript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstObjectTypesToScript.Name = "lstObjectTypesToScript";
            this.lstObjectTypesToScript.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstObjectTypesToScript.Size = new System.Drawing.Size(388, 418);
            this.lstObjectTypesToScript.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 1038);
            this.Controls.Add(this.lstObjectTypesToScript);
            this.Controls.Add(this.lstDatabase);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Mssql Scripter";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtServerAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect2;
        private System.Windows.Forms.ListBox lstDatabase;
        private System.Windows.Forms.CheckBox chkUseIntegrated;
        private System.Windows.Forms.ListBox lstObjectTypesToScript;
    }
}

