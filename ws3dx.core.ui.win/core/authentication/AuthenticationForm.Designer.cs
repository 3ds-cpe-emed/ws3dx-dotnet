namespace ws3dx.core.ui.win.authentication
{
    partial class AuthenticationForm
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
            this.m_premiseSecurityContextTextBox = new System.Windows.Forms.TextBox();
            this.m_passwordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_usernameTextBox = new System.Windows.Forms.TextBox();
            this.m_enoviaURLTextBox = new System.Windows.Forms.TextBox();
            this.m_passportURLTextBox = new System.Windows.Forms.TextBox();
            this.m_loginButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.cloudLabelTenant = new System.Windows.Forms.Label();
            this.m_tenantTextBox = new System.Windows.Forms.TextBox();
            this.m_cloudSecurityContextTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_premiseSecurityContextTextBox
            // 
            this.m_premiseSecurityContextTextBox.Location = new System.Drawing.Point(457, 136);
            this.m_premiseSecurityContextTextBox.Name = "m_premiseSecurityContextTextBox";
            this.m_premiseSecurityContextTextBox.Size = new System.Drawing.Size(58, 22);
            this.m_premiseSecurityContextTextBox.TabIndex = 7;
            this.m_premiseSecurityContextTextBox.Visible = false;
            // 
            // m_passwordTextBox
            // 
            this.m_passwordTextBox.Location = new System.Drawing.Point(135, 95);
            this.m_passwordTextBox.Name = "m_passwordTextBox";
            this.m_passwordTextBox.PasswordChar = '*';
            this.m_passwordTextBox.Size = new System.Drawing.Size(164, 22);
            this.m_passwordTextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Enovia URL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Passport URL :";
            // 
            // m_usernameTextBox
            // 
            this.m_usernameTextBox.Location = new System.Drawing.Point(135, 67);
            this.m_usernameTextBox.Name = "m_usernameTextBox";
            this.m_usernameTextBox.Size = new System.Drawing.Size(164, 22);
            this.m_usernameTextBox.TabIndex = 3;
            // 
            // m_enoviaURLTextBox
            // 
            this.m_enoviaURLTextBox.Location = new System.Drawing.Point(135, 36);
            this.m_enoviaURLTextBox.Name = "m_enoviaURLTextBox";
            this.m_enoviaURLTextBox.Size = new System.Drawing.Size(395, 22);
            this.m_enoviaURLTextBox.TabIndex = 2;
            // 
            // m_passportURLTextBox
            // 
            this.m_passportURLTextBox.Location = new System.Drawing.Point(135, 8);
            this.m_passportURLTextBox.Name = "m_passportURLTextBox";
            this.m_passportURLTextBox.Size = new System.Drawing.Size(395, 22);
            this.m_passportURLTextBox.TabIndex = 1;
            // 
            // m_loginButton
            // 
            this.m_loginButton.Location = new System.Drawing.Point(188, 136);
            this.m_loginButton.Name = "m_loginButton";
            this.m_loginButton.Size = new System.Drawing.Size(88, 32);
            this.m_loginButton.TabIndex = 0;
            this.m_loginButton.Text = "Login";
            this.m_loginButton.UseVisualStyleBackColor = true;
            this.m_loginButton.Click += new System.EventHandler(this.m_loginButton_Click);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(299, 136);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(88, 32);
            this.m_cancelButton.TabIndex = 14;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // cloudLabelTenant
            // 
            this.cloudLabelTenant.AutoSize = true;
            this.cloudLabelTenant.Location = new System.Drawing.Point(305, 68);
            this.cloudLabelTenant.Name = "cloudLabelTenant";
            this.cloudLabelTenant.Size = new System.Drawing.Size(61, 17);
            this.cloudLabelTenant.TabIndex = 34;
            this.cloudLabelTenant.Text = "Tenant :";
            // 
            // m_tenantTextBox
            // 
            this.m_tenantTextBox.Location = new System.Drawing.Point(368, 65);
            this.m_tenantTextBox.Name = "m_tenantTextBox";
            this.m_tenantTextBox.Size = new System.Drawing.Size(162, 22);
            this.m_tenantTextBox.TabIndex = 33;
            // 
            // m_cloudSecurityContextTextBox
            // 
            this.m_cloudSecurityContextTextBox.Location = new System.Drawing.Point(393, 136);
            this.m_cloudSecurityContextTextBox.Name = "m_cloudSecurityContextTextBox";
            this.m_cloudSecurityContextTextBox.Size = new System.Drawing.Size(58, 22);
            this.m_cloudSecurityContextTextBox.TabIndex = 31;
            this.m_cloudSecurityContextTextBox.Visible = false;
            // 
            // AuthenticationForm
            // 
            this.AcceptButton = this.m_loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(552, 186);
            this.Controls.Add(this.cloudLabelTenant);
            this.Controls.Add(this.m_tenantTextBox);
            this.Controls.Add(this.m_cloudSecurityContextTextBox);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_premiseSecurityContextTextBox);
            this.Controls.Add(this.m_passwordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_loginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_usernameTextBox);
            this.Controls.Add(this.m_enoviaURLTextBox);
            this.Controls.Add(this.m_passportURLTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Authentication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button m_loginButton;
        private System.Windows.Forms.TextBox m_passwordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_usernameTextBox;
        private System.Windows.Forms.TextBox m_enoviaURLTextBox;
        private System.Windows.Forms.TextBox m_passportURLTextBox;
        private System.Windows.Forms.TextBox m_premiseSecurityContextTextBox;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Label cloudLabelTenant;
        private System.Windows.Forms.TextBox m_tenantTextBox;
        private System.Windows.Forms.TextBox m_cloudSecurityContextTextBox;
    }
}

