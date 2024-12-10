using DIPatternDemo_Layered .Models;

namespace DIPatternDemo_Layered .Repositories
    {
    public interface IEmployeeRepository
        {
        IEnumerable<Employee> GetEmployees ();

        Employee GetEmployeeById ( int id );

        int AddEmployee ( Employee employee );

        int UpdateEmployee ( Employee employee );


        int DeleteEmployee ( int id );
        }
    }

