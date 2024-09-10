namespace ds.authentication.ui.win
{
    partial class SecurityContextSelection
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
            this.m_securityContextComboBox = new System.Windows.Forms.ComboBox();
            this.m_okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_securityContextComboBox
            // 
            this.m_securityContextComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_securityContextComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_securityContextComboBox.FormattingEnabled = true;
            this.m_securityContextComboBox.Location = new System.Drawing.Point(12, 35);
            this.m_securityContextComboBox.Name = "m_securityContextComboBox";
            this.m_securityContextComboBox.Size = new System.Drawing.Size(378, 24);
            this.m_securityContextComboBox.TabIndex = 0;
            // 
            // m_okButton
            // 
            this.m_okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_okButton.Location = new System.Drawing.Point(151, 83);
            this.m_okButton.Name = "m_okButton";
            this.m_okButton.Size = new System.Drawing.Size(112, 35);
            this.m_okButton.TabIndex = 1;
            this.m_okButton.Text = "OK";
            this.m_okButton.UseVisualStyleBackColor = true;
            this.m_okButton.Click += new System.EventHandler(this.m_okButton_Click);
            // 
            // SecurityContextSelection
            // 
            this.AcceptButton = this.m_okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 141);
            this.Controls.Add(this.m_okButton);
            this.Controls.Add(this.m_securityContextComboBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 188);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 188);
            this.Name = "SecurityContextSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Security Context";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_securityContextComboBox;
        private System.Windows.Forms.Button m_okButton;
    }
}