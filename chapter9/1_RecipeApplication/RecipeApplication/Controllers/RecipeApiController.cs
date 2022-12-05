using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    [Route("api/recipe")]
    public class NoFilterRecipeApiController : ControllerBase
    {
        private const bool IsEnabled = true;
        private readonly RecipeService service;
        public NoFilterRecipeApiController(RecipeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        [EnsureRecipeExists]
        public async Task<IActionResult> Get(int id)
        {
            if (!IsEnabled)
            {
                return BadRequest();
            }
            try
            {
                if (!await this.service.DoesRecipeExistAsync(id))
                {
                    return NotFound();
                }
                var detail = await this.service.GetRecipeDetailAsync(id);
                Response.GetTypedHeaders().LastModified = detail.LastModified;
                return Ok(detail);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(
            int id, [FromBody] UpdateRecipeCommand command)
        {
            if (!IsEnabled)
            {
                return BadRequest();
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await this.service.DoesRecipeExistAsync(id))
                {
                    return NotFound();
                }
                await this.service.UpdateRecipeAsync(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        private static IActionResult GetErrorResponse(Exception ex)
        {
            var error = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = ex.Message,
                Status = 500,
                Type = "https://httpstatuses.com/500"
            };

            return new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }

}