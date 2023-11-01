using Folders.Data.ContextData;
using Folders.Model;
using Folders.Web.Services.IServices;
using Folders.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Folders.Web.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;

        public CatalogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CatalogViewModel> GetAllCatalogsByParentIdAsync(Guid? parentId)
        {
            var catalog = _context.Catalogs.FirstOrDefault(c => c.Id == parentId);
            if (catalog == null)
                throw new ArgumentNullException(nameof(catalog));

            var childCatalogs = await _context.Catalogs.Where(c => c.ParentCatalogId == parentId).ToListAsync();
            if (childCatalogs == null)
                throw new ArgumentNullException(nameof(childCatalogs));

            var catalogViewModel = new CatalogViewModel()
            {
                Catalog = catalog,
                ChildCatalogs = childCatalogs,
            };

            return catalogViewModel;
        }

        public async Task<CatalogViewModel> GetParentCatalogsAsync()
        {
            var catalogs = await _context.Catalogs.Where(x => x.ParentCatalogId == null).ToListAsync();

            var catalogViewModel = new CatalogViewModel()
            {
                Catalog = null,
                ChildCatalogs = catalogs
            };

            return catalogViewModel;
        }

        public async Task<CatalogViewModel> GetParentCatalogsByNullAsync()
        {
            var catalog = _context.Catalogs.FirstOrDefault(c => c.ParentCatalogId == null);

            if (catalog == null)
                throw new ArgumentNullException(nameof(catalog));

            var childCatalogs = _context.Catalogs.Where(c => c.ParentCatalogId == catalog.Id).ToList();
            if (childCatalogs == null)
                throw new ArgumentNullException(nameof(childCatalogs));

            var catalogViewModel = new CatalogViewModel()
            {
                Catalog = catalog,
                ChildCatalogs = childCatalogs,
            };

            return catalogViewModel;
        }

        public async Task PostCatalogsByParentCatalogId(string path, Guid baseCatalogId)
        {
            string[] directories = Directory.GetDirectories(path);
            List<string> nameCatalogs = new List<string>();

            foreach (var c in directories)
            {
                List<string> subCatalogs = c.Split('/').ToList();
                nameCatalogs.Add(subCatalogs[subCatalogs.Count - 1]);
            }

            List<Catalog> catalogs = new List<Catalog>();

            for (int i = 0; i < nameCatalogs.Count; i++)
            {
                catalogs.Add(new Catalog()
                {
                    Id = Guid.NewGuid(),
                    Name = nameCatalogs[i],
                    ParentCatalogId = baseCatalogId,
                });
            }
            await _context.Catalogs.AddRangeAsync(catalogs);
            await _context.SaveChangesAsync();
        }

        public async Task<Catalog> PostParentCatalog(string path, Guid? rootId)
        {
            string[] directories = Directory.GetDirectories(path);
            
            List<string> baseCatalog = directories[0].Split('/').ToList();
            string nameBaseCatalog = baseCatalog[baseCatalog.Count - 2];

            var catalog = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = nameBaseCatalog,
                ParentCatalogId = rootId,
            };

            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();

            return catalog;
        }
    }
}
