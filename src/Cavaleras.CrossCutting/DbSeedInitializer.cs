using Calaveras.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.CrossCutting
{
    public static class DbSeedInitializer
    {
        
        public static void CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            List<string> roles = new List<string>()
            {
                "Gerente",
                "Garçom", 
                "Motoboy",
                "Cliente",
                "Administrador",
            };

            foreach(string role in roles)
            {
                if (roleManager.FindByNameAsync(role).Result == null)
                {
                    roleManager.CreateAsync(new IdentityRole { Name = role, NormalizedName = role }).Wait();
                }
            }
        }

        public static void CreateAdmin(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("administrador@cavalerasplace.com.br").Result == null)
            {
                User admin = new User()
                { 
                    Email = "administrador@cavalerasplace.com.br",
                    NormalizedEmail = "administrador@cavalerasplace.com.br",
                    EmailConfirmed = true,
                    name = "Administrador",
                    PhoneNumber = "13996540909",
                    PhoneNumberConfirmed = true,
                    UserName = "administrador@cavalerasplace.com.br", 
                    cpf = "44560744858", 
                };

                userManager.CreateAsync(admin, "cavspls@321").Wait();
                userManager.AddToRoleAsync(admin, "Administrador").Wait();
            }
        }
    }
}
