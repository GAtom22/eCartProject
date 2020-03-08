using Microsoft.Owin;
using Owin;
using Entities.Cart;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UI.Cart2.Models;

[assembly: OwinStartupAttribute(typeof(UI.Cart2.Startup))]
namespace UI.Cart2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "Cart2_admin@gmail.com";

                string userPWD = "A@Zs200711";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");

                }
            }


            // creating Creating Cliente role     
            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);

            }
        }
    }
}
