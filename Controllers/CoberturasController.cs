using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class CoberturasController : ControllerBase {
    private readonly AppDbContext _context;

    public CoberturasController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(_context.Coberturas.ToList());
    }
}