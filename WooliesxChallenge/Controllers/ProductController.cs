using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Enums;

namespace WooliesxChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("Sort")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] string sortOption)
        {
            var canParse = Enum.TryParse(sortOption, true, out SortOption parsedSortOption);
            if (!canParse)
                throw new ValidationException("Sort Option is not valid");

            var products = await _productService.GetProductAsync(parsedSortOption);
            return Ok(products);
        }
    }
}
