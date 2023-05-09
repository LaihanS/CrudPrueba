using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Dtos;
using SocialNetwork.Core.Application.Features.Properties.Commands.CreateProperty;
using SocialNetwork.Core.Application.Features.Properties.Commands.DeleteProperty;
using SocialNetwork.Core.Application.Features.Properties.Commands.UpdateProperty;
using SocialNetwork.Core.Application.Features.Properties.Queries.GetAllProperties;
using SocialNetwork.Core.Application.Features.Properties.Queries.GetPropertyById;
using SocialNetwork.WebApi.Controllers;
using System.Data;
using System.Net.Mime;

namespace WebApi.SocialNetwork.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MejoraController : BaseApiController
    {
        public MejoraController(IServiceProvider services) : base(services)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
           
                return Ok(await Mediator.Send(new GetAllPropertiesQuery()));
           
        }

        [HttpGet("GetMejoraById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      
        public async Task<IActionResult> Get(int id)
        {
                return Ok(await Mediator.Send(new GetPropertyByIdQuery { id = id }));
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
 
        public async Task<IActionResult> Post([FromBody] CreatePropertyCommand command)
        {            

                await Mediator.Send(command);
                return NoContent();
        }


        [HttpPut("UpdateMejora/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PropertyDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json)]
   
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePropertyCommand command)
        {
           
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                if (id != command.id)
                {
                    return BadRequest();
                }

                return Ok(await Mediator.Send(command));
           
        }

        [HttpDelete("DeleteMejora/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
      
        public async Task<IActionResult> Delete(int id)
        {
           
                await Mediator.Send(new DeletePropertyById { id = id });
                return NoContent();
           
        }
    }
}
