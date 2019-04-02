using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.Odbc;
using System.Data;
using Curiox.Web.Models;

namespace Curiox.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Question()
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(UNICODE)}; Server=localhost; Port=5432; Database=Curiox; Uid=postgres; Pwd=123456; ";
            List<Question> questionList = new List<Question>();

            try
            {
                using(OdbcConnection con = new OdbcConnection(connectionString))
                {
                    string query = "Select * from \"Question\"";

                    DataTable dt = new DataTable();

                    OdbcDataAdapter da = new OdbcDataAdapter();

                    da.SelectCommand = new OdbcCommand(query, con);

                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        var question = new Question();

                        question.Id = Int32.Parse(row["id"].ToString());

                        question.Title = row["title"].ToString();

                        question.DateCreated = (DateTime) row["date_created"];

                        question.DateUpdated = (DateTime) row["date_updated"];

                        question.UserId = Int32.Parse(row["user_id"].ToString());

                        question.CategoryId = Int32.Parse(row["category_id"].ToString());

                        questionList.Add(question);
                    }

                    return View(questionList);
                }
            }
            catch
            {

                return View("Error");
            }


            return View();
        }

        public string AddUser()
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(UNICODE)}; Server=localhost; Port=5432; Database=Curiox; Uid=postgres; Pwd=123456; ";
            string queryString =
                "INSERT INTO \"User\" (name, email, password, description) Values('Lam Nguyen', 'lamnt@gmail.com', '123456', 'Admin User')";
            OdbcCommand command = new OdbcCommand(queryString);

            using(OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

            return "OK";
        }

        public ActionResult ShowUser()
        {
            string connectionString = "Driver={PostgreSQL ODBC Driver(UNICODE)}; Server=localhost; Port=5432; Database=Curiox; Uid=postgres; Pwd=123456; ";
            List<User> userList = new List<User>();

            try
            {
                using (OdbcConnection con = new OdbcConnection())
                {
                    string query = "select * from \"User\"";

                    con.ConnectionString = connectionString;

                    DataTable dt = new DataTable();

                    OdbcDataAdapter da = new OdbcDataAdapter();

                    da.SelectCommand = new OdbcCommand(query, con);

                    da.Fill(dt);

                    foreach(DataRow row in dt.Rows)
                    {
                        var user = new User();

                        user.Id = Int32.Parse(row["id"].ToString());

                        user.Name = row["name"].ToString();

                        user.Email = row["email"].ToString();

                        user.Password = row["password"].ToString();

                        user.Description = row["description"].ToString();

                        userList.Add(user);
                    }
                }

                return View(userList);
            }

            catch
            {
                return View("Error");
            }
        }
    }
}