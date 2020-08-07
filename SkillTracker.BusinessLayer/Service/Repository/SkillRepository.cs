using Microsoft.EntityFrameworkCore;
using SkillTracker.DataLayer;
using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.BusinessLayer.Service.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ISkillConnection _skillConnection;

        public SkillRepository(SkillContext skillContext)
        {
            _skillConnection = new SkillConnection(skillContext);
        }

        // Save new skill upgarded by full stack engineer into database
        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            try
            {
                String message = string.Empty;
                var context = _skillConnection.GetSkillContext;

                var lstSkills = context.Skills;

                return lstSkills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Save new skill upgarded by full stack engineer into database
        public async Task<string> AddNewSkill(Skill skill)
        {
            try
            {
                String message = string.Empty;
                var context = _skillConnection.GetSkillContext;

                var lstSkills = context.Skills;
                var result = lstSkills.Add(skill);
                if (result.State == EntityState.Added)
                {
                    message = "New Skill Added";
                    await context.SaveChangesAsync();
                }

                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // delete skill of full stack engineer from database
        public async Task<int> DeleteSkill(string skillname)
        {
            try
            {
                int count = 0;
                var context = _skillConnection.GetSkillContext;

                var lstSkills = context.Skills;
                var result = await lstSkills.SingleOrDefaultAsync(skl => skl.SkillName == skillname);
                var removeResult = lstSkills.Remove(result);
                if (removeResult.State == EntityState.Deleted)
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
        // update skill upgarded by full stack engineer from database
        public async Task<int> EditSkill(Skill skill)
        {
            try
            {
                int count = 0;
                var context = _skillConnection.GetSkillContext;

                var lstSkills = context.Skills;
                var result = await lstSkills.SingleOrDefaultAsync(skl => skl.SkillName == skill.SkillName);
                result.Remark = skill.Remark;
                result.SkillCategory = skill.SkillCategory;
                result.SkillLevel = skill.SkillLevel;
                result.SkillName = skill.SkillName;
                result.SkillType = skill.SkillType;
                result.SkillTotalExperiance = skill.SkillTotalExperiance;
                var editResult = lstSkills.Update(result);
                if (editResult.State == EntityState.Modified)
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
    }
}
