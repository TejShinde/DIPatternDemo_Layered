using DIPatternDemo_Layered .Models;
using DIPatternDemo_Layered .Repositories;
using DIPatternDemo_Layered .Data;

namespace DIPatternDemo_Layered .Repositories
    {
    public class EmployeeRepository : IEmployeeRepository

        {
        private readonly ApplicationDBContext db;
        public EmployeeRepository ( ApplicationDBContext db ) // added dependency
            {
            this .db = db;
            }
        public int AddEmployee ( Employee employee )
            {
            int result = 0;
            db .Employees?.Add(employee);
            result = db .SaveChanges();
            return result;
            }

        public int DeleteEmployee ( int id )
            {
            int result = 0;
            var emp = db .Employees?.Where(x => x .EmpId == id) .SingleOrDefault();
            if ( emp != null )
                {
                db .Employees?.Remove(emp);
                result = db .SaveChanges();
                }
            return result;
            }

        public Employee GetEmployeeById ( int id )
            {
            return db .Employees?.Where(x => x .EmpId == id) .SingleOrDefault();
            }

        public IEnumerable<Employee> GetEmployees ()
            {
            return db .Employees .ToList();
            }

        public int UpdateEmployee ( Employee employee )
            {
            int result = 0;
            var emp = db .Employees?.Where(x => x .EmpId == employee .EmpId) .SingleOrDefault();
            if ( emp != null )
                {
                emp .Name = employee .Name;
                emp .Email = employee .Email;
                emp .Salary = employee .Salary;
                result = db .SaveChanges();
                }
            return result;

            }
        }
    }
