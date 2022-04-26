using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_project.Data;

namespace my_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyclassController : ControllerBase
    {

        //changing here
        private readonly DataContext _datacontext;

        public MyclassController(DataContext datacontext)
        {
            this._datacontext = datacontext;
        }
        
        
        
        
        
        private static List<Myclass> heroes = new List<Myclass>
            {
                new Myclass
                { Id = 1,
                    Name ="Spiderman",
                    FirstName="Rajesh",
                    LastName="Singh",
                    Address="jankpur"
                },
               new Myclass
                { Id = 2,
                    Name ="superman",
                    FirstName="Suresh",
                    LastName="Singh",
                    Address="Kathmandu"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Myclass>>> Get()
        {

            return Ok(await _datacontext.Myclasses.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Myclass>> GetById(int id)
        {//

            var hero = await _datacontext.Myclasses.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("ID values not found");
            }
            return Ok(hero);
        }
         [HttpPost]
         public async Task<ActionResult<List<Myclass>>> Addclass(Myclass hero)
        {
            _datacontext.Myclasses.Add(hero);
            await _datacontext.SaveChangesAsync();
            return Ok(await _datacontext.Myclasses.ToListAsync());
        }

        //changes
        [HttpPut]
        public async Task<ActionResult<List<Myclass>>> Updateclass(Myclass request)
        {
            var dbhero = await _datacontext.Myclasses.FindAsync(request.Id);
            if (dbhero == null)
            {
                return BadRequest("ID values not found");
            }
             dbhero.Name = request.Name;
            dbhero.FirstName = request.FirstName;
            dbhero.LastName = request.LastName;
            dbhero.Address = request.Address;
            await _datacontext.SaveChangesAsync();
            return (await _datacontext.Myclasses.
                ToListAsync());

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Myclass>>> Delete(int id)
        {
            var dbhero = await _datacontext.Myclasses.FindAsync(id);
            if (dbhero == null)
            {
                return BadRequest("ID values not found");
            }

            _datacontext.Myclasses.Remove(dbhero);
            await _datacontext.SaveChangesAsync();
            return Ok(await _datacontext.Myclasses.ToListAsync());

        }


    }
}
