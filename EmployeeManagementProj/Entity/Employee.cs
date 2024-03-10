using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class Employee
    {
        /// <summary>
        /// Employee Number. Cannot start with Zero
        /// </summary>
        [Key]
        [StringLength(6)]
       
        public string EmpID { get; set; }

        /// <summary>
        /// Employee's First Name. E.g. Bill in Bill Gates
        /// </summary>

        [Required]
        [StringLength(25)]
        public string EmpFirstName { get; set; }

        /// <summary>
        /// Employee's Last Name. E.g. Gates in Bill Gates
        /// </summary>

        [StringLength(25)]
        public string EmpLastName { get; set; }


        /// <summary>
        /// Any valid date. Business rule is that the employee must be minimum 18 yrs old when they join the organization and their age cant exceed 58 years
        /// </summary>

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime EmpDateOfBirth { get; set; }

        /// <summary>
        /// Any valid date. Must be greater than Date of Birth
        /// </summary>

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }

        /// <summary>
        /// ForeignKey of Department table
        /// </summary>

        [Required]
        [ForeignKey("Department")]
        public int EmpDeptID { get; set; }


        /// <summary>
        /// M1, M2, M3…M7 are the grades and related to Grade table
        /// </summary>
        [Required]
        [StringLength(2)]
        [ForeignKey("Grade_Master")]
        public string EmpGrade { get; set; }

        [StringLength(50)]
        public string EmpDesignation { get; set; }

        [Required]
        public int EmpBasic { get; set; }

        /// <summary>
        /// Single Character to determine its M or F
        /// </summary>

        [Required]
        [StringLength(1)]
        public string EmpGender { get; set; }

        /// <summary>
        ///  Single Character
        /// </summary>

        [Required]
        [StringLength(1)]
        public string EmpMaritalStatus { get; set; }


        [StringLength(100)]
        public string EmpHomeAddress { get; set; }


        [StringLength(15)]
        public string EmpContactNum { get; set; }

    }
    
}