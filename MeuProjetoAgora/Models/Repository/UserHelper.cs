using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
   public interface IUserHelper
    {
        Task<bool> DeleteUserAsync(string username);
        Task<bool> UpdateUserAsync(string currentusername, string newUserName);
        Task CheckRoleAsync(string roleName);
         Task CheckSuperUserAsync();
        Task CreateUserASPAsync(string email, string roleName);
        Task CreateUserASPAsync(string email, string roleName, string password);
    }

    public class UserHelper : IUserHelper
    {

        public ApplicationDbContext userContext { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public IConfiguration Configuration { get; }

        public UserHelper(ApplicationDbContext contexto, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            userContext = contexto;
            UserManager = userManager;
            RoleManager = roleManager;
            Configuration = configuration;
        }

        public async Task<bool> DeleteUserAsync(string username)
        {
            
            var userASP = await UserManager.FindByEmailAsync(username);
            if (userASP != null)
            {
                var response = await UserManager.DeleteAsync(userASP);
                return response.Succeeded;
            }

            return false;
        }

        public async Task<bool> UpdateUserAsync(string currentusername, string newUserName)
        {

            var userASP = await UserManager.FindByEmailAsync(currentusername);
            if (userASP != null)
            {
                userASP.UserName = newUserName;
                userASP.Email = newUserName;
                var response = await UserManager.UpdateAsync(userASP);
                return response.Succeeded;
            }

            return false;
        }


        public async Task CheckRoleAsync(string roleName)
        {
            if (! await RoleManager.RoleExistsAsync(roleName))
            {
               await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public async Task CheckSuperUserAsync()
        {
            
            var email = "leandroleanleo@gmail.com";
            var password = "M@nequim1991";
            var userASP = await UserManager.FindByNameAsync(email);
            if (userASP == null)
            {
               await UserManager.CreateAsync(new IdentityUser { UserName = email }, password);
                return;
            }

         await UserManager.AddToRoleAsync(userASP, "SuperAdmin");
        }

        public async Task CreateUserASPAsync(string email, string roleName)
        {            
            var users = UserManager.Users.ToList();
            var user = users.Find(u => u.UserName == email);            
          await  UserManager.AddToRoleAsync(user, roleName);
        }

        public async Task CreateUserASPAsync(string email, string roleName, string password)
        {
            

            var userASP = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

           await UserManager.CreateAsync(userASP);
          await  UserManager.AddToRoleAsync(userASP, roleName);
        }

        

        
    }

}
