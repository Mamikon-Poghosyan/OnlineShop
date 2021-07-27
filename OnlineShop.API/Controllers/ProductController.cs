using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Abstractions.Operations;
using OnlineShop.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductOperation _productOperation;
        public ProductController(IProductOperation productOperation)
        {
            _productOperation = productOperation;
        }
        [HttpPost]
        public IActionResult Get([FromBody] ProductModel model)
        {
                _productOperation.AddProduct(model);
            return Created("", model);
        }
    }
}
