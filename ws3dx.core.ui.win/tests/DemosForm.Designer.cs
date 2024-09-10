namespace ws3dx.core.ui.win.tests
{
    partial class m_demoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_authenticationDemoButton = new Button();
            m_searchMfgItemByNameRevisionDemoButton = new Button();
            m_searchEngItemByNameRevisionDemoButton = new Button();
            SuspendLayout();
            // 
            // m_authenticationDemoButton
            // 
            m_authenticationDemoButton.Location = new Point(22, 32);
            m_authenticationDemoButton.Name = "m_authenticationDemoButton";
            m_authenticationDemoButton.Size = new Size(160, 54);
            m_authenticationDemoButton.TabIndex = 0;
            m_authenticationDemoButton.Text = "Authentication";
            m_authenticationDemoButton.UseVisualStyleBackColor = true;
            m_authenticationDemoButton.Click += m_authenticationDemoButton_Click;
            // 
            // m_searchMfgItemByNameRevisionDemoButton
            // 
            m_searchMfgItemByNameRevisionDemoButton.Location = new Point(22, 118);
            m_searchMfgItemByNameRevisionDemoButton.Name = "m_searchMfgItemByNameRevisionDemoButton";
            m_searchMfgItemByNameRevisionDemoButton.Size = new Size(160, 54);
            m_searchMfgItemByNameRevisionDemoButton.TabIndex = 1;
            m_searchMfgItemByNameRevisionDemoButton.Text = "Search Mfg Item By Name and Revision";
            m_searchMfgItemByNameRevisionDemoButton.UseVisualStyleBackColor = true;
            m_searchMfgItemByNameRevisionDemoButton.Click += m_searchMfgItemByNameRevisionDemoButton_Click;
            // 
            // m_searchEngItemByNameRevisionDemoButton
            // 
            m_searchEngItemByNameRevisionDemoButton.Location = new Point(22, 200);
            m_searchEngItemByNameRevisionDemoButton.Name = "m_searchEngItemByNameRevisionDemoButton";
            m_searchEngItemByNameRevisionDemoButton.Size = new Size(160, 54);
            m_searchEngItemByNameRevisionDemoButton.TabIndex = 2;
            m_searchEngItemByNameRevisionDemoButton.Text = "Search Eng Item By Name and Revision";
            m_searchEngItemByNameRevisionDemoButton.UseVisualStyleBackColor = true;
            m_searchEngItemByNameRevisionDemoButton.Click += this.m_searchEngItemByNameRevisionDemoButton_Click;
            // 
            // m_demoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(205, 279);
            Controls.Add(m_searchEngItemByNameRevisionDemoButton);
            Controls.Add(m_searchMfgItemByNameRevisionDemoButton);
            Controls.Add(m_authenticationDemoButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "m_demoForm";
            Text = "DEMOs";
            Load += m_demoForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button m_authenticationDemoButton;
        private Button m_searchMfgItemByNameRevisionDemoButton;
        private Button m_searchEngItemByNameRevisionDemoButton;
    }
}
