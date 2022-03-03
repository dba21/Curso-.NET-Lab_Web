using Ficha_10.Models;
using System.Text.Json;

namespace Ficha_10
{
    public class JsonLoader
    {

        public static Employees LoadEmploeesJson()
        {
            var jsonData = File.ReadAllText("./JsonFiles/employees.json");
            Employees? es = JsonSerializer.Deserialize<Employees>(jsonData);
            return es;

            string json = JsonSerializer.Serialize<Employees>(es);
            File.WriteAllText("./JsonFiles/employees.json", json);

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
