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

using ws3dx.core.data.impl;

namespace ws3dx.core.ui.win.authentication
{
    class CloudAgentAuthentication : ICloudAuthenticationType
    {
        AuthenticationInfo m_authenticationInfo = null;

        public AuthenticationInfo GetAuthenticationInfo()
        {
            return m_authenticationInfo;
        }

        public DialogResult ShowForm(IWin32Window owner)
        {
            AgentAuthenticationForm authenticationForm = new AgentAuthenticationForm();

            DialogResult result = authenticationForm.ShowDialog(owner);

            if (result != DialogResult.OK)
                return result;

            string securityContext = authenticationForm.SecurityContext;

            UserInfo userInfo = authenticationForm.UserInfo;

            AuthenticationInfo info = new AuthenticationInfo();

            info.IsValidAuthentication = authenticationForm.IsValidAuthentication;
            info.Passport = authenticationForm.Passport;
            info.SecurityContext = securityContext;
            info.EnoviaURL = authenticationForm.EnoviaURL;
            info.Tenant = authenticationForm.Tenant;

            string[] securityContextSplit = securityContext.Split('.');

            info.LoginMessage =
                string.Format("{3} : {0} logged in as {1} to '{2}'", userInfo.name, securityContextSplit[0], securityContextSplit[2], DateTime.Now);

            m_authenticationInfo = info;

            return result;
        }

        public override string ToString() { return "Agent Authentication"; }
    }
}
