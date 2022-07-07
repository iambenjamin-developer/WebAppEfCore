using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppEfCore.Entities;

namespace WebAppEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BusinessDbContext _context;

        public ProductsController(BusinessDbContext context)
        {
            _context = context;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _context.Products.ToListAsync();

            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            product.CreatedDate = DateTime.Now;

            _context.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            entity.Name = product.Name;
            entity.Stock = product.Stock;
            entity.UpdatedDate = DateTime.Now;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            _context.Products.Remove(entity);

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
    }
}
