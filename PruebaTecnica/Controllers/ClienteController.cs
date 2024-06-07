using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase//hereda para que esta clase entienda que es un controlador
    {
        private readonly Context _context;

        public ClienteController(Context context)//metodo para poder acceder a la base de datos
        {
            _context = context;
        }

        [HttpPost]//protocolo http para agregar un nuevo cliente
        [Route("crearNumero")]
        public async Task<ActionResult>crearNumeroSorteo(int idUsuario, int idCliente,int idSorteo, string nombreUsuario)//Descripcion de requerimiento 3
        {
            if(idUsuario == 0 || idCliente == 0 || idSorteo == 0)//Tiene que enviar los 3 datos
            {
                return BadRequest("Faltan datos");
            }

            var sorteo = new Sorteo
            {
                idSorteo = idSorteo,
                numeroSorteo = new Random().Next(0, 99999)//Escoge un numero random entre 0 y 99999 que es el requerimiento numero 1
            };

            var usuario = new Usuario
            {
                idUsuario = idUsuario,
                idCliente = idCliente,
                idSorteo = idSorteo,
                nombreUsuario = nombreUsuario,
                fechaNacimiento = DateTime.Now,
                sorteo = sorteo//valores de los datos que se envian del usuario, falta enviar el numero de sorte
                //que está en la tabla Sorteo, y el atributo se llama numeroSorteo
                
            };

              

            var sorteosBd = _context.Sorteos.ToList();//Obtiene el numero de sorteo

            var sorteoExistente = sorteosBd.Where(x => x.numeroSorteo == sorteo.numeroSorteo).FirstOrDefault();//Busca si el numero de sorteo ya existe en la base de datos

            if (sorteoExistente!=null)
            {
                sorteo.numeroSorteo = new Random().Next(0, 99999);//Escoge un numero random entre 0 y 99999 que es el requerimiento numero 1
            }

            
                //Busca si el numero de sorteo ya existe en la base de datos

            var cliente = new Cliente//Valores del cliente
            {
                idCLiente = idCliente,
                nombreEmpresa = "Empresa"
            };

            await _context.Sorteos.AddAsync(sorteo);//Agregamos el sorteo a la tabla Sorteo
            await _context.SaveChangesAsync();//Guardamos los cambios

            await _context.Usuarios.AddAsync(usuario);//lo mismo para usuario
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]//protocolo http para obtener la información de los usuarios y saber si se están ingresando correctamente
        [Route("obtenerInfo")]
        public async Task<ActionResult<IEnumerable<Usuario>>>obtenerInfo()//obtener la información de los usuarios
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
    }
}
