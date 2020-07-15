using System;
using Microsoft.EntityFrameworkCore;
using SkillTracker.Entities;

namespace SkillTracker.DataLayer
{
    public class SkillContext:DbContext
    {
        public SkillContext(DbContextOptions<SkillContext> options):base(options)
        {

        }
        public DbSet<Skill> Skills { get; set; }
    }
}
