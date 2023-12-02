using Microsoft.AspNetCore.Mvc;
using Tarea.Models;

namespace Tarea.Controllers
{
    [Route("api/Videojuego")]
    [ApiController]
    public class VideojuegoController : Controller
    {
        private static List<Videojuego> listaVideojuegos = new List<Videojuego>();

        [HttpPost("AddVideojuego")]
        public ActionResult AddVideojuego([FromBody] Videojuego videojuego)
        {
            listaVideojuegos.Add(videojuego);
            return Ok(videojuego);
        }

        private Videojuego GetVideojuegoXID(int id)
        {
            return listaVideojuegos.Find(x => x.IdJuego == id);
        }

        [HttpGet("ListarUnJuego")]
        public ActionResult ListarUnJuego(int idJuego)
        {
            Videojuego videojuego = GetVideojuegoXID(idJuego);
            return Ok(videojuego);
        }

        [HttpGet("ListarTodosLosJuegos")]
        public ActionResult ListarTodosLosJuegos()
        {
            return Ok(listaVideojuegos);
        }

        [HttpGet("ListarTiposDeJuegoDeUnJuego")]
        public ActionResult ListarTiposDeJuegoDeUnJuego(int idJuego)
        {
            Videojuego videojuego = GetVideojuegoXID(idJuego);
            return Ok(videojuego.TiposDeJuego);
        }

        [HttpPost("AgregarTipoDeJuegoAUnJuego")]
        public ActionResult AgregarTipoDeJuegoAUnJuego(int idJuego, [FromBody] TipoDeJuego nuevoTipoDeJuego)
        {
            Videojuego videojuego = GetVideojuegoXID(idJuego);
            videojuego.TiposDeJuego.Add(nuevoTipoDeJuego);
            return Ok(GetVideojuegoXID(idJuego));
        }

        [HttpPost("EditarTipoDeJuegoAUnJuego")]
        public ActionResult EditarTipoDeJuegoAUnJuego(int idJuego, [FromBody] TipoDeJuego tipoDeJuegoEditado)
        {
            Videojuego videojuego = GetVideojuegoXID(idJuego);
            videojuego.TiposDeJuego.Find(x => x.IdTipoDeJuego == tipoDeJuegoEditado.IdTipoDeJuego).Descripcion = tipoDeJuegoEditado.Descripcion;
            return Ok(GetVideojuegoXID(idJuego));
        }

        [HttpDelete("EliminarTipoDeJuegoAUnJuego")]
        public ActionResult EliminarTipoDeJuegoAUnJuego(int idJuego, int idTipoDeJuego)
        {
            Videojuego videojuego = GetVideojuegoXID(idJuego);
            TipoDeJuego tipo = videojuego.TiposDeJuego.Find(x => x.IdTipoDeJuego == idTipoDeJuego);
            videojuego.TiposDeJuego.Remove(tipo);
            return Ok(GetVideojuegoXID(idJuego));
        }
    }
}
