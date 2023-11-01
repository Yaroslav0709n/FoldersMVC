namespace Folders.Model
{
    public class Catalog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCatalogId { get; set; }
    }
}