using Future3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Future3.Controllers
{
    [ApiController]
    public class CharactersController
    {
        private const string Route = "api/characters";

        private DataContext _dataContext;

        public CharactersController()
        {
            _dataContext = new DataContext();
        }

        // api/characters
        // api/characters?rpg=DungeonsAndDragons
        [HttpGet(Route)]
        //ActionResult -> dzięki temu możemy zwrócić czy akcja się udała (np. HttpStatus200) czy nie udała (np. HttpStatus400)
        //List<Character> -> zwracamy listę postaci
        //FromQuery -> Przekazujemy argument do funkcji za pomocą query (po '?' (?rpg=DungeonsAndDragons))
        //Rpg? rpg -> tutaj, znak zapytania jest, ponieważ chcemy mieć możliwość nie podawania argumentu (wówczas rpg jest ustawiane jako null)
        public ActionResult<List<Character>> Get([FromQuery] Rpg? rpg)
        {
            var characters = _dataContext.Characters;

            if (rpg != null)
            {
                characters = characters
                    //Where -> weź nasze postaci, które spełniają warunek
                    //character => character.Rpg == rpg -> dla każdego obiektu listy (nazwij go character), sprawdź czy jego rpg (character.Rpg) jest równe naszemu argumentowi (rpg)
                    .Where(character => character.Rpg == rpg)
                    //Zwróć nam listę
                    .ToList();
            }

            //Stwórz OkObjectResult (żeby użytkownik miał pewność, że wszystko się udało) i zwróć w nim listę postaci
            return new OkObjectResult(characters);
        }

        // api/characters/id
        [HttpGet(Route + "/{id}")]
        //FromRoute -> Przekazujemy argument do funkcji za pomocą route (po '/' (/1))
        public ActionResult<Character> GetById([FromRoute] int id)
        {
            var character = _dataContext.Characters
                //Single -> Weź tylko jedną postać (spodziewamy się, że w liście będzie dokładnie jedna taka postać), która spełnia warunek
                //OrDefault -> jeśli nie będzie takiej postaci, zwróć null
                //x => x.Id == id -> dla każdego obiektu list (nazwij go x), sprawdź czy jego id (x.id) jest równe naszemu argumentowi (id)
                .SingleOrDefault(x => x.Id == id);

            if (character == null)
            {
                //Zwróć informację, że się nie udało (BadRequest)
                return new BadRequestResult();
            }

            //Stwórz OkObjectResult (żeby użytkownik miał pewność, że wszystko się udało) i zwróć w nim postać
            return new OkObjectResult(character);
        }
    }
}
