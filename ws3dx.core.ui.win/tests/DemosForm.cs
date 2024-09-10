using ws3dx.authentication.data;
using ws3dx.core.ui.win.authentication;
using ws3dx.core.ui.win.search;

using ws3dx.dseng.data;
using ws3dx.dseng.core.service;
using ws3dx.dsmfg.data;
using ws3dx.dsmfg.service;

namespace ws3dx.core.ui.win.tests
{
    public partial class m_demoForm : Form
    {
        public m_demoForm()
        {
            InitializeComponent();
        }

        IPassportAuthentication Passport { get; set; }

        MfgItemService MfgItemService { get; set; }
        EngItemService EngItemService { get; set; }

        private void m_authenticationDemoButton_Click(object sender, EventArgs e)
        {
            AuthenticationSelectionForm authSelectionForm = new AuthenticationSelectionForm();

            if (authSelectionForm.ShowDialog(this) != DialogResult.OK)
                return;

            IAuthenticationType authenticationType = authSelectionForm.SelectedAuthenticationType;

            if (authenticationType.ShowForm(this) == DialogResult.OK)
            {
                AuthenticationInfo authInfo = authenticationType.GetAuthenticationInfo();

                if (!authInfo.IsValidAuthentication)             
                {
                    m_searchMfgItemByNameRevisionDemoButton.Enabled = false;
                    m_searchEngItemByNameRevisionDemoButton.Enabled = false;

                    return;
                }

                this.Passport = authInfo.Passport;

                string securityContext = authInfo.SecurityContext;
                string enoviaURL = authInfo.EnoviaURL;

                MessageBox.Show(authInfo.LoginMessage, "Login Message", MessageBoxButtons.OK);

                MfgItemService = new MfgItemService(enoviaURL, Passport);
                MfgItemService.SecurityContext = securityContext;
                MfgItemService.Tenant = authInfo.Tenant;

                EngItemService = new EngItemService(enoviaURL, Passport);
                EngItemService.SecurityContext = securityContext;
                EngItemService.Tenant = authInfo.Tenant;

                m_searchMfgItemByNameRevisionDemoButton.Enabled = true;
                m_searchEngItemByNameRevisionDemoButton.Enabled = true;
            }
        }

        private void m_demoForm_Load(object sender, EventArgs e)
        {

        }

        private void m_searchMfgItemByNameRevisionDemoButton_Click(object sender, EventArgs e)
        {
            SearchByNameRevisionForm searchByNameRevisionForm = new SearchByNameRevisionForm(MfgItemService, typeof(IMfgItemMask));

            searchByNameRevisionForm.StartPosition = FormStartPosition.CenterParent;
            searchByNameRevisionForm.ShowDialog(this);

            if (searchByNameRevisionForm.SelectedItem == null) return;
            
            IMfgItemMask selectedMfgItem = searchByNameRevisionForm.SelectedItem;

            MessageBox.Show(selectedMfgItem.Title, "Info", MessageBoxButtons.OK);
        }


        private void m_searchEngItemByNameRevisionDemoButton_Click(object sender, EventArgs e)
        {
            SearchByNameRevisionForm searchByNameRevisionForm = new SearchByNameRevisionForm(EngItemService, typeof(IEngItemDefaultMask));

            searchByNameRevisionForm.StartPosition = FormStartPosition.CenterParent;
            searchByNameRevisionForm.ShowDialog(this);

            if (searchByNameRevisionForm.SelectedItem == null) return;

            IMfgItemMask selectedMfgItem = searchByNameRevisionForm.SelectedItem;

            MessageBox.Show(selectedMfgItem.Title, "Info", MessageBoxButtons.OK);
        }
    }
}
