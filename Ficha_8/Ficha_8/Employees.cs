namespace Ficha_8
{
    public class Employees
    {

        //criar construtor por omição, para chamar da class object
        public Employees()
        {
            EmployeesList = new List<Employee>();

        }

        //propriedade
        public List<Employee> EmployeesList { get; set;}

    }
}
