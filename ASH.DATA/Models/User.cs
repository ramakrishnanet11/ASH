namespace ASH.DATA.Models
{
    public partial class User
    {
        public User()
        {
            EmployeeCreatedByNavigations = new HashSet<Employee>();
            EmployeeModifiedByNavigations = new HashSet<Employee>();
            EmployeeTypes = new HashSet<EmployeeType>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Employee> EmployeeCreatedByNavigations { get; set; }
        public virtual ICollection<Employee> EmployeeModifiedByNavigations { get; set; }
        public virtual ICollection<EmployeeType> EmployeeTypes { get; set; }
    }
}
