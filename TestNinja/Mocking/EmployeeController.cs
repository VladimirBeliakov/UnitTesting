using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeContext _db;

        public EmployeeController()
        {
            _db = EmployeeContextFactory.Create();
        }

        public ActionResult DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }

    public class RedirectResult : ActionResult { }

    public interface IEmployeeContext
    {
        void SaveChanges();
        IDbSet<Employee> Employees { get; set; }
    }

    public class EmployeeContext : IEmployeeContext
    {
        public IDbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }

    public static class EmployeeContextFactory
    {
        private static IEmployeeContext _empContext = null;

        public static IEmployeeContext Create()
        {
            if (_empContext != null)
                return _empContext;
            return new EmployeeContext();
        }

        public static void SetEmployeeContext(IEmployeeContext empContext)
        {
            _empContext = empContext;
        }
    }
}