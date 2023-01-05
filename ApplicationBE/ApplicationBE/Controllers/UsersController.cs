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
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("Registration")]

        public Response register(Users users)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.register(users, connection);
            return response;
        }

        [HttpPost]
        [Route("AddUser")]

        public Response AddUser(AddUser usi)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.AddUser(usi, connection);
            return response;
        }

        [HttpPost]
        [Route("AddMessage")]

        public Response AddMessage(AddMessage usi)
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.AddMessage(usi, connection);
            return response;
        }

        [HttpPost]
        [Route("Login")]
        public Response Login(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            Response response = new Response();
            response = dal.Login(users, connection);
            return response;
        }

        [HttpGet]
        [Route("orderList")]

        public Response orderList()
        {
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            response = dal.orderList(connection);
            return response;
        }


        [HttpPost]
        [Route("viewUser")]

        public Response viewUser(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            Response response = new Response();
            response = dal.viewUser(users, connection);
            return response;
        }

        [HttpPost]
        [Route("updateProfile")]

        public Response updateProfile(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            Response response = new Response();
            response = dal.updateProfile(users, connection);
            return response;
        }

        [HttpGet]
        [Route("UserList")]

        public Response UserList()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());
            DAL dal = new DAL();
            Response response = new Response();
            response = dal.UserList(connection);
            return response;
        }

        [HttpGet]
        [Route("Getregisters")]
        public registerdetails Getregisters()
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("ProdCS").ToString());

            DAL a = new DAL();
            registerdetails r = a.getregisters(conn);
            //we should write the logic of getting infomation of the registrations per day
            return r;
        }
    }
}
