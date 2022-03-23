namespace Ficha_10.Models
{
    public class Characters : ICharacters
    {
        private List<Character> charactersL;
        List<Character> ICharacters.CharactersL
        {
            get => charactersL;
            set => charactersL = value;
        }
        public Characters()
        {
            charactersL = JsonLoader.LoadCharactersJsonFiles();
        }

    }
}
