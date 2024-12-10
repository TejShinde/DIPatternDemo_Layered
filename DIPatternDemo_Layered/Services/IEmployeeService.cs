using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Services
    {
    public interface IEmployeeService
        {
        IEnumerable<Employee> GetEmployees ();
        Employee GetEmployeeById ( int id );
        int AddEmployee(Employee employee );
        int UpdateEmployee (Employee employee );
        int DeleteEmployee(int id );
        }
    }
