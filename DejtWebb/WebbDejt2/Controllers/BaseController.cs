using System.Web.Mvc;
using WebbDejt2.Models;

namespace WebbDejt2.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            
            base.Dispose(disposing);
        }
    }
}