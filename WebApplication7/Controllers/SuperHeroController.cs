using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;

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
        private readonly DataContext _dataContext;

        public SuperHeroController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);


            if (hero == null)
            {
                return BadRequest("hero not found");
            }
            return Ok(hero);

        }



        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpPatch]
        public async Task<ActionResult<List<SuperHero>>> updateHero(SuperHero request)
        {
            var dbHero = await _dataContext.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
            {
                return BadRequest("hero not found");
            }
            dbHero.Name = request.Name;
            dbHero.Place = request.Place;
           await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> deleteHero(int id)
        {
            var dbHero = await _dataContext.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("hero not found");
            }
            _dataContext.SuperHeroes.Remove(dbHero); 
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

    }

}

