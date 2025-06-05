using OasisOneBack.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebGrease;

namespace OasisOneBack.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public async Task<IHttpActionResult> PostLogin(LoginPeticion solicitud)
        {
            string correo = solicitud.Correo;
            string contraseña = solicitud.Contraseña;

            var login = new Login();
            var result = await login.LoginAsync(correo, contraseña);

            if (result.EsValido)
                return Ok(result);
            else
                return Unauthorized();

        }

        [HttpPost]
        [Route("api/registrarse/usuario")]
        public async Task<IHttpActionResult> PostUsuario(Usuarios usuarioNuevo)
        {
            var login = new Login();

            var resultado = await login.RegistrarUsuario(usuarioNuevo);

            if (!resultado.Exito)
            {
                return BadRequest(resultado.Mensaje);
            }

            return Ok(new
            {
                mensaje = resultado.Mensaje,
                id = resultado.Id
            });

        }


        [HttpPost]
        [Route("api/registrarse/empleado")]
        public async Task<IHttpActionResult> PostEmpleado(Empleados empleadoNuevo)
        {
            var login = new Login();
            var resultado = await login.RegistrarEmpleado(empleadoNuevo);

            if (!resultado.Exito)
            {
                return BadRequest(resultado.Mensaje);
            }

            return Ok(new
            {
                mensaje = resultado.Mensaje,
                id = resultado.Id
            });
        }

        public class LoginPeticion
        {
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }

    }
}
