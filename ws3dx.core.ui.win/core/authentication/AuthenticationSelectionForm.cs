//------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2020 Dassault Systèmes - CPE EMED
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify,
// merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished
// to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
// BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//------------------------------------------------------------------------------------------------------------------------------------

namespace ws3dx.core.ui.win.authentication
{
    public partial class AuthenticationSelectionForm : Form
    {
        public AuthenticationSelectionForm()
        {
            InitializeComponent();

            m_platformTypeComboBox.BeginUpdate();

            m_platformTypeComboBox.Items.Add(new CloudPlatformType());
            m_platformTypeComboBox.Items.Add(new PremisePlatformType());

            int selPlatformType = Properties.Settings.Default.sel_platform_type;

            if (selPlatformType >= m_platformTypeComboBox.Items.Count)
                selPlatformType = 0;

            m_platformTypeComboBox.SelectedIndex = selPlatformType;

            m_platformTypeComboBox.EndUpdate();
        }

        private void m_okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Properties.Settings.Default.sel_platform_type = m_platformTypeComboBox.SelectedIndex;
            Properties.Settings.Default.sel_auth_method = m_authenticationTypeComboBox.SelectedIndex;

            Properties.Settings.Default.Save();

            this.Close();
        }

        public IAuthenticationType SelectedAuthenticationType
        {
            get
            {
                return ((IAuthenticationType)m_authenticationTypeComboBox.SelectedItem);
            }
        }

        private void m_platformTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_authenticationTypeComboBox.BeginUpdate();
                m_authenticationTypeComboBox.Items.Clear();

                if (m_platformTypeComboBox.SelectedItem is PremisePlatformType)
                {
                    m_authenticationTypeComboBox.Items.AddRange(PremisePlatformType.GetAvailableAuthenticationTypes().ToArray());
                }
                else
                {
                    m_authenticationTypeComboBox.Items.AddRange(CloudPlatformType.GetAvailableAuthenticationTypes().ToArray());
                }

                int selAuthMethod = Properties.Settings.Default.sel_auth_method;

                if (selAuthMethod >= m_authenticationTypeComboBox.Items.Count)
                    selAuthMethod = 0;

                m_authenticationTypeComboBox.SelectedIndex = Properties.Settings.Default.sel_auth_method;
            }
            finally
            {
                m_authenticationTypeComboBox.EndUpdate();
            }
        }
    }
}
