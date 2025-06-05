using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OasisOneBack.Controllers
{
    public class ConsultasController : ApiController
    {
        private OasisOneEntities dbsuper = new OasisOneEntities();

        [HttpGet]
        [Route("servicios")]
        public async Task<IHttpActionResult> ConsultarListaServicios()
        {
            var servicios = await dbsuper.Servicios.Select(s => new
            {
                s.Id_Servicio,
                s.Nombre,
                s.Descripcion,
                s.Precio              
            }).ToListAsync();

            return Ok(servicios);
        }

        [HttpGet]
        [Route("sedes")]
        public async Task <IHttpActionResult> ConsultarListaSedes()
        {
            var servicios = await dbsuper.Sedes.Select(s => new
            {
                s.Id_Sede,
                s.Nombre,
                s.Direccion,
                s.Telefono,
                s.Correo_Contacto,
                s.Ciudad
            }).ToListAsync();

            return Ok(servicios);
        }
    }
}
