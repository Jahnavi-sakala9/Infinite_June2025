using System.Threading.Tasks;
using System.Web.Mvc;
using Assignment1.Models;
using Assignment1.Repositories;

namespace Assignment1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repo;
        public ContactsController(IContactRepository repo) { _repo = repo; }

        public async Task<ActionResult> Index()
        {
            var items = await _repo.GetAllAsync();
            return View(items);
        }

        public ActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact c)
        {
            if (!ModelState.IsValid) return View(c);
            await _repo.CreateAsync(c);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(long id)
        {
            var contact = await _repo.GetByIdAsync(id);
            if (contact == null) return HttpNotFound();
            return View(contact);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
