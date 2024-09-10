namespace ws3dx.core.ui.win.authentication
{
    partial class BatchServiceAuthenticationForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_usernameTextBox = new System.Windows.Forms.TextBox();
            this.m_enoviaURLTextBox = new System.Windows.Forms.TextBox();
            this.m_passportURLTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_serviceNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(380, 210);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(88, 32);
            this.m_cancelButton.TabIndex = 16;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // m_loginButton
            // 
            this.m_loginButton.Location = new System.Drawing.Point(236, 210);
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
            this.label6.Location = new System.Drawing.Point(364, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Sec. Context:";
            // 
            // m_securityContextTextBox
            // 
            this.m_securityContextTextBox.Location = new System.Drawing.Point(461, 141);
            this.m_securityContextTextBox.Name = "m_securityContextTextBox";
            this.m_securityContextTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_securityContextTextBox.TabIndex = 25;
            // 
            // m_passwordTextBox
            // 
            this.m_passwordTextBox.Location = new System.Drawing.Point(461, 102);
            this.m_passwordTextBox.Name = "m_passwordTextBox";
            this.m_passwordTextBox.PasswordChar = '*';
            this.m_passwordTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_passwordTextBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enovia URL :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Passport URL :";
            // 
            // m_usernameTextBox
            // 
            this.m_usernameTextBox.Location = new System.Drawing.Point(139, 141);
            this.m_usernameTextBox.Name = "m_usernameTextBox";
            this.m_usernameTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_usernameTextBox.TabIndex = 20;
            // 
            // m_enoviaURLTextBox
            // 
            this.m_enoviaURLTextBox.Location = new System.Drawing.Point(139, 60);
            this.m_enoviaURLTextBox.Name = "m_enoviaURLTextBox";
            this.m_enoviaURLTextBox.Size = new System.Drawing.Size(542, 22);
            this.m_enoviaURLTextBox.TabIndex = 18;
            // 
            // m_passportURLTextBox
            // 
            this.m_passportURLTextBox.Location = new System.Drawing.Point(139, 21);
            this.m_passportURLTextBox.Name = "m_passportURLTextBox";
            this.m_passportURLTextBox.Size = new System.Drawing.Size(542, 22);
            this.m_passportURLTextBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Batch Service :";
            // 
            // m_serviceNameTextBox
            // 
            this.m_serviceNameTextBox.Location = new System.Drawing.Point(139, 102);
            this.m_serviceNameTextBox.Name = "m_serviceNameTextBox";
            this.m_serviceNameTextBox.Size = new System.Drawing.Size(220, 22);
            this.m_serviceNameTextBox.TabIndex = 27;
            // 
            // BatchServiceAuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 267);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_serviceNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_securityContextTextBox);
            this.Controls.Add(this.m_passwordTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_usernameTextBox);
            this.Controls.Add(this.m_enoviaURLTextBox);
            this.Controls.Add(this.m_passportURLTextBox);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_loginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchServiceAuthenticationForm";
            this.Text = "Batch Service Authentication";
            this.Load += new System.EventHandler(this.BatchServiceAuthenticationForm_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_usernameTextBox;
        private System.Windows.Forms.TextBox m_enoviaURLTextBox;
        private System.Windows.Forms.TextBox m_passportURLTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_serviceNameTextBox;
    }
}