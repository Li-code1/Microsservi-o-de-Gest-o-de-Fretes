// FreightManagement.Api/Controllers/FreightController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FreightManagement.Api.Models;

namespace FreightManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreightController : ControllerBase
    {
        /// <summary>
        /// Calcula o valor total do frete com base na distância.
        /// </summary>
        /// <response code="200">Retorna o valor do frete calculado com sucesso.</response>
        /// <response code="401">Não autorizado. Token JWT ausente ou inválido.</response>
        /// <response code="400">Dados de entrada inválidos.</response>
        [HttpPost("calculate")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Calculate([FromBody] FreightRoute route)
        {
            try
            {
                var totalPrice = route.CalculateTotalFreight();
                return Ok(new
                {
                    Origin = route.Origin,
                    Destination = route.Destination,
                    Distance = $"{route.DistanceInKm} Km",
                    TotalCost = totalPrice.ToString("C")
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}