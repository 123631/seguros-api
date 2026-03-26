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
    public async Task<IActionResult> Emitir(EmitirPolizaDto dto) {
        try{
            var result = await _service.EmitirPoliza(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        } catch (Exception ex) when (ex.Message.Contains("no existe") || ex.Message.Contains("inválidas")) {
            return BadRequest(new { message = ex.Message });
        } catch (Exception ex) {
            return StatusCode(500, "Ocurrió un error inesperado en el servidor, " + ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        var polizas = await _service.ObtenerPolizas();

        if (polizas == null || !polizas.Any())
            return NoContent();

        return Ok(polizas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)  {
        var poliza = await _service.ObtenerPorId(id);
        if (poliza == null) {
            return NotFound(new { message = $"La póliza no fue encontrada." });
        }
        return Ok(poliza);
    }
}