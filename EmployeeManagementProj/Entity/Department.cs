using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEntity
{
    public class Department
    {
        /// <summary>
        /// Department Number. Cannot start with Zero
        /// </summary>
        [Key]
   //     [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptID { get; set; }


        /// <summary>
        /// Department Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DeptName { get; set; }
    }
}