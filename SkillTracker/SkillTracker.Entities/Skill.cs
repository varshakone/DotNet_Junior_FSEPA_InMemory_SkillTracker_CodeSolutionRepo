using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillTracker.Entities
{
  public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        [Required]
        public String SkillName { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public SkillType SkillType { get; set; }
        public String Remark { get; set; }
        public int SkillTotalExperiance { get; set; }
    }
}
