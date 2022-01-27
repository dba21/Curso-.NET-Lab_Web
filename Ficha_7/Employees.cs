namespace Ficha_7
{
    public class Employees
    {

        //criar construtor por omição, para chamar da class object
        public Employees()
        {
            EmployeesList = new List<Employee>();
        }


        public List<Employee> EmployeesList { get; set;}
    }
}
