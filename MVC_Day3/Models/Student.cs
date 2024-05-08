using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC_Day3.CustomValidationRoles;

namespace MVC_Day3.Models
{
    public class Student
    {
        public int Id { get; set; }
        

        //[Display(Name = "Full Name")]
        ////validationsof required and effect (database
        [Required]
        //MaxLength,minLenghth
        [StringLength(20,MinimumLength =3)]
        public string Name { get; set; }
        [Range(20,30)]
        //servier site
        [DividedByTwoValidation(4,ErrorMessage ="Age must be divided by two ")]
        public int Age { get; set; }

        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        public String Email { get; set; }

        
        //public String Password { get; set; }
        //[Compare("Password")]
        //[NotMapped]
        //public String CPassword { get; set; }

        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
