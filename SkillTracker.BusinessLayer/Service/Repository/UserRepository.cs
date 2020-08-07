using Microsoft.EntityFrameworkCore;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private IUserConnection _userConnection;

        public UserRepository(UserContext userContext)
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
                message = await ValidateUserFirstName(user);
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
                if (result != null)
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
                var updateuser = await LstUsers.SingleOrDefaultAsync(usr => usr.FirstName == user.FirstName);
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
        //return list of all users with pagination
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                IEnumerable<User> users;
                var context = _userConnection.GetUserContext;

                users = context.Users;


                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Search user by it's email
        public async Task<User> SearchUserByEmail(string Email)
        {
            User user = null;
            try
            {

                var context = _userConnection.GetUserContext;

                var LstUsers = context.Users;
                user = await LstUsers.SingleOrDefaultAsync(usr => usr.Email == Email);


                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Search user by it's first name
        public async Task<User> SearchUserByFirstName(string firstname)
        {
            User user = null;
            try
            {

                var context = _userConnection.GetUserContext;

                var LstUsers = context.Users;
                user = await LstUsers.SingleOrDefaultAsync(usr => usr.FirstName == firstname);

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Search user by it's mobile number
        public async Task<User> SearchUserByMobile(long mobilenumber)
        {
            User user = null;
            try
            {

                var context = _userConnection.GetUserContext;

                var LstUsers = context.Users;
                user = await LstUsers.SingleOrDefaultAsync(usr => usr.Mobile == mobilenumber);


                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Search user by it's skill range between start value and end value
        public async Task<User> SearchUserBySkillRange(int startvalue,int endvalue)
        {
            User user = null;
            try
            {

                var context = _userConnection.GetUserContext;
                var LstUsers = context.Users;
                user = await LstUsers.SingleOrDefaultAsync(usr => usr.MapSkills == startvalue || usr.MapSkills<=endvalue);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
