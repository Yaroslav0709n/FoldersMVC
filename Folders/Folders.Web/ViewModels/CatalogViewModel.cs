using Folders.Model;

namespace Folders.Web.ViewModels
{
    public class CatalogViewModel
    {
        public Catalog Catalog { get; set; }
        public List<Catalog> ChildCatalogs { get; set; }
    }
}
