using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MTTApi.Entities;
using MTTApi.Models;
using MTTApi.Services;

namespace MTTApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IMTTRepository _mttRepository;
        private readonly IMapper _mapper;

        public ProductsController(IMTTRepository mttRepository, IMapper mapper)
        {
            _mttRepository = mttRepository;
            //Auto mapper map entites to dto's
            _mapper = mapper;
        }

        //api/products 
        public IActionResult Get()
        {
            var productEntities = _mttRepository.GetProducts();

            return Ok(productEntities);
        }


        //https://localhost:44327/api/products/GetFeaturedProducts/1
        [HttpGet("GetByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var productEntities = _mttRepository.GetProductsByCategory(category);

            if (productEntities == null)
            {
                return NotFound();
            }

            return Ok(productEntities);
        }

        // https://localhost:44327/api/products/GetFeaturedProducts/1
        [HttpGet("GetFeaturedProducts/{feat}")]
        public IActionResult GetFeaturedProducts(int feat)
        {
            var productEntities = _mttRepository.GetFeaturedProducts();

            if (productEntities == null)
            {
                return NotFound();
            }

            return Ok(productEntities);
        }




    }
}
