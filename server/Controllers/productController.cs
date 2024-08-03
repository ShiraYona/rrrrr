using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;
using services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productController : Controller
    {
        IMapper _mapper;
        IProductService _productService;
        HttpClient _httpClient;
        StoreDataBase1Context _storeDataBase1;
        public productController(IProductService productService, StoreDataBase1Context storeDataBase1,IMapper mapper, HttpClient httpClient)
        {
            _productService = productService;
            _storeDataBase1 = storeDataBase1;
            _mapper = mapper;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44387/api/Users/");
        }
        //[HttpGet]
        //public async Task<IEnumerable< ProductDto> >getProde()
        //{
        //    var products = await _productService.getProde();
        //    var products2 = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(products);
        //    return products2;
        //}

        [HttpGet("fkljs")]
        public async Task<List<User>> GetUsers()
        {
            
            
            var t =await _httpClient.GetAsync("");
            var y = await t.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(y);

        }

        [HttpPost]
        public async Task<ProductDto> ADD([FromBody] ProductDto product)
        {
            var t=_mapper.Map<ProductDto, Product > (product);
            await _storeDataBase1.Products.AddAsync(t);
            await _storeDataBase1.SaveChangesAsync();
            return product;
        }
        [HttpPut]
        public async Task<ProductDto> Put([FromBody] ProductDto product)
        {
            var t = _mapper.Map<ProductDto, Product>(product);
            var productee = await _storeDataBase1.Products.FindAsync(t.ProductId);
            if (t.Description != null)
            {
                productee.Description = t.Description;
            }
            if (t.Img!=null) { 
            productee.Img = t.Img;
            }
            if (t.Price != null)
            {
                productee.Price = t.Price;
            }

            productee.CategoryId = t.CategoryId;
            if (t.Name != null)
            {
                productee.Name = t.Name;
            }

           
            await _storeDataBase1.SaveChangesAsync();
            return product;
        }

        [HttpDelete("{id}")]
    public async Task<bool> del(int id)
        {
           var y=await  _storeDataBase1.Products.FindAsync(id);
            if (y != null) { 
             _storeDataBase1.Products.Remove(y);
            await _storeDataBase1.SaveChangesAsync();
            return true;}
            return false;
        }
    }
}
