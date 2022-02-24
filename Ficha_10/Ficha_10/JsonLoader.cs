using Ficha_10.Models;
using System.Text.Json;

namespace Ficha_10
{
    public class JsonLoader
    {

        public static Employees loadEmploeesJson()
        {
            var jsonData = File.ReadAllText("./JsonFiles/employees.json");
            Employees es = JsonSerializer.Deserialize<Employees>(jsonData);
            return es;

            string json = JsonSerializer.Serialize<Employees>(es);
            File.WriteAllText("./JsonFiles/employees.json", json);

        }



        public static Characters loadCharactersJson()
        {
            string jsonC = File.ReadAllText("characters.json");
            var characters = JsonSerializer.Deserialize<Characters>(jsonC);
            return characters;
        }
    }
}
