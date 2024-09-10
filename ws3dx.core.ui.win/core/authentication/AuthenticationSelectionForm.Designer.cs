namespace ws3dx.core.ui.win.authentication
{
    partial class AuthenticationSelectionForm
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
            this.m_okButton = new System.Windows.Forms.Button();
            this.m_cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.m_platformTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_authenticationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_okButton
            // 
            this.m_okButton.Location = new System.Drawing.Point(86, 122);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(88, 32);
            this.m_okButton.TabIndex = 0;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.m_okButton_Click);
            // 
            // m_cancelButton
            // 
            this.m_cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cancelButton.Location = new System.Drawing.Point(205, 122);
            this.m_cancelButton.Name = "m_cancelButton";
            this.m_cancelButton.Size = new System.Drawing.Size(88, 32);
            this.m_cancelButton.TabIndex = 14;
            this.m_cancelButton.Text = "Cancel";
            this.m_cancelButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Type :";
            // 
            // m_platformTypeComboBox
            // 
            this.m_platformTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_platformTypeComboBox.FormattingEnabled = true;
            this.m_platformTypeComboBox.Location = new System.Drawing.Point(124, 22);
            this.m_platformTypeComboBox.Name = "m_platformTypeComboBox";
            this.m_platformTypeComboBox.Size = new System.Drawing.Size(224, 24);
            this.m_platformTypeComboBox.TabIndex = 16;
            this.m_platformTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.m_platformTypeComboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Authentication  :";
            // 
            // m_authenticationTypeComboBox
            // 
            this.m_authenticationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_authenticationTypeComboBox.FormattingEnabled = true;
            this.m_authenticationTypeComboBox.Location = new System.Drawing.Point(124, 67);
            this.m_authenticationTypeComboBox.Name = "m_authenticationTypeComboBox";
            this.m_authenticationTypeComboBox.Size = new System.Drawing.Size(224, 24);
            this.m_authenticationTypeComboBox.TabIndex = 20;
            // 
            // AuthenticationSelectionForm
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_cancelButton;
            this.ClientSize = new System.Drawing.Size(378, 172);
            this.Controls.Add(this.m_authenticationTypeComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.m_platformTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cancelButton);
            this.Controls.Add(this.m_okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthenticationSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Platform Type and Authentication method";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button m_okButton;
        private System.Windows.Forms.Button m_cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_platformTypeComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox m_authenticationTypeComboBox;
    }
}

