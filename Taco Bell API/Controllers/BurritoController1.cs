using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell_API.Models;

namespace Taco_Bell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController1 : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();//ANY CHANGES TO DB (ADDED/UPDATED) DONT FORGET TO dbContext.SaveChanges().

        [HttpGet]
        public List<Burrito> GetAllBeans()
        {
            return dbContext.Burritos.Where(b => b.Bean == true).ToList();
        }
        [HttpGet("{i}")]
        public Burrito GetByBroke(float i)
        {
            return dbContext.Burritos.First(x => x.Cost < i);
        }
        [HttpPost]
        public Burrito AddTaco(string name, float cost, bool bean)
        {
            Burrito newBurrito = new Burrito()
            {
                Name = name,
                Cost = cost,
                Bean = bean,
                
            };
            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();

            return newBurrito;
        }
    }
}
