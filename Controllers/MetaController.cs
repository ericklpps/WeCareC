using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeCare.Models;
using WeCare.Repositories;

namespace WeCare.Controllers
{
    public class MetaController : Controller
    {
        private readonly IMetaRepository _metaRepository;

        public MetaController(IMetaRepository metaRepository)
        {
            _metaRepository = metaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var metas = await _metaRepository.GetAllAsync();
            return View(metas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Meta meta)
        {
            if (ModelState.IsValid)
            {
                await _metaRepository.AddAsync(meta);
                return RedirectToAction(nameof(Index));
            }
            return View(meta);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var meta = await _metaRepository.GetByIdAsync(id);
            if (meta == null)
            {
                return NotFound();
            }
            return View(meta);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Meta meta)
        {
            if (id != meta.MetaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _metaRepository.UpdateAsync(meta);
                return RedirectToAction(nameof(Index));
            }
            return View(meta);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var meta = await _metaRepository.GetByIdAsync(id);
            if (meta == null)
            {
                return NotFound();
            }
            return View(meta);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _metaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
