using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taco_Bell_API.Models;

namespace Taco_Bell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();//ANY CHANGES TO DB (ADDED/UPDATED) DONT FORGET TO dbContext.SaveChanges().

        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }
        [HttpGet("{i}")]
        public Taco GetById(int i)
        {
            return dbContext.Tacos.First(x => x.Id == i);
        }
        [HttpPost]
        public Taco AddTaco(string name, float cost, bool softShell, bool dorito)
        {
            Taco newTaco = new Taco()
            {
                Name = name,
                Cost = cost,
                SoftShell = softShell,
                Dorito = dorito,
            };
            dbContext.Tacos.Add(newTaco);
            dbContext.SaveChanges();

            return newTaco; 
        }
    }
}
