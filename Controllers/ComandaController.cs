using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestTest.Data;
using RestTest.Models;

namespace RestTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly ComandaContext _context;

        public ComandaController(ComandaContext context)
        {
            _context = context;
        }

        //Creat/Edit
        [HttpPost]
        public JsonResult CreateComanda(ComandaModel comanda)
        {
            var result = _context.Comandas.Find(comanda.idUsuario);
        
            if (result == null)
            {
                _context.Comandas.Add(comanda);
                var user = new UsuarioModel
                {
                    idUsuario = comanda.idUsuario,
                    nomeUsuario = comanda.nomeUsuario,
                    telefoneUsuario = comanda.telefoneUsuario,
                };
                _context.Usuarios.Add(user);
            }
            else
            {
                return new JsonResult("Não é possível processar a solicitação porque ela está malformada ou incorreta.");
            }
            _context.SaveChanges();

            return new JsonResult(Ok(_context.Comandas.Find(comanda.idUsuario)));
        }

        //Get
        [HttpGet]
        public JsonResult Get([FromQuery] int id)
        {
            var result = _context.Comandas.Find(id);
    
            if(result == null) return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }
        //Get all
        [HttpGet ("GetAll")]
        public JsonResult Get()
        {
            var result = _context.Usuarios.Count();
            var usuarios = new List<UsuarioModel>();
            if (result != 0)
            {
                for (var i = result; i > 0; i--)
                {
                    usuarios.Add(_context.Usuarios.Find(i));
                }
            }else return new JsonResult(NotFound());

            return new JsonResult(Ok(usuarios));
        }

        // Delete 
        [HttpDelete]
        public JsonResult Delete([FromQuery] int id)
        {
            var result = _context.Comandas.Find(id);
            if (result == null) return new JsonResult(NotFound());

            _context.Comandas.Remove(result);
            _context.SaveChanges();

            return new JsonResult(Ok("{ success: { text: comanda removida}}"));
        }

        //Put
        [HttpPut]
        public JsonResult Put([FromQuery] int id,ComandaModel comanda)
        {
            var result = _context.Comandas.Find(id);
            if(result == null) return new JsonResult("O recurso solicitado não existe.");
            result = comanda;
            _context.SaveChanges();

            return new JsonResult(Ok(comanda.idUsuario));
        }
    }
}
