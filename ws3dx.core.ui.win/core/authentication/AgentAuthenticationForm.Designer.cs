namespace ws3dx.core.ui.win.authentication
{
    partial class AgentAuthenticationForm
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
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.m_loginButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.m_securityContextTextBox = new System.Windows.Forms.TextBox();
            this.m_passwordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_enoviaURLTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_serviceNameTextBox = new System.Windows.Forms.TextBox();
            this.m_tenantTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(380, 171);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(88, 32);
            this.m_cancelButton.TabIndex = 16;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_loginButton
            // 
            this.m_loginButton.Location = new System.Drawing.Point(236, 171);
            this.m_loginButton.Name = "m_loginButton";
            this.m_loginButton.Size = new System.Drawing.Size(88, 32);
            this.m_loginButton.TabIndex = 15;
            this.m_loginButton.Text = "Login";
            this.m_loginButton.UseVisualStyleBackColor = true;
            this.m_loginButton.Click += new System.EventHandler(this.m_loginButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Security Context:";
            // 
            // m_securityContextTextBox
            // 
            this.m_securityContextTextBox.Location = new System.Drawing.Point(461, 107);
            this.m_securityContextTextBox.Name = "m_securityContextTextBox";
            this.m_securityContextTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_securityContextTextBox.TabIndex = 25;
            // 
            // m_passwordTextBox
            // 
            this.m_passwordTextBox.Location = new System.Drawing.Point(461, 63);
            this.m_passwordTextBox.Name = "m_passwordTextBox";
            this.m_passwordTextBox.PasswordChar = '*';
            this.m_passwordTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_passwordTextBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Secret :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enovia URL :";
            // 
            // m_enoviaURLTextBox
            // 
            this.m_enoviaURLTextBox.Location = new System.Drawing.Point(139, 21);
            this.m_enoviaURLTextBox.Name = "m_enoviaURLTextBox";
            this.m_enoviaURLTextBox.Size = new System.Drawing.Size(542, 22);
            this.m_enoviaURLTextBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Agent Id :";
            // 
            // m_serviceNameTextBox
            // 
            this.m_serviceNameTextBox.Location = new System.Drawing.Point(139, 63);
            this.m_serviceNameTextBox.Name = "m_serviceNameTextBox";
            this.m_serviceNameTextBox.Size = new System.Drawing.Size(186, 22);
            this.m_serviceNameTextBox.TabIndex = 27;
            // 
            // m_tenantTextBox
            // 
            this.m_tenantTextBox.Location = new System.Drawing.Point(139, 107);
            this.m_tenantTextBox.Name = "m_tenantTextBox";
            this.m_tenantTextBox.Size = new System.Drawing.Size(186, 22);
            this.m_tenantTextBox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tenant :";
            // 
            // AgentAuthenticationForm
            // 
            this.AcceptButton = this.m_loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(704, 231);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_tenantTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_serviceNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_securityContextTextBox);
            this.Controls.Add(this.m_passwordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_loginButton);
            this.Controls.Add(this.m_enoviaURLTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgentAuthenticationForm";
            this.Text = "Agent Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Button m_loginButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_securityContextTextBox;
        private System.Windows.Forms.TextBox m_passwordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_enoviaURLTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_serviceNameTextBox;
        private System.Windows.Forms.TextBox m_tenantTextBox;
        private System.Windows.Forms.Label label3;
    }
}