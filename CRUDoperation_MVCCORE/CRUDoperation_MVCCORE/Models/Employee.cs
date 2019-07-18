using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDoperation_MVCCORE.Models
{
    public class Employee : IValidatableObject
    {
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name ="Employee Name")]
        [Required(ErrorMessage ="Employee Name Required")]
        public string EmployeeName { get; set; }

        [Display(Name ="Email ID")]
        [Required(ErrorMessage = "Email ID Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string EmailId { get; set; }

        [Display(Name = "Date Of Joining")]
        [DataType(DataType.Date,ErrorMessage ="Invalid Date")]
        public DateTime DateOfJoining { get; set; }

        [Display(Name = "Blog URl")]
        [DataType(DataType.Url, ErrorMessage = "Invalid URL")]
        public string Blog { get; set; }

        public bool Married { get; set; }

        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var emp = (Employee)validationContext.ObjectInstance;

            if (emp.Username == "abc")
            {
                yield return new ValidationResult("Invalid UserName");
            }

            if (emp.Password == "abc")
            {
                yield return new ValidationResult("Invalid Password", new[] { nameof(Password) });
            }
        }
    }
}
