using Folders.Model;
using Microsoft.EntityFrameworkCore;

namespace Folders.Data.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {
            var baseFolder = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Creating Digital Images",
            };

            var resourcesBaseCDI = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Resources",
                ParentCatalogId = baseFolder.Id,
            };


            var evidenceBaseCDI = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Evidence",
                ParentCatalogId = baseFolder.Id,
            };

            var graficProductsBaseCDI = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Grafic Products",
                ParentCatalogId = baseFolder.Id,
            };

            var primarySource = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Primary Source",
                ParentCatalogId = resourcesBaseCDI.Id,
            };

            var secondarySource = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Secondary Source",
                ParentCatalogId = resourcesBaseCDI.Id,
            };

            var process = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Process",
                ParentCatalogId = graficProductsBaseCDI.Id,
            };


            var finalProduct = new Catalog()
            {
                Id = Guid.NewGuid(),
                Name = "Final Product",
                ParentCatalogId = graficProductsBaseCDI.Id,
            };

            builder.Entity<Catalog>().HasData(baseFolder);
            builder.Entity<Catalog>().HasData(resourcesBaseCDI);
            builder.Entity<Catalog>().HasData(evidenceBaseCDI);
            builder.Entity<Catalog>().HasData(graficProductsBaseCDI);
            builder.Entity<Catalog>().HasData(primarySource);
            builder.Entity<Catalog>().HasData(secondarySource);
            builder.Entity<Catalog>().HasData(process);
            builder.Entity<Catalog>().HasData(finalProduct);
        }
    }
}
