using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ficha_10.Models;
using System.Text.Json;
using System.Net.Mime;

namespace Ficha_10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : Controller
    {
        private readonly Characters characters;

        public CharactersController()
        {
            characters = JsonLoader.LoadCharactersJson();
        }

        // GET: CharactersController
        [HttpGet]
        public  IEnumerable<Character> Get()
        {
            return characters.CharactersL;
        }

        
        // POST api/<ValuesController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody] Character c)
        {
            if (characters.CharactersL.Count == 0)
            {
                c.Id = 1;
                characters.CharactersL.Add(c);
            }
            else
            {
                var personagem = characters.CharactersL[characters.CharactersL.Count - 1];
                c.Id = personagem.Id + 1;
                characters.CharactersL.Add(c);
            }
            return Created("./JsonFiles/characters.json", c);
        }
        

        // GET: CharactersController/Delete/5
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            int removed = characters.CharactersL.RemoveAll(e => e.Id == id);
            if (removed == 0)
            {
                return NotFound(string.Format("Id: {0} not found.", id));
            }
            else
            {
                return Ok(String.Format("Employee with ID: {0} was deleted.", id));
            }
        }

        // GET: CharactersController/Details/5
        [HttpGet("{I:int}", Name = "GetByI")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetI(int I)
        {
            Character? c = characters.CharactersL.Find(p => p.Id == I);
            if (c == null)
            {
                return NotFound($"Id: {I} not Found.");
            }
            else
            {
                return Ok(c);
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Put(int id, [FromBody] Character charact)
        {
            var c = characters.CharactersL.Find(p => p.Id == id);
            if (c == null)
            {
                return NotFound(String.Format("Id: {0} not found!", id));
            }
            else
            {
                c.Id = charact.Id;
                c.Name = charact.Name;
                c.Gender = charact.Gender;
                c.Homeworld = charact.Homeworld;
                c.Born = charact.Born;
                c.Jedi = charact.Jedi; 
                return Ok(c);
            }
        }

        //Get Gender
        [HttpGet("gender/{gender}", Name = "GetByGender")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByGender(string gender)
        {
            List<Character>? chG = characters.CharactersL.FindAll(c => c.Gender == gender);
            if (chG.Count == 0)
            {
                return NotFound(String.Format("Gender: {0} not found.", gender));
            }
            else
            {
                return Ok(chG);
            }
        }


        //Get Jedi
        [HttpGet("jedi", Name = "GetByJedi")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByJedi()
        {
            List<Character>? c = characters.CharactersL.FindAll(p => p.Jedi == true);
            if (c.Count == 0)
            {
                return NotFound(String.Format("Jedi: not found."));
            }
            else
            {
                return Ok(c);
            }
        }


        //Download
        [HttpGet("download", Name = "GetDownload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDownload()
        {
            string jsonCha = JsonSerializer.Serialize<Characters>(characters);
            //namespace.class.function
            System.IO.File.WriteAllText("./JsonFiles/characters.json", jsonCha);

            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes("./JsonFiles/characters.json");
                return File(bytes, "aolication/json", "./JsonFiles/characters.json");

            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
