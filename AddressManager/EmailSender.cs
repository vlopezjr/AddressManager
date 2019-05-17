using CPUserControls.CPMail;
using CreateCustomer.API.Entities;
using System.Diagnostics;
using System.Windows.Forms;

namespace AddressManager
{
    internal static class EmailSender
    {
        internal static void EmailNonAuthorizedUser(Address currentAddress)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string userId = userName.Substring(userName.IndexOf(@"\") + 1);

            string summary = $"{userId} has created a new address: {currentAddress.Name}";

            if (Debugger.IsAttached) { MessageBox.Show(summary); return; }

            ServiceSoapClient client = new ServiceSoapClient();
            client.Email("op@caseparts.com", "pams@caseparts.com, valeriem@caseparts.com, dev@caseparts.com", "AddressManager - Non Authorized User", summary, false, "", "");
        }
    }
}
