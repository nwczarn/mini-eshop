using AIService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIService.Controllers;

[ApiController]
[Route("api/ollama")]
public class OllamaController : ControllerBase
{
    private readonly OllamaService _service;

    public OllamaController(OllamaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string prompt)
    {
        var result = await _service.GenerateAsync(prompt);
        return Ok(result);
    }
}