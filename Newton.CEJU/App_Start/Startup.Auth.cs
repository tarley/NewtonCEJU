using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Newton.CJU.DAL;
using Newton.CJU.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Newton.CJU
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void Configure(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private static void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(CJUContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Autenticacao/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, Usuario>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesAndUsers()
        {
            CJUContext context = CJUContext.Create();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Usuario>(new UserStore<Usuario>(context));
            
            if (!roleManager.RoleExists("Monitor"))
            {
                var role = new IdentityRole();
                role.Name = "Monitor";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Professor"))
            {
                var role = new IdentityRole();
                role.Name = "Professor";
                roleManager.Create(role);

                var user = new Usuario();
                user.Nome = "Valéria";
                user.UserName = "valeria@newtonpaiva.com";
                user.Email = "valeria@newtonpaiva.com";

                string userPWD = "ceju2016";

                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Professor");
                }
            }
        }
    }
}