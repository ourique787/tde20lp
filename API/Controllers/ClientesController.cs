using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<List<Cliente>> Get()
    {
        return _context.Clientes.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        var cliente = _context.Clientes.Find(id);
        
        if(cliente == null)
        {
            return NotFound();
        }
    return cliente;
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        var cliente = _context.Clientes.Find(id);
        if(cliente == null)
        {
            return NotFound();
        }
        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var clienteParaRemover = _context.Produtos.Find(id);
        if(clienteParaRemover == null)
        {
            return NotFound();
        }
        _context.Remove(clienteParaRemover);
        _context.SaveChanges();
        return NoContent();
    }


}