using DTS_Web_Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DTS_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class GeneralController<TEntity,TIRepository, TKey> : ControllerBase
        where TEntity : class
        where TIRepository : IGeneralRepository <TEntity,TKey>
    {
        protected readonly TIRepository _repository;

        public GeneralController(TIRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var results = await _repository.GetAllAsync();
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(TKey key)
        {
            var results = await _repository.GetByIdAsync(key);
            if (results == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    data = new
                    {
                        message = "Data Not Found!"
                    }
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                data = results
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TEntity entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data insert",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(TKey key,TEntity entity)
        {
            if (key.Equals(entity.GetType().GetProperty("Id")) ||
            key.Equals(entity.GetType().GetProperty("Nik")))
            {
                return BadRequest();
            }

            if (!await _repository.IsExist(key))
            {
                return NotFound();
            }

            try
            {
                await _repository.UpdateAsync(entity);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data update",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(TKey key)
        {
            try
            {
                await _repository.DeleteAsync(key);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = new
                    {
                        Message = "Data Sucessfully delete",
                    }
                });
            }
            catch
            {
                return NotFound(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    data = new
                    {
                        message = "Server Cannot Process Request"
                    }
                });
            }
        }
    }
}
