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
        private readonly IUserService _userService;
        public UserController(UserContext userContext)
        {
            _userService = new UserService(userContext);
        }

        [Route("/user/newuser")]
        //Create new user
        public IActionResult NewUser()
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

        //Create new user
        [HttpPost]
        [Route("/user/newuser")]
        public async Task< IActionResult> NewUser(User user)
        {
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

        //update user details
        [Route("/user/update")]
        public IActionResult ReviseUser()
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

        //update user details
        [HttpPost]
        [Route("/user/update")]
        public async Task<IActionResult> ReviseUser(User user)
        {
            try
            {
                var result =await _userService.UpdateUser(user);
                if(result == 1)
                {
                    return RedirectToAction("allusers","admin");
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //delete user details
        [Route("/user/delete")]
        public IActionResult DestroyUser()
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

        //delete user details
        [HttpPost]
        [Route("/user/delete")]
        public async Task<IActionResult> DestroyUser(String FirstName, String LastName)
        {
            try
            {
                var result = await _userService.RemoveUser(FirstName, LastName);
                if (result == 1)
                {
                    return   RedirectToAction("allusers", "admin");
                }
                return View();
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