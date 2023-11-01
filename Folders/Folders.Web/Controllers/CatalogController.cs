using Folders.Data.ContextData;
using Folders.Web.Services.IServices;
using Folders.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Folders.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService) 
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var catalogs = await _catalogService.GetParentCatalogsAsync();
            return View(catalogs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCatalogs(Guid? id)
        {
            CatalogViewModel catalogs;
            if (id != null)
            {
                catalogs = await _catalogService.GetAllCatalogsByParentIdAsync(id);
            }
            else
            {
                catalogs = await _catalogService.GetParentCatalogsByNullAsync();
            }

            return View(catalogs);
        }

        [HttpPost]
        public async Task<IActionResult> ImportDirectory(string path, Guid? rootId)
        {
            var baseCatalog = await _catalogService.PostParentCatalog(path, rootId);
            await _catalogService.PostCatalogsByParentCatalogId(path, baseCatalog.Id);
            return RedirectToAction("Index");
        }
    }
}
