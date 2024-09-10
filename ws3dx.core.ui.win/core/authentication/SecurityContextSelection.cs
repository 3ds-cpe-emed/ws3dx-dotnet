using ws3dx.core.data.impl;

namespace ds.authentication.ui.win
{
    public partial class SecurityContextSelection : Form
    {
        public SecurityContextSelection()
        {
            InitializeComponent();

            m_securityContextComboBox.DisplayMember = "DisplayValue";
            m_securityContextComboBox.ValueMember = "Value";
        }

        public void Initialize(IList<SecurityContext> _securityContext)
        {
            m_securityContextComboBox.Items.AddRange([.. _securityContext]);
        }

        public string SelectedContext
        {
            get {

                SecurityContext selectedSecContext = (SecurityContext)m_securityContextComboBox.SelectedItem;

                if ( selectedSecContext == null)
                {
                    return null;
                }

                return selectedSecContext.Value;
            }
            set
            {
                foreach (SecurityContext securityContext in m_securityContextComboBox.Items)
                {
                    if (securityContext.Value == value)
                    {
                        m_securityContextComboBox.SelectedItem = securityContext;
                        return;
                    }
                }
            }
        }

        private void m_okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
