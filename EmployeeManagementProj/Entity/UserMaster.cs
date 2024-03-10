using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class UserMaster
    {
        /// <summary>
        ///  UserID
        /// </summary>
        [Key]
        [StringLength(6)]
        public string UserID { get; set; }

        /// <summary>
        /// Cannot be less than 8 characters
        /// </summary>

        [Required]
        [MaxLength(15), MinLength(8)]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        /// <summary>
        /// Supervisor or Regular user. Only a supervisor can upload the file. As of now is only admin
        /// </summary>


        [Required]
        [StringLength(2)]
        public string UserType { get; set; }

    }

    
}