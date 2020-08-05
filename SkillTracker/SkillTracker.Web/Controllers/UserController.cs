using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.DataLayer;
using SkillTracker.Entities;

namespace SkillTracker.Web.Controllers
{
    
    public class UserController : Controller
    {
        /// <summary>
        /// Inject userservice object
        /// </summary>
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Get : Create new user
        /// </summary>
        /// <returns></returns>
        [Route("User/NewUser")]
        
        public IActionResult NewUser()
        {
            //business logic goes here
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Post : Create new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route("User/NewUser")]
        public async Task< IActionResult> NewUser(User user)
        {
            //business logic goes here
            try
            {
               var result =await  _userService.CreateNewUser(user);
                ViewBag.message = result;
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Get : Update User details
        /// </summary>
        /// <returns></returns>
        
        [Route("User/ReviseUser")]
        public IActionResult ReviseUser()
        {
            //business logic goes here
            try
            {
                return View("ReviseUser");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Put : update user details
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route("User/ReviseUser")]
        public async Task<IActionResult> ReviseUser(User user)
        {
            //business logic goes here
            try
            {
                var result =await _userService.UpdateUser(user);
                if(result == 1)
                {
                    return RedirectToAction("allusers","user");
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Get : delete user details
        /// </summary>
        /// <returns></returns>
     
        [Route("User/DestroyUser")]
        public IActionResult DestroyUser()
        {
            //business logic goes here
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete : delete user details
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        [Route("User/DestroyUser")]
        [HttpPost]

        public async Task<IActionResult> DestroyUser(String FirstName, String LastName)
        {
            //business logic goes here
            try
            {
                var result = await _userService.RemoveUser(FirstName, LastName);
                if (result == 1)
                {
                    return   RedirectToAction("allusers", "user");
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Show list of all users with pagination
        /// </summary>
        /// <returns></returns>
        
        [Route("User/allusers")]
        public async Task<IActionResult> AllUsers()
        {
            //business logic goes here
            try
            {
                var allusers = await _userService.GetAllUsers();
                return View(allusers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Get : Search user by it's first name
        /// </summary>
        /// <returns></returns>
        
        public IActionResult SearchUser()
        {
            //business logic goes here
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Post : Search user by it's first name
        /// </summary>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<IActionResult> InspectUserByFirstName(String FirstName)
        {
            //business logic goes here
            try
            {
                var user = await _userService.SearchUserByFirstName(FirstName);
                if (user != null)
                {
                    return View("SearchUser", user);
                }
                return View("SearchUser");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Post : Search user by it's email
        /// </summary>
        /// <returns></returns>
       
        [HttpPost]
        public async Task<IActionResult> InspectUserByEmail(String email)
        {
            //business logic goes here
            try
            {
                var user = await _userService.SearchUserByEmail(email);
                if (user != null)
                {
                    return View("SearchUser", user);
                }
                return View("SearchUser");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Post : Search user by it's mobile number
        /// </summary>
        /// <returns></returns>
        
        [HttpPost]
        public async Task<IActionResult> InspectUserByMobile(long mobilenumber)
        {
            //business logic goes here
            try
            {
                var user = await _userService.SearchUserByMobile(mobilenumber);
                if (user != null)
                {
                    return View("SearchUser", user);
                }
                return View("SearchUser");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Post : Search user by it's skill range between start value and end value
        /// </summary>
        /// <param name="startvalue"></param>
        /// <param name="endvalue"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> InspectUserBySkillRange(int startvalue,int endvalue)
        {
            //business logic goes here
            try
            {
                var user = await _userService.SearchUserBySkillRange(startvalue, endvalue);
                if (user != null)
                {
                    return View("SearchUser", user);
                }
                return View("SearchUser");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Error()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}