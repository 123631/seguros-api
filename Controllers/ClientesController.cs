using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase {
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context) {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(_context.Clientes.ToList());
    }
}