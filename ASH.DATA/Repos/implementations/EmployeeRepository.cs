using ASH.DATA.Models;
using ASH.DATA.Repos.interfaces;

namespace ASH.DATA.Repos.implementations
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ASHContext context) : base(context)
        {

        }
    }
}
