using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;
using System.Net;

namespace ECommerce_API.Parent
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TViewModel, TIRepository, TKey> : ControllerBase
        where TViewModel : class
        where TIRepository : IBaseRepository<TViewModel, TKey>
    {
        protected readonly TIRepository _repository;

        public BaseController(TIRepository repository) { 
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                VMResponse<List<TViewModel>>? response = await Task.Run(() => _repository.GetAllAsync(""));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e) {
                Console.WriteLine("An error occurred while trying to retrieve data : " + e.Message);
                return BadRequest("An error occurred while trying to retrieve data : " + e.Message);
            }
        }

        [HttpGet("[action]/{filter?}")]
        public async Task<ActionResult> GetByFilterAsync(string? filter)
        {
            try
            {
                VMResponse<List<TViewModel>>? response = await Task.Run(() => _repository.GetAllAsync(filter));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to retrieve data : " + e.Message);
                return BadRequest("An error occurred while trying to retrieve data : " + e.Message);
            }
        }

        [HttpGet("[action]/{id?}")]
        public async Task<ActionResult> GetByIdAsync(TKey id)
        {
            try
            {
                VMResponse<TViewModel>? response = await Task.Run(() => _repository.GetByIdAsync(id));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to retrieve data : " + e.Message);
                return BadRequest("An error occurred while trying to retrieve data : " + e.Message);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> CreateAsync(TViewModel entity)
        {
            try
            {
                VMResponse<TViewModel>? response = await Task.Run(() => _repository.CreateAsync(entity));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to create data : " + e.Message);
                return BadRequest("An error occurred while trying to create data : " + e.Message);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult> UpdateAsync(TViewModel entity)
        {
            try
            {
                VMResponse<TViewModel>? response = await Task.Run(() => _repository.UpdateAsync(entity));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to update data : " + e.Message);
                return BadRequest("An error occurred while trying to update data : " + e.Message);
            }
        }

        [HttpDelete("{id}/{deletBy}")]
        public virtual async Task<ActionResult> DeleteAsync(TKey id, int deleteBy)
        {
            try
            {
                VMResponse<TViewModel>? response = await Task.Run(() => _repository.DeleteAsync(id, deleteBy));
                if (response!.data != null)
                {
                    return Ok(response);
                }

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while trying to update data : " + e.Message);
                return BadRequest("An error occurred while trying to update data : " + e.Message);
            }
        }
    }
}
