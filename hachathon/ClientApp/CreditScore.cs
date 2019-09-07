using System;
using System.Threading.Tasks;
using hachathon.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hachathon.ClientApp
{
  [Route("/api/[controller]/")]
  [ApiController]
  public class CreditScore : Controller
  {
    [HttpGet("{ssn}")]
    [ProducesResponseType(typeof(CreditScoreResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetScore(string ssn)
    {
        Random random = new Random();
        return Ok(new CreditScoreResource { Score = random.Next(1, 800)});
    }

  }
}
