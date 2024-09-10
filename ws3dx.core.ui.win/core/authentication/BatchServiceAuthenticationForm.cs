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

using ws3dx.authentication.data;
using ws3dx.authentication.data.impl;
using ws3dx.authentication.data.impl.passport;
using ws3dx.core.data.impl;
using ws3dx.core.service;

namespace ws3dx.core.ui.win.authentication
{
    public partial class BatchServiceAuthenticationForm : Form
    {
        public BatchServiceAuthenticationForm()
        {
            InitializeComponent();

            m_passportURLTextBox.Text = Properties.Settings.Default.pba_passportURL;
            m_enoviaURLTextBox.Text = Properties.Settings.Default.pba_enoviaURL;
            m_usernameTextBox.Text = Properties.Settings.Default.pba_username;
            m_serviceNameTextBox.Text = Properties.Settings.Default.pba_servicename;

            m_securityContextTextBox.Text = Properties.Settings.Default.pba_securitycontext;
        }

        public UserInfo UserInfo { get; private set; } = null;

        public IPassportAuthentication Passport { get; private set; } = null;

        public string EnoviaURL { get { return m_enoviaURLTextBox.Text; } set { m_enoviaURLTextBox.Text = value; } }

        public string SecurityContext { get { return m_securityContextTextBox.Text; } set { m_securityContextTextBox.Text = value; } }

        public string ServiceName { get { return m_serviceNameTextBox.Text; } }

        public bool IsValidAuthentication
        {
            get
            {
                return ((Passport != null) && (((BatchServicePassport)Passport).IsCookieAuthenticated));
            }
        }

        private async void m_loginButton_Click(object sender, EventArgs e)
        {
            string enoviaURL = EnoviaURL.Trim(' ');
            string passportURL = m_passportURLTextBox.Text.Trim(' ');
            string service = m_serviceNameTextBox.Text.Trim(' ');
            string username = m_usernameTextBox.Text.Trim(' ');
            string password = m_passwordTextBox.Text;

            string securityContextParser = SecurityContext.Trim(' ');

            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime startTime = DateTime.Now;

                // The first thing to do is to authenticate in the 3DEXPERIENCE Platform

                Passport = new BatchServicePassport(passportURL);

                bool isValid = await ((BatchServicePassport)Passport).CASLogin(service, password, username);

                BatchServicePassportAuthentication authenticationIdentity = ((BatchServicePassport)Passport).AuthenticationIdentity;

                //Option 1 - Get associated on-behalf user credentials
                UserInfoService userInfoService = new UserInfoService(enoviaURL, Passport);

                userInfoService.Current = true;
                userInfoService.IncludeCollaborativeSpaces = true;
                userInfoService.IncludePreferredCredentials = true;

                // verify authentication by getting associated user information
                UserInfo = await userInfoService.GetCurrentUserInfoAsync();

                //Another option is to get the username from the authenticationidentity
                //UserInfo userInfo = new UserInfo();
                //userInfo.name = (string)authenticationIdentity.userdata.fields["username"];
                //this.UserInfo = userInfo;
                DateTime endTime = DateTime.Now;

                TimeSpan elapsedTime = endTime - startTime;

                this.Cursor = Cursors.Default;

                MessageBox.Show(string.Format("Successfully logged in '{0}' in {1:0.0} secs", service, elapsedTime.TotalSeconds), "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                //Save settings
                Properties.Settings.Default.pba_passportURL = m_passportURLTextBox.Text;
                Properties.Settings.Default.pba_enoviaURL = m_enoviaURLTextBox.Text;
                Properties.Settings.Default.pba_username = m_usernameTextBox.Text;
                Properties.Settings.Default.pba_servicename = m_serviceNameTextBox.Text;
                Properties.Settings.Default.pba_securitycontext = m_securityContextTextBox.Text;
                //password?

                Properties.Settings.Default.Save();
            }
            catch (Exception _ex)
            {
                this.Cursor = Cursors.Default;

                DialogResult = DialogResult.Abort;

                MessageBox.Show(_ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MessageBox.Show(_ex.StackTrace, "Exception Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.Close();
        }

        private void BatchServiceAuthenticationForm_Load(object sender, EventArgs e)
        {
        }
    }
}
