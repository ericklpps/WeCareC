using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeCare.Models;
using WeCare.Repositories;

namespace WeCare.Controllers
{
    public class MetaUsuarioController : Controller
    {
        private readonly IMetaUsuarioRepository _metaUsuarioRepository;

        public MetaUsuarioController(IMetaUsuarioRepository metaUsuarioRepository)
        {
            _metaUsuarioRepository = metaUsuarioRepository;
        }

        // GET: MetaUsuario
        public async Task<IActionResult> Index()
        {
            var metaUsuarios = await _metaUsuarioRepository.GetAllAsync();
            return View(metaUsuarios);
        }

        // GET: MetaUsuario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var metaUsuario = await _metaUsuarioRepository.GetByIdAsync(id);
            if (metaUsuario == null)
            {
                return NotFound();
            }
            return View(metaUsuario);
        }

        // GET: MetaUsuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetaUsuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,MetaId,Status,DataConclusao,DescricaoPersonalizada,Prazo")] MetaUsuario metaUsuario)
        {
            if (ModelState.IsValid)
            {
                await _metaUsuarioRepository.AddAsync(metaUsuario);
                return RedirectToAction(nameof(Index));
            }
            return View(metaUsuario);
        }

        // GET: MetaUsuario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var metaUsuario = await _metaUsuarioRepository.GetByIdAsync(id);
            if (metaUsuario == null)
            {
                return NotFound();
            }
            return View(metaUsuario);
        }

        // POST: MetaUsuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MetaUsuarioId,UsuarioId,MetaId,Status,DataConclusao,DescricaoPersonalizada,Prazo")] MetaUsuario metaUsuario)
        {
            if (id != metaUsuario.MetaUsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _metaUsuarioRepository.UpdateAsync(metaUsuario);
                return RedirectToAction(nameof(Index));
            }
            return View(metaUsuario);
        }

        // GET: MetaUsuario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var metaUsuario = await _metaUsuarioRepository.GetByIdAsync(id);
            if (metaUsuario == null)
            {
                return NotFound();
            }
            return View(metaUsuario);
        }

        // POST: MetaUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _metaUsuarioRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
