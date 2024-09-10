namespace ws3dx.core.ui.win.search
{
    partial class SearchByNameRevisionForm
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
            m_searchButton = new Button();
            m_nameLabel = new Label();
            m_revisionLabel = new Label();
            m_nameTextBox = new TextBox();
            m_revisionTextBox = new TextBox();
            m_searchResultsGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)m_searchResultsGridView).BeginInit();
            SuspendLayout();
            // 
            // m_searchButton
            // 
            m_searchButton.Anchor = AnchorStyles.Bottom;
            m_searchButton.Location = new Point(171, 313);
            m_searchButton.Name = "m_searchButton";
            m_searchButton.Size = new Size(191, 48);
            m_searchButton.TabIndex = 2;
            m_searchButton.Text = "Search";
            m_searchButton.UseVisualStyleBackColor = true;
            m_searchButton.Click += m_searchButton_Click;
            // 
            // m_nameLabel
            // 
            m_nameLabel.AutoSize = true;
            m_nameLabel.Location = new Point(12, 16);
            m_nameLabel.Name = "m_nameLabel";
            m_nameLabel.Size = new Size(56, 20);
            m_nameLabel.TabIndex = 4;
            m_nameLabel.Text = "Name :";
            // 
            // m_revisionLabel
            // 
            m_revisionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_revisionLabel.AutoSize = true;
            m_revisionLabel.Location = new Point(328, 16);
            m_revisionLabel.Name = "m_revisionLabel";
            m_revisionLabel.Size = new Size(71, 20);
            m_revisionLabel.TabIndex = 5;
            m_revisionLabel.Text = "Revision :";
            // 
            // m_nameTextBox
            // 
            m_nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            m_nameTextBox.Location = new Point(74, 13);
            m_nameTextBox.Name = "m_nameTextBox";
            m_nameTextBox.Size = new Size(248, 27);
            m_nameTextBox.TabIndex = 0;
            // 
            // m_revisionTextBox
            // 
            m_revisionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            m_revisionTextBox.Location = new Point(405, 16);
            m_revisionTextBox.Name = "m_revisionTextBox";
            m_revisionTextBox.Size = new Size(125, 27);
            m_revisionTextBox.TabIndex = 1;
            // 
            // m_searchResultsGridView
            // 
            m_searchResultsGridView.AllowUserToAddRows = false;
            m_searchResultsGridView.AllowUserToDeleteRows = false;
            m_searchResultsGridView.AllowUserToOrderColumns = true;
            m_searchResultsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            m_searchResultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            m_searchResultsGridView.Location = new Point(12, 52);
            m_searchResultsGridView.MultiSelect = false;
            m_searchResultsGridView.Name = "m_searchResultsGridView";
            m_searchResultsGridView.ReadOnly = true;
            m_searchResultsGridView.RowHeadersWidth = 51;
            m_searchResultsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            m_searchResultsGridView.Size = new Size(518, 245);
            m_searchResultsGridView.TabIndex = 3;
            m_searchResultsGridView.CellContentClick += m_searchResultsGridView_CellContentClick;
            m_searchResultsGridView.CellContentDoubleClick += m_searchResultsGridView_CellContentDoubleClick;
            m_searchResultsGridView.CellDoubleClick += m_searchResultsGridView_CellDoubleClick;
            // 
            // SearchByNameRevisionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 373);
            Controls.Add(m_searchResultsGridView);
            Controls.Add(m_revisionTextBox);
            Controls.Add(m_nameTextBox);
            Controls.Add(m_revisionLabel);
            Controls.Add(m_nameLabel);
            Controls.Add(m_searchButton);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(560, 420);
            Name = "SearchByNameRevisionForm";
            Text = "Search By Name and Revision";
            ((System.ComponentModel.ISupportInitialize)m_searchResultsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button m_searchButton;
        private Label m_nameLabel;
        private Label m_revisionLabel;
        private TextBox m_nameTextBox;
        private TextBox m_revisionTextBox;
        private DataGridView m_searchResultsGridView;
    }
}