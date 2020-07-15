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
    public class AdminService : IAdminService
    {
        private IUserConnection _userConnection;
        public AdminService(UserContext context)
        {
            _userConnection = new UserConnection(context);
        }
        //return list of all users with pagination
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                IEnumerable<User> users;
                var context = _userConnection.GetUserContext;
           
                 users =context.Users;

               
                return users ;
            }
            catch(Exception ex)
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
            catch(Exception ex)
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
        public async Task<User> SearchUserBySkillRange(int startvalue)
        {
            User user = null;
            try
            {

                    var context = _userConnection.GetUserContext;
                  var LstUsers = context.Users;
                  user = await LstUsers.SingleOrDefaultAsync(usr => usr.MapSkills ==startvalue );
                   return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
