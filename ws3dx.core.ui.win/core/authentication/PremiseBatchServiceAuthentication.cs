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
    public class PremiseBatchServiceAuthentication : IPremiseAuthenticationType
    {
        AuthenticationInfo m_authenticationInfo = null;

        public AuthenticationInfo GetAuthenticationInfo()
        {
            return m_authenticationInfo;
        }

        public DialogResult ShowForm(IWin32Window owner)
        {
            m_authenticationInfo = null;

            BatchServiceAuthenticationForm authForm = new BatchServiceAuthenticationForm();

            DialogResult result = authForm.ShowDialog(owner);

            if (result != DialogResult.OK)
                return result;

            string securityContext = authForm.SecurityContext;
            UserInfo userInfo = authForm.UserInfo;

            AuthenticationInfo info = new AuthenticationInfo();
            info.IsValidAuthentication = authForm.IsValidAuthentication;
            info.Passport = authForm.Passport;
            info.SecurityContext = securityContext;
            info.EnoviaURL = authForm.EnoviaURL;

            string serviceName = authForm.ServiceName;

            info.LoginMessage =
                string.Format("{2} : Batch {0} logged in on behalf of {1}", serviceName, userInfo.name, DateTime.Now);

            m_authenticationInfo = info;

            return result;
        }

        public override string ToString()
        {
            return "Batch Service Authentication";
        }
    }
}
