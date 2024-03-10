using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class GradeMaster
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [StringLength(2)]
        public string GradeCode { get; set; }

        /// <summary>
        /// For Describing for example - Associates,Executive, Managers etc
        /// </summary>

        [Required]
        [StringLength(10)]
        public string Description { get; set; }

        /// <summary>
        /// Lower Salary band
        /// </summary>
        [Required]
        public int MinSalary { get; set; }

        /// <summary>
        /// Upper Salary Band
        /// </summary>

        [Required]
        public int MaxSalary { get; set; }
    }
}