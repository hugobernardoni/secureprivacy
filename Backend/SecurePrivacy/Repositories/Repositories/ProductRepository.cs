using DAO;
using Model.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.Interfaces;
namespace Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MongoDbContext _context;

        public ProductRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products.Find(p => p.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task Delete(string id)
        {
            await _context.Products.DeleteOneAsync(p => p.Id == ObjectId.Parse(id));
        }

        public async Task Update(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id); 
            await _context.Products.ReplaceOneAsync(filter, product); 
        }
    }
}
