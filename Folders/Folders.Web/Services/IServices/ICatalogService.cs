using Folders.Model;
using Folders.Web.ViewModels;

namespace Folders.Web.Services.IServices
{
    public interface ICatalogService
    {
        Task<CatalogViewModel> GetAllCatalogsByParentIdAsync(Guid? parentId);
        Task<CatalogViewModel> GetParentCatalogsByNullAsync();
        Task<CatalogViewModel> GetParentCatalogsAsync();
        Task<Catalog> PostParentCatalog(string path, Guid? rootId);
        Task PostCatalogsByParentCatalogId(string path, Guid baseCatalogId);
    }
}
