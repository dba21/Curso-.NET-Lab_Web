using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ficha_10.Models;
using System.Text.Json;
using System.Net.Mime;

namespace Ficha_10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class CharactersController : ControllerBase
    {
        private readonly ICharacters characters;

        public CharactersController(ICharacters characters)
        {
            this.characters = characters;
        }

        // GET: CharactersController
        [HttpGet]
        public  IEnumerable<Character> Get()
        {
            return characters.CharactersL;
        }

        
        // POST api/<ValuesController>
        [HttpPost(Name = "PostCharacter")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody] Character character)
        {
            if (character != null)
            {
                characters.CharactersL.Add(character);
                return CreatedAtRoute("GetById", new {id = character.Id }, character);
            }
            else
            {
                return BadRequest(); 
            }
        }
        

        // GET: CharactersController/Delete/5
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            return Ok();
            /*
            int removed = characters.CharactersL.RemoveAll(e => e.Id == id);
            if (removed == 0)
            {
                return NotFound(string.Format("Id: {0} not found.", id));
            }
            else
            {
                return Ok(String.Format("Employee with ID: {0} was deleted.", id));
            }*/
        }

        // GET: CharactersController/Details/5
        [HttpGet("{id}", Name = "GetByI")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetI(int id)
        {
            Character? c = characters.CharactersL.Find(p => p.Id == id);
            if (c == null)
            {
                return NotFound($"Id: {id} not Found.");
            }
            else
            {
                return Ok(c);
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Put(int id, [FromBody] Character character)
        {
            var c = characters.CharactersL.Find(p => p.Id == id);
            if (c == null)
            {
                return NotFound(String.Format("Id: {0} not found!", id));
            }
            else
            {
                c.Id = character.Id;
                c.Name = character.Name;
                c.Gender = character.Gender;
                c.Homeworld = character.Homeworld;
                c.Born = character.Born;
                c.Jedi = character.Jedi; 
                return Ok(c);
            }
        }

        //Get Gender
        [HttpGet("gender/{gender}", Name = "GetByGender")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByGender(string gender)
        {
            Character? chG = characters.CharactersL.Find(c => c.Gender == gender);
            if (chG == null)
            {
                return NotFound($"Gender: {gender} not found.");
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
        public IActionResult GetByJedi(bool jedi)
        {
            Character? c = characters.CharactersL.Find(p => p.Jedi == true);
            if (c == null)
            {
                return NotFound($"Jedi: {jedi} not found.");
            }
            else
            {
                return Ok(c);
            }
        }


        //Download
        [HttpGet("download", Name = "GetDownload")]
        public IActionResult GetDownload()
        {
            //Save the current employee list to a file
            string jsonCha = JsonSerializer.Serialize<ICharacters>(characters);
            //namespace.class.function
            System.IO.File.WriteAllText("./JsonFiles/characters.json", jsonCha);

            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes("./JsonFiles/characters.json");
                return File(bytes, "application/json", "characters.json");

            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
