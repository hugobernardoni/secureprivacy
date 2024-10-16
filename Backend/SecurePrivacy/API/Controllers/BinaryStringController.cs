using API.DTO;
using AutoMapper;
using BinaryStringAnalyzer;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Repositories.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/binary")]
    public class BinaryStringController : ControllerBase
    {
       public BinaryStringController()
       {
       }

        [HttpPost("isvalid")]
        public async Task<ActionResult<ProductDto>> IsValid(BinaryStringDto binaryStringDto)
        {
            bool actualResult = BinaryStringAnalyzer.BinaryStringAnalyzer.IsGoodBinaryString(binaryStringDto.Content);

            return Ok(new
            {
                result = actualResult 
            });
        }
    }
}
