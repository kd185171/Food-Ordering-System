using ApplicationBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationBE.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("addUpdateProduct")]

        public Response addUpdateProduct(Products product)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            DAL dal = new DAL();
            Response response = new Response();
            response = dal.addUpdateProduct(product, connection);
            return response;
        }

        
    }
}
