using Microsoft.AspNetCore.Mvc;
using Tarea.Clases;
using Tarea.Memoria;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegoController : ControllerBase
    {
        // GET: api/<JuegoController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            Datos datos = new Datos();
            List<Juego> list = datos.obtenerJuegos();
            return Ok(list);
        }

        // GET api/<JuegoController>/5
        [HttpGet("{id}")]
        public ActionResult<Juego> Get(int id)
        {
            Datos datos = new Datos();
            Juego juego = datos.buscarJuego(id);
            return Ok(juego);
        }

        // POST api/<JuegoController>
        [HttpPost]
        public ActionResult<Juego> Post([FromBody] Juego value)
        {
            Datos datos = new Datos();
            datos.agregarJuego(value);
            return Ok(value);

        }

        // PUT api/<JuegoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Juego value)
        {

            Datos datos = new Datos();
            datos.editarJuego(id, value);
            return Ok(value);

        }

        // DELETE api/<JuegoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Datos datos = new Datos();
            datos.eliminarJuego(id);
            return Ok();
        }

        [HttpGet("Mostrar_Tipos_de_Juego")]
        public ActionResult<IEnumerable<string>> ActualizarTipo(int idJuego)
        {
            Datos datos = new Datos();
            List<TipoDeJuego> lista = datos.obtenerTipos(idJuego);
            return Ok(lista);
        }

        [HttpPut("EliminarTipo")]
        public ActionResult EliminarTipo(int idJuego, List<int> idsTipo)
        {
            Datos datos = new Datos();
            datos.eliminarTipos(idJuego, idsTipo);
            return Ok();
        }

        [HttpPut("ActualizarTipo")]
        public ActionResult ActualizarTipo(int idJuego, int idTipo, TipoDeJuego tipo)
        {
            Datos datos = new Datos();
            datos.editarTipos(idJuego, idTipo, tipo);
            return Ok();
        }


        [HttpPut("Agregar_Tipo")]
        public ActionResult AgregarTipo(int idJuego, TipoDeJuego tipo)
        {
            Datos datos = new Datos();
            datos.agregarTipos(idJuego, tipo);
            return Ok();
        }
    }
}
