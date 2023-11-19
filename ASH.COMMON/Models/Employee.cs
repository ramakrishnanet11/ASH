using System.ComponentModel.DataAnnotations;

namespace ASH.COMMON.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="First Name Required")]
        [MaxLength(30, ErrorMessage ="Only 30 Chars allowed.")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Last Name Required")]
        [MaxLength(30, ErrorMessage = "Only 50 Chars allowed.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address1 is Required")]
        [MaxLength(30, ErrorMessage = "Only 100 Chars allowed.")]
        public string Address1 { get; set; } = string.Empty;
        public decimal? PayPerHour { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }
        public int EmployeeTypeId { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
