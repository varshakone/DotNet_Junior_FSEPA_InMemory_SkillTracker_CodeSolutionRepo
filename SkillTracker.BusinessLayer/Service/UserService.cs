using SkillTracker.BusinessLayer.Interface;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillTracker.BusinessLayer.Service.Repository;

namespace SkillTracker.BusinessLayer.Service
{

    public class UserService : IUserService
    {
        /// <summary>
        /// userrepository type of reference
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Inject UserRepository object
        /// </summary>
        /// <param name="skillRepository"></param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// call repository method to create new user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>New User Registered</returns>
        public async Task<string> CreateNewUser(User user)
        {
            //Business Logic goes here
            try
            {
                var message = await _userRepository.CreateNewUser(user);

                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// call repository method to retrieve all users
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.GetAllUsers();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// call repository method to delete user from db
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>delete count</returns>
        public async Task<int> RemoveUser(string firstname, string lastname)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.RemoveUser(firstname,lastname);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// call repository method to search user by email id into db
        /// </summary>
        /// <param name="Email"></param>
        /// <returns>User details</returns>
        public async Task<User> SearchUserByEmail(string Email)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.SearchUserByEmail(Email);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// call repository method to search user by firstname into db
        /// </summary>
        /// <param name="firstname"></param>
        /// <returns>User details</returns>
        public async Task<User> SearchUserByFirstName(string firstname)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.SearchUserByFirstName(firstname);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// call repository method filtered by mobile number into db
        /// </summary>
        /// <param name="mobilenumber"></param>
        /// <returns>User details</returns>
        public async Task<User> SearchUserByMobile(long mobilenumber)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.SearchUserByMobile(mobilenumber);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// call repository method to search user by it's skill range
        /// </summary>
        /// <param name="startvalue"></param>
        /// <returns>User details</returns>
        public async Task<User> SearchUserBySkillRange(int startvalue,int endvalue)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.SearchUserBySkillRange(startvalue,endvalue);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// call repository method to update user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>update count 1</returns>
        public async Task<int> UpdateUser(User user)
        {
            //Business Logic goes here
            try
            {
                var result = await _userRepository.UpdateUser(user);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
