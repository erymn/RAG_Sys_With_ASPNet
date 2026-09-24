using Microsoft.AspNetCore.Mvc;
using Rlzz.HazPro.RagSys.Models;
using Rlzz.HazPro.RagSys.Services;

namespace Rlzz.HazPro.RagSys.Controller;

[ApiController]
[Route("api/[controller]")]
public class PolicyController : ControllerBase
{
    private readonly PolicyService _policyService;

    public PolicyController(PolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] QuestionRequest request)
    {
        string answer = await _policyService.GetAnswerAsync(request.Question);
        return Ok(new { answer });
    }
}