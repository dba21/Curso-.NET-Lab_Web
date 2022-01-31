namespace Ficha_7
{
    public class Employees
    {

        //criar construtor por omição, para chamar da class object
        public Employees()
        {
            EmployeesList = new List<Employee>();

            //StringList = new List<string>();

            //IntList = new List<int>();
        }

        //propriedade
        public List<Employee> EmployeesList { get; set;}
       // public List<string> StringList { get; set; }
        //public List<int> IntList { get; set; }  

    }
}
