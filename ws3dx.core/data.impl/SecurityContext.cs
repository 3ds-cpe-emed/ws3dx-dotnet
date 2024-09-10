// ------------------------------------------------------------------------------------------------------------------------------------
// Copyright 2023 Dassault Systèmes - CPE EMED
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
// ------------------------------------------------------------------------------------------------------------------------------------

using System.Data;

namespace ws3dx.core.data.impl
{
   public class SecurityContext
   {
        public const string RESTRICTED = "(Restricted)";

        public const string ADMINISTRATOR = "Administrator";
        public const string VPLM_ADMINISTRATOR = "VPLMAdmin";
    
        public const string VPLM_OWNER = "VPLMProjectAdministrator";
        public const string VPLM_RESTRICTED_OWNER = "3DSRestrictedOwner";
        public const string OWNER = "Owner";
        public const string RESTRICTED_OWNER = RESTRICTED + OWNER;

        public const string VPLM_LEADER = "VPLMProjectLeader";
        public const string VPLM_RESTRICTED_LEADER = "3DSRestrictedLeader";
        public const string LEADER = "Leader";
        public const string RESTRICTED_LEADER = RESTRICTED + LEADER;

        public const string VPLM_AUTHOR= "VPLMCreator";
        public const string VPLM_RESTRICTED_AUTHOR = "3DSRestrictedAuthor";
        public const string AUTHOR = "Author";
        public const string RESTRICTED_AUTHOR = RESTRICTED + AUTHOR;

        public const string VPLM_CONTRIBUTOR = "VPLMExperimenter";
        public const string VPLM_RESTRICTED_CONTRIBUTOR = "3DSRestrictedContributor";
        public const string CONTRIBUTOR = "Contributor";
        public const string RESTRICTED_CONTRIBUTOR = RESTRICTED + CONTRIBUTOR;

        public const string VPLM_VIEWER = "VPLMViewer";
        public const string VPLM_RESTRICTED_VIEWER = "3DSRestrictedReader";
        public const string VIEWER = "Viewer";
        public const string RESTRICTED_VIEWER = RESTRICTED + VIEWER;

        public const string VPLM_PUBLIC_READER = "VPLMSecuredCrossAccess"; //Ancestor before creation of restricted roles
        public const string PUBLIC_VIEWER = "Public Viewer";

        public static string getRoleDisplay(string _role)
        { 
            if (_role == null) return null;

            string roleDisplay = _role;

            switch (_role)
            {
                case VPLM_ADMINISTRATOR:
                    roleDisplay = ADMINISTRATOR;
                    break;

                case VPLM_OWNER:
                    roleDisplay = OWNER;
                    break;

                case VPLM_RESTRICTED_OWNER:
                    roleDisplay = RESTRICTED_OWNER;
                    break;

                case VPLM_LEADER:
                    roleDisplay = LEADER;
                    break;

                case VPLM_RESTRICTED_LEADER:
                    roleDisplay = RESTRICTED_LEADER;
                    break;

                case VPLM_AUTHOR:
                    roleDisplay = AUTHOR;
                    break;

                case VPLM_RESTRICTED_AUTHOR:
                    roleDisplay = RESTRICTED_AUTHOR;
                    break;

                case VPLM_CONTRIBUTOR:
                    roleDisplay = CONTRIBUTOR;
                    break;

                case VPLM_RESTRICTED_CONTRIBUTOR:
                    roleDisplay = RESTRICTED_CONTRIBUTOR;
                    break;

                case VPLM_VIEWER:
                    roleDisplay = VIEWER;
                    break;

                case VPLM_RESTRICTED_VIEWER:
                    roleDisplay = RESTRICTED_VIEWER;
                    break;

                case VPLM_PUBLIC_READER:
                    roleDisplay = PUBLIC_VIEWER;
                    break;

                default:
                    roleDisplay = _role;
                    break;
            }

            return roleDisplay;
        }

        public string Value { get { return ToString();}}

        public string DisplayValue { get { return getDisplayValue(); } }

        public SecurityContext() {
        }

        public SecurityContext(Role _role, Organization _organization, CollaborationSpace _collabSpace)
        {
            role         = _role;
            organization = _organization;
            collabspace  = _collabSpace;
        }

        public CollaborationSpace collabspace { get; set; }
        public Organization organization { get; set; }
        public Role role { get; set; }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", role.name, organization.name, collabspace.name);
        }

        public string getDisplayValue()
        {
            return string.Format("{0} - {1} - {2}", getRoleDisplay(role.name), organization.name, collabspace.name);
        }
    }
}
