namespace SampleProject.Domain.Interfaces
{
    public interface ISampleDatabase
    {
        Task AddProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task DeleteProductById(Product product);
        Task EventOccured(Product product, string evt);
    }
}
