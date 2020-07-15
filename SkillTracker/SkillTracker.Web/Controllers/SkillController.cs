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
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        public SkillController(SkillContext skillContext)
        {
            _skillService = new SkillService(skillContext);
        }
        // Save new skill upgarded by full stack engineer
        public IActionResult AllSkills()
        {
            try
            {
                var result = _skillService.GetAllSkills();
                if (result != null)
                {
                  return View(result);
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Save new skill upgarded by full stack engineer
        public IActionResult NewSkill()
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

        // Save new skill upgarded by full stack engineer
        [HttpPost]
        public async Task< IActionResult> NewSkill(Skill skill)
        {
            try
            {
                var result = await _skillService.AddNewSkill(skill);
                if(result == "New Skill Added")
                {
                    ViewBag.result = result;
                    return RedirectToAction("AllSkills");
                }
                else
                {
                    ViewBag.result = "New Skill Not Added";
                }
               return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // update skill upgarded by full stack engineer
        [HttpGet]
        [Route("/skill/update")]
        public IActionResult ReviseSkill()
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

        // update skill upgarded by full stack engineer
        [HttpPost]
        [Route("/skill/update")]
        public async Task<IActionResult> ReviseSkill(Skill skill)
        {
            try
            {
                var result = await _skillService.EditSkill(skill);
                if (result == 1)
                {
                    return RedirectToAction("AllSkills");
                }
                else
                {
                    return RedirectToAction("AllSkills");
                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // delete skill of full stack engineer
        [HttpGet]
        [Route("/skill/delete")]
        public IActionResult DestroySkill()
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

        // delete skill of full stack engineer
        [HttpPost]
        [Route("/skill/delete")]
        public async Task<IActionResult> DestroySkill(String skillname)
        {
            try
            {
                var result = await _skillService.DeleteSkill(skillname);
                if (result == 1)
                {
                    return RedirectToAction("AllSkills");
                    return View();
                }
                else
                {
                    return RedirectToAction("AllSkills");
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
            return View();
        }
    }
}