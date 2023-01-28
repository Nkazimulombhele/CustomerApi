using CustomerApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                              select CustomerId, FirstName,LastName,UserName,EmailAddress,Age,DateCreated,DateEdited,IsDeleted from 
                              dbo.Customer
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet]
        public JsonResult Get(Guid id)
        {
            string query = @"
                              select FirstName,LastName,UserName,EmailAddress,Age,DateCreated,DateEdited,IsDeleted from 
                              dbo.Customer
                             where CustomerId = CustomerId


                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerId", id);
                  
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Customer customer)
        {
            string query = @"
                            
                              insert into dbo.Customer  
                              values (@FirstName,@LastName,@UserName,@EmailAddress,@Age,@DateCreated,@DateEdited,@IsDeleted)
                              
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", customer.LastName);
                    myCommand.Parameters.AddWithValue("@UserName", customer.UserName);
                    myCommand.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);
                    myCommand.Parameters.AddWithValue("@Age", customer.Age);
                    myCommand.Parameters.AddWithValue("@DateCreated", customer.DateCreated);
                    myCommand.Parameters.AddWithValue("@@DateEdited", customer.DateEdited);
                    myCommand.Parameters.AddWithValue("@IsDeleted", customer.IsDeleted);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPut]
        public JsonResult Put(Customer cus)
        {
            string query = @"
                           
                             update dbo.Customer  
                              set  FirstName=@FirstName,LastName=@LastName,UserName=@UserName,EmailAddress=@EmailAddress,Age=@Age,DateCreated=@DateCreated,DateEdited=@DateEdited,IsDeleted=@IsDeleted)
                             where CustomerId = CustomerId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerId", cus.CustomerId);
                    myCommand.Parameters.AddWithValue("@FirstName", cus.FirstName);
                    myCommand.Parameters.AddWithValue("@LastName", cus.LastName);
                    myCommand.Parameters.AddWithValue("@UserName", cus.UserName);
                    myCommand.Parameters.AddWithValue("@EmailAddress", cus.EmailAddress);
                    myCommand.Parameters.AddWithValue("@Age", cus.Age);
                    myCommand.Parameters.AddWithValue("@DateCreated", cus.DateCreated);
                    myCommand.Parameters.AddWithValue("@@DateEdited", cus.DateEdited);
                    myCommand.Parameters.AddWithValue("@IsDeleted", cus.IsDeleted);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                              delete from dbo.Customer
                              where CustomerId = CustomerId

                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CustomerAppCon");
            SqlDataReader myReader;

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@CustomerId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
