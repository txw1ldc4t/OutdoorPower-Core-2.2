using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutdoorPower.Models;

namespace OutdoorPower.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApiController : ControllerBase
    {
        private readonly IOutdoorPowerRepository _outdoorPowerRepository;
        private ILogger<InventoryApiController> _logger;

        public InventoryApiController(
            IOutdoorPowerRepository outdoorPowerRepository,
            ILogger<InventoryApiController> logger
            )
        {
            _outdoorPowerRepository = outdoorPowerRepository;
            _logger = logger;
        }

        [HttpGet("list/inventory/types")]
        [Produces("application/json")]
        public IActionResult QTypes()
        {
            try
            {
                var data = _outdoorPowerRepository.GetInventoryTypes();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when retrieving the Inventory Type List,  Error Message: {ex}");
            }

            return BadRequest("Failed to retrieve the inventory type list.");
        }

        [HttpGet("list/inventory/makes")]
        [Produces("application/json")]
        public IActionResult QMakes()
        {
            try
            {
                var data = _outdoorPowerRepository.GetInventoryMakes();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when retrieving the Inventory Make List,  Error Message: {ex}");
            }

            return BadRequest("Failed to retrieve the inventory make list.");
        }

        [HttpGet("list/inventory/models")]
        [Produces("application/json")]
        public IActionResult QModels(int makeId, int typeId)
        {
            try
            {
                var data = _outdoorPowerRepository.GetInventoryModels(makeId, typeId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when retrieving the Inventory Model List,  Error Message: {ex}");
            }

            return BadRequest("Failed to retrieve the inventory model list.");
        }

        [HttpGet("list/inventory/model/options")]
        [Produces("application/json")]
        public IActionResult QModelOptions(int modelId)
        {
            try
            {
                var data = _outdoorPowerRepository.GetInventoryModelOptions(modelId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when retrieving the Inventory Model List,  Error Message: {ex}");
            }

            return BadRequest("Failed to retrieve the inventory model list.");
        }

        [HttpGet("list/engine/horsepower")]
        [Produces("application/json")]
        public IActionResult QModelOptions(string engineBrand)
        {
            try
            {
                var data = _outdoorPowerRepository.GetEngineHorsePower(engineBrand);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when retrieving the Engine HorsePower List,  Error Message: {ex}");
            }

            return BadRequest("Failed to retrieve the engine horsepower list.");
        }
    }
}