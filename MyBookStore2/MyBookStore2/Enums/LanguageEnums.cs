using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore2.Enums
{
    public enum LanguageEnums
    {
        [Display(Name = "English Language")]
        English = 10,
        [Display(Name = "Spanish Language")]
        Spanish = 11,
        [Display(Name = "German Language")]
        German = 12,
        [Display(Name = "Italian Language")]
        Italian = 13,
        [Display(Name = "Chinese Language")]
        Chinese = 14
    }
}
