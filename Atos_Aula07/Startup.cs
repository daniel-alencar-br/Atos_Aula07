using Microsoft.Owin;
using Owin;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Atos_Aula07.Models;

[assembly: OwinStartupAttribute(typeof(Atos_Aula07.Startup))]
namespace Atos_Aula07
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CriarRolesUsuarios();
        }

        private void CriarRolesUsuarios()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new
                RoleManager<IdentityRole>(new
                     RoleStore<IdentityRole>(context));
            var userManager = new
                UserManager<ApplicationUser>(new
                        UserStore<ApplicationUser>(context));

            // Criar a Role Admin

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Criar o primeiro Administrador

                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser()
                {
                    Email = "Admin@abc.com",
                    UserName = "Admin@abc.com"
                };
                var incUsuario = manager.Create(user, "P@ssw0rd");

                if (incUsuario.Succeeded)
                {
                    var Resultado =
                        userManager.AddToRole(user.Id, "Admin");
                }



            }

            if (!roleManager.RoleExists("Gerente"))
            {
                var role = new IdentityRole();
                role.Name = "Gerente";
                roleManager.Create(role);

            }
        }
    }
}
