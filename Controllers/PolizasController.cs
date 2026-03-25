using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PolizasController : ControllerBase {
    private readonly IPolizaService _service;

    public PolizasController(IPolizaService service)
    {
        _service = service;
    }

    [HttpPost("emitir")]
    public async Task<IActionResult> Emitir(EmitirPolizaDto dto)     {
        try
        {
            var result = await _service.EmitirPoliza(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        return Ok(await _service.ObtenerPolizas());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)  {
        var poliza = await _service.ObtenerPorId(id);
        if (poliza == null) return NotFound();
        return Ok(poliza);
    }
}