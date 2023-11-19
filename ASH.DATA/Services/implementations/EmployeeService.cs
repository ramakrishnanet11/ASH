using ASH.COMMON.Models;
using ASH.DATA.Repos.interfaces;
using ASH.DATA.Services.interfaces;

namespace ASH.DATA.implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public CommonResponse<List<Employee>> Get()
        {
            CommonResponse<List<Employee>> result = new CommonResponse<List<Employee>>();
            try
            {
                result.Data = _employeeRepository.Get().Select(x => Map(x)).ToList();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }
        public CommonResponse<Employee> Get(int id)
        {
            CommonResponse<Employee> result = new CommonResponse<Employee>();
            try
            {
                var employee = _employeeRepository.Get(id);
                if (employee != null)
                {
                    result.Data = Map(employee);
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }
        public CommonResponse<Employee> Save(Employee request, int userId)
        {
            CommonResponse<Employee> result = new CommonResponse<Employee>();
            try
            {
                var employee = _employeeRepository.Save(Map(request), userId);
                result.Data = Map(employee);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }
        public CommonResponse<Employee> Delete(int id)
        {
            CommonResponse<Employee> result = new CommonResponse<Employee>();
            try
            {
                var employee = _employeeRepository.Delete(id);
                result.Data = Map(employee);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;

            }
            return result;
        }

        private Employee Map(ASH.DATA.Models.Employee x)
        {
            return new Employee()
            {
                Id = x.Id,
                Address1 = x.Address1,
                AnnualSalary = x.AnnualSalary,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MaxExpenseAmount = x.MaxExpenseAmount,
                PayPerHour = x.PayPerHour,
                Type = x.EmployeeType?.Title
            };
        }

        private ASH.DATA.Models.Employee Map(Employee x)
        {
            var entity = new ASH.DATA.Models.Employee()
            {
                Id = x.Id,
                Address1 = x.Address1,
                AnnualSalary = x.AnnualSalary,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MaxExpenseAmount = x.MaxExpenseAmount,
                PayPerHour = x.PayPerHour,
                EmployeeTypeId = x.EmployeeTypeId
            };
            return entity;
        }

    }
}
