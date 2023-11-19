using ASH.COMMON.Models;

namespace ASH.DATA.Models
{
    public partial class EmployeeType : BaseEntity
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public virtual User? ModifiedByNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
