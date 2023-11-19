using ASH.COMMON.Models;

namespace ASH.DATA.Models
{
    public partial class Employee : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public decimal? PayPerHour { get; set; }
        public decimal? AnnualSalary { get; set; }
        public decimal? MaxExpenseAmount { get; set; }
        public int EmployeeTypeId { get; set; }
        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual EmployeeType EmployeeType { get; set; } = null!;
        public virtual User? ModifiedByNavigation { get; set; }
    }
}
