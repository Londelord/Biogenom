using Biogenom.API.Contracts;
using Biogenom.Persistence.DTOs;
using Biogenom.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.API.Controllers;

[ApiController]
[Route("[controller]/result")]
public class DiagnosisController : ControllerBase
{
    private readonly DiagnosisRepository _diagnosisRepository;

    public DiagnosisController(DiagnosisRepository diagnosisRepository)
    {
        _diagnosisRepository = diagnosisRepository;
    }

    [HttpGet]
    public async Task<ActionResult<DiagnosisResultDto>> GetLatestResult()
    {
        try
        {
            var result = await _diagnosisRepository.GetLatestDiagnosisResult();
            
            if (result.IsFailure) return BadRequest(result.Error);
            
            return Ok(result.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> SaveResult([FromBody] SaveDiagnosisRequest request)
    {
        try
        {
            var boolResult = await _diagnosisRepository.SaveDiagnosisResults(request.Values);
            
            if (boolResult.IsFailure) return BadRequest(boolResult.Error);
            
            return Ok(boolResult.Value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500);
        }
    }
}