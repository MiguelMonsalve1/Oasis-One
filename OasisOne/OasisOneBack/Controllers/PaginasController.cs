using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OasisOneBack.Controllers
{
    public class PaginasController : Controller  
    {
        private OasisOneEntities db = new OasisOneEntities();

 
        public async Task<ActionResult> Sedes()
        {
            var sedes = await db.Sedes.ToListAsync();
            return View(sedes); 
        }

        
        public async Task<ActionResult> Servicios()
        {
            var servicios = await db.Servicios.ToListAsync();
            return View(servicios);  
        }
    }
}