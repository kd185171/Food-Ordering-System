using ApplicationBE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ApplicationBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("addToCart")]

        public Response addToCart(Cart cart)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.addToCart(cart, connection);
            return response;
        }

        [HttpPost]
        [Route("placeOrder")]

        public Response placeOrder(Users user)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.placeOrder(user, connection);
            return response;
        }

        

    }
}
