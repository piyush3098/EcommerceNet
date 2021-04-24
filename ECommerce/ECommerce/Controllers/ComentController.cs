using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.iControllers;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentController : ControllerBase
    {
        
        private readonly iComents _iComents;
        public ComentController(iComents iComents)
        {
            _iComents = iComents;
        }
        [HttpPost]
        [Route("api/review/addReview")]
        public IActionResult addComment(ComentsModel review)
        {
            _iComents.addComment(review);
            return Ok(new JsonResult("Successful") { ContentType = "Review Added Successfully", StatusCode = 400 });
        }

        [HttpGet]
        // [Route("[action]")]
        [Route("api/review/getReview/{id}")]
        public IActionResult GetComment(int id)
        {
            var conn = _iComents.GetCommentID(id);

            if (conn != null)
            {
                var con = _iComents.GetComment(id);
                return Ok(con);
            }

            return NotFound(new JsonResult("Unsuccessful") { ContentType = "No Record Found", StatusCode = 403 });

        }

        [HttpDelete]
        [Route("api/review/removeReview/{id}")]
        public IActionResult DeleteReview(int id)
        {
            var add = _iComents.GetCommentID(id);
            if (add != null)
            {
                _iComents.DeleteComment(add);
                return Ok(new JsonResult("Successful") { ContentType = "Review Remove Successfully", StatusCode = 400 });
            }
            return NotFound(new JsonResult("Unsuccessful") { ContentType = "No Record Found", StatusCode = 403 });
        }
        [HttpPatch]
        [Route("api/product/updateReview/{id}")]
        public IActionResult UpdateReview(int id, ComentsModel review)
        {
            var add = _iComents.GetCommentID(id);
            if (add != null)
            {
                review.Coment_Id = add.Coment_Id;
                _iComents.UpdateComment(review);
                return Ok(new JsonResult("Successful") { ContentType = "Review Updated Successfully", StatusCode = 400 });

            }
            return NotFound(new JsonResult("Unsuccessful") { ContentType = "Error While updating Review Found", StatusCode = 403 });
        }
    }
}
