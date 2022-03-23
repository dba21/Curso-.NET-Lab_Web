using Ficha_10.Models;
using System.Text.Json;

namespace Ficha_10
{
    public class JsonLoader
    {
        public static List<Employee> LoadEmployeesJsonFiles()
        {
            string jsonData = System.IO.File.ReadAllText("./JsonFiles/employees.json");
            return JsonSerializer.Deserialize<List<Employee>>(jsonData);

        }

        public static List<Character> LoadCharactersJsonFiles()
        {
            string jsonC = System.IO.File.ReadAllText("./JsonFiles/characters.json");
            return JsonSerializer.Deserialize<List<Character>>(jsonC);
            
        }
    }
}
