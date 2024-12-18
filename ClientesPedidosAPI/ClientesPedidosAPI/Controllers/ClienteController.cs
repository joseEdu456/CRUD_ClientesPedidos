using ClientesPedidosAPI.Data;
using ClientesPedidosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesPedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly AplicationContext _context;
    public ClienteController(AplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
    {
        if (_context.Clientes.Count() == 0)
        {
            return NotFound();
        }
        return await _context.Clientes.Include(c => c.Pedidos).ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        if (_context.Clientes.Count() == 0)
        {
            return ValidationProblem(new ValidationProblemDetails(ModelState)
            {
                Title = "Nenhum cliente cadastrado"
            });
        }
        var cliente = await _context.Clientes.Include(c => c.Pedidos).FirstOrDefaultAsync(c => c.Id == id);
        if(cliente == null) return NotFound();
        return cliente;
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        _context.Clientes.Add(cliente);
        foreach (var pedido in cliente.Pedidos)
        {
            _context.Pedidos.Add(pedido);
        }
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
    {
        if (_context.Clientes.Count() == 0)
        {
            return ValidationProblem(new ValidationProblemDetails(ModelState)
            {
                Title = "Nenhum cliente cadastrado"
            });
        }

        if (id != cliente.Id) return BadRequest();

        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        _context.Entry(cliente).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClienteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Cliente>> DeleteCliente(int id)
    {
        if(_context.Clientes.Count() == 0) return NotFound();
        
        var cliente = await _context.Clientes.FindAsync(id);
        if(cliente == null) return NotFound();
        
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClienteExists(int id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}