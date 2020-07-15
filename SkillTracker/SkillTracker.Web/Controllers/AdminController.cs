using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.BusinessLayer.Interface;
using SkillTracker.BusinessLayer.Service;
using SkillTracker.DataLayer;
using SkillTracker.Web.Models;

namespace SkillTracker.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(UserContext userContext)
        {
            _adminService = new AdminService(userContext);
        }
        //Show list of all users with pagination
        [Route("/admin/allusers")]
        public async Task< IActionResult> AllUsers()
        {
            try
            {
                var allusers = await _adminService.GetAllUsers();
                return View(allusers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Search user by it's first name
        public IActionResult SearchUser()
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
      
        //Search user by it's first name
        [HttpPost]
        public async Task<IActionResult> InspectUserByFirstName(String FirstName)
        {
            try
            {
                var user = await _adminService.SearchUserByFirstName(FirstName);
                if(user !=null)
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

       

        //Search user by it's email
        [HttpPost]
        public async Task< IActionResult> InspectUserByEmail(String email)
        {
            try
            {
                var user = await  _adminService.SearchUserByEmail(email);
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

       
        //Search user by it's mobile number
        [HttpPost]
        public async Task< IActionResult> InspectUserByMobile(long mobilenumber)
        {
            try
            {
                var user = await _adminService.SearchUserByMobile(mobilenumber);
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

      
        //Search user by it's skill range between start value and end value
        [HttpPost]
        public async  Task<IActionResult> InspectUserBySkillRange(int start)
        {
            try
            {
                var user = await _adminService.SearchUserBySkillRange(start);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
