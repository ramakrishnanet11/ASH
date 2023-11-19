using ASH.COMMON.Models;

namespace ASH.DATA.Services.interfaces
{
    public interface IEmployeeService
    {
        CommonResponse<List<Employee>> Get();
        CommonResponse<Employee> Get(int id);
        CommonResponse<Employee> Save(Employee request, int userId);
        CommonResponse<Employee> Delete(int id);
        
    }
}
