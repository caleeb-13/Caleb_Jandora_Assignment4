using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebFormsIdentity
{
    public partial class Register : System.Web.UI.Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = UserName.Text }; // UserName is the name of the TextBox
            IdentityResult result = manager.Create(user, Password.Text); // Password is the name of the TextBox

            if (result.Succeeded) // if succeeded, make the message below
            {
                StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
            }
            else // if it doesnt work, make the message below
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}