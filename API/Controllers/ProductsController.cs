using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        
        private readonly StoreContext _storeContext;
        
          public ProductsController(StoreContext storeContext)
          {
            this._storeContext = storeContext;
            
          }


        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var products =  await  _storeContext.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }

        
    }
}