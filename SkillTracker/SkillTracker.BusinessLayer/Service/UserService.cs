using SkillTracker.BusinessLayer.Interface;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkillTracker.BusinessLayer.Service
{
    
    public class UserService : IUserService
    {
        private IUserConnection _userConnection;

        public UserService(UserContext userContext)
        {
            _userConnection = new UserConnection(userContext);
        }
        //Save new user into database
        public async Task<string> CreateNewUser(User user)
        {
            try
            {
                string message = String.Empty;
                var context = _userConnection.GetUserContext;
                message =await ValidateUserFirstName(user);
                if (message == "")
                {
                    var users = context.Users;
                    var result = users.Add(user);
                    if (result.State == EntityState.Added)
                    {
                        message = "New User Register";
                        await context.SaveChangesAsync();
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> ValidateUserFirstName(User user)
        {
            try
            {
                string message = String.Empty;
                var context = _userConnection.GetUserContext;

                var users = context.Users;
                var result = await users.SingleOrDefaultAsync(usr => usr.FirstName == user.FirstName);
                if (result !=null)
                {
                    message = "User name not available";
                   
                }

                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //delete user details from database
        public async Task<int> RemoveUser(string firstname, string lastname)
        {
            try
            {
                int count = 0;
                var context = _userConnection.GetUserContext;
               
                    var LstUsers = context.Users;
                    var result = await LstUsers.SingleOrDefaultAsync(usr => usr.FirstName == firstname && usr.LastName == lastname);
                    var UserResult = LstUsers.Remove(result);

                    if (UserResult.State == EntityState.Deleted)
                    {
                        count = 1;
                        await context.SaveChangesAsync();
                    }
              
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //update user details into database
        public async Task<int> UpdateUser(User user)
        {
            try
            {
                int count = 0;
                var LstUsers = _userConnection.GetUserContext.Users;
                var updateuser =await LstUsers.SingleOrDefaultAsync(usr => usr.FirstName == user.FirstName);
                updateuser.Email = user.Email;
                updateuser.Mobile = user.Mobile;
                updateuser.MapSkills = user.MapSkills;

                var UserResult = LstUsers.Update(updateuser);

                if (UserResult.State == EntityState.Modified)
                {
                    count = 1;
                    var context = _userConnection.GetUserContext;
                    await context.SaveChangesAsync();
                }
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
