namespace Ficha_10.Models
{
    public class Employees : IEmployees
    {
        private List<Employee> employeesL;
        List<Employee> IEmployees.EmployeesL
        { 
            get => employeesL; 
            set => employeesL = value; 
        
        }

        public Employees()
        {
            employeesL = JsonLoader.LoadEmployeesJsonFiles();
        }
    }
}
