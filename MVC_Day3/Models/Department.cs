using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Day3.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote("CheckDeptId", "Department")]

        public int DeptId { get; set; }
        [Remote("CheckDeptName", "Department")]

        public string DeptName { get; set; }
        //public bool Status { get; set; } = true;

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    }
}
