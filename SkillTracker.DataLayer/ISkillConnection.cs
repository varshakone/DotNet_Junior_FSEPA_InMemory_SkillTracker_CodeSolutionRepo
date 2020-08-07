using SkillTracker.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillTracker.DataLayer
{
   public interface ISkillConnection
    {
   SkillContext GetSkillContext { get; }
    }
}
