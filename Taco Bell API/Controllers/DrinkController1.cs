using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taco_Bell_API.Models;

namespace Taco_Bell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController1 : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();//ANY CHANGES TO DB (ADDED/UPDATED) DONT FORGET TO dbContext.SaveChanges().

        [HttpGet]
        public List<Drink> GetAllDrinks()
        {
            return dbContext.Drinks.ToList();
        }
        [HttpGet("{i}")]
        public List<Drink> GetByPoor(float i)
        {
            
            return dbContext.Drinks.Where(x => x.Cost < i).ToList();
        }
        [HttpDelete]
        public Drink DeleteDrink(string name)
        {
            Drink noDrink = dbContext.Drinks.FirstOrDefault(drink => drink.Name == name);
            dbContext.Drinks.Remove(noDrink);
            dbContext.SaveChanges();
            return noDrink;
        }
        [HttpPut("drank")]
        public List<Drink> AllBajaBlastForFree(bool giveMeBaja)
        {
            if(giveMeBaja)
            {
                foreach(Drink d in dbContext.Drinks)
                {
                    d.Name = "Baja Blast";
                    d.Cost = 0;
                    d.Slushie = false;
                }
            }
            return dbContext.Drinks.ToList();
        }
    }
}
