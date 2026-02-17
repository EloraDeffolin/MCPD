public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Smartphone X", Category = "Électronique", Price = 799.99 },
            new Product { Id = 2, Name = "T-shirt coton", Category = "Vêtements", Price = 24.90 },
            new Product { Id = 3, Name = "Café en grains 1kg", Category = "Alimentation", Price = 12.50 },
            new Product { Id = 4, Name = "Ordinateur portable Pro", Category = "Électronique", Price = 1499.00 },
            new Product { Id = 5, Name = "Jean slim", Category = "Vêtements", Price = 59.99 },
            new Product { Id = 6, Name = "Tablette 10 pouces", Category = "Électronique", Price = 329.00 }
        };
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetFilteredProducts(string category, double? maxPrice)
    {
        IEnumerable<Product> query = _products;

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= maxPrice.Value);
        }

        return query.ToList();
    }
}