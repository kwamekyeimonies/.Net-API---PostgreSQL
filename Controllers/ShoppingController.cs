using Microsoft.AspNetCore.Mvc;
using PostgresSQL.API.DBContext;
using PostgresSQL.API.Model;
using PostgresSQL.API.Repository;
using PostgresSQL.API.Handler;

namespace PostgresSQL.API.Controllers
{
    public class ShoppingApiController : ControllerBase
    {
        private readonly ShoppingImpl _db;
        public ShoppingApiController(EF_DataContext eF_DataContext)
        {
            _db = new ShoppingImpl(eF_DataContext);
        }

        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {

            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Product> data = _db.GetProducts();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(Responsehandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }

        }

        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(Guid id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                Product data = _db.GetProductByID(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(Responsehandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] Order model)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.SaveOrder(model);
                return Ok(Responsehandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put([FromBody] Order model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(Responsehandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(Responsehandler.GetAppResponse(type, "Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Responsehandler.GetExceptionResponse(ex));
            }
        }
    }
}