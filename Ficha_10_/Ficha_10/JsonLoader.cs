using Ficha_10.Models;
using System.Text.Json;

namespace Ficha_10
{
    public class JsonLoader
    {

        public static List<Employee>? LoadEmployeesJson()
        {
            var jsonData = System.IO.File.ReadAllText("./JsonFiles/employees.json");
            return JsonSerializer.Deserialize<List<Employee>>(jsonData);


        }

        public static Characters LoadCharactersJson()
        {
            var jsonC = File.ReadAllText("./JsonFiles/characters.json");
            Characters? cs = JsonSerializer.Deserialize<Characters>(jsonC);
            return cs;

            string json = JsonSerializer.Serialize<Characters>(cs);
            File.WriteAllText("./JsonFiles/characters.json", json);
        }
    }
}
