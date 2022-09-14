using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> hereos = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Batman",
                    Place = "tunisia"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Superman",
                    Place = "usa"
                }
            };



        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(hereos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = hereos.Find(h => h.Id == id);

            
                if(hero == null)
                {
                return BadRequest("hero not found");
                }
                return Ok(hero);    
            
        }



        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            hereos.Add(hero);
            return Ok(hereos);  
        }

    }

}

