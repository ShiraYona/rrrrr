using Entities;
using Newtonsoft.Json;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class ProductService:IProductService
    {
        IProductRepository _productRepository;
        private readonly HttpClient _httpClient;

        public ProductService(IProductRepository productRepository, HttpClient httpClient)
        {
            _productRepository = productRepository;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44387/api/Gift/");
        }
        public async Task<IEnumerable<Product>> getProde()
        {
            return await _productRepository.getProde();
        }
       

           

            public async Task<List<Gift>> GetUsersAsync()
            {
            var response = await _httpClient.GetAsync("GetGifts");
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Gift>>(content);
        }
       

    }

    public class Gift
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Donor { get; set; }
        public int Cost { get; set; } = 10;

        public string Description { get; set; }

        public string Image { get; set; }
        public int Quentity { get; set; } = 1;

        public Gift(int id, string name, string donor, int cost, string image, string description, int quentity)
        {
            Id = id;
            Name = name;
            Donor = donor;
            Cost = cost;
            Description = description;
            Image = image;
            Quentity = quentity;
        }
    }
}
