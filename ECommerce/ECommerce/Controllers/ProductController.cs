using ECommerce.iController;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly iProductController _iProductController;


        public ProductController(iProductController iProductController)
        {
            _iProductController = iProductController;
        }


        [HttpPost]
        [Route("api/ProductModel/addproduct")]
        public IActionResult addProduct(ProductModel product)
        {
            try
            {
                _iProductController.addProduct(product);
            }
            catch (Exception ex)
            {
                string msg = "Error While Inserting Data";
                return NotFound(new JsonResult(msg) { ContentType = null, StatusCode = 403 });
            }

            return Ok(new JsonResult("Data Added Successfully") { ContentType = null, StatusCode = 400 });
        }

        [HttpGet]
        // [Route("[action]")]
        [Route("api/product/getProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var conn = _iProductController.GetProduct(id);
            if (conn != null)
            {
                return Ok(conn);
            }
            string msg = "Data Not Found";
            return NotFound(new JsonResult(msg) { ContentType = null, StatusCode = 403 });
        }

        [HttpDelete]
        [Route("api/product/removeProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var add = _iProductController.GetProduct(id);
            if (add != null)
            {
                _iProductController.DeleteProduct(add);
                string msg = "Data Deleted Successfully";
                return Ok(new JsonResult(msg) { ContentType = null, StatusCode = 400 });
            }
            string msg1 = "Entered Id Is Not Found";
            return NotFound(new JsonResult(msg1) { ContentType = null, StatusCode = 403 });
        }
        [HttpPatch]
        [Route("api/product/updateProduct/{id}")]
        public IActionResult UpdateProduct(int id, ProductModel product)
        {
            var add = _iProductController.GetProduct(id);
            if (add != null)
            {
                product.Product_Id = add.Product_Id;
                _iProductController.UpdateProduct(product);
                string msg = "Data Changed Successfully";
                return Ok(new JsonResult(msg) { ContentType = null, StatusCode = 400 });
            }

            string msg1 = "Entered Id Is Not Found";
            return NotFound(new JsonResult(msg1) { ContentType = null, StatusCode = 403 });
        }
    }
}
