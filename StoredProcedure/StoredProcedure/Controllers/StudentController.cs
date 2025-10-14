using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Data;
using StoredProcedure.Models;

namespace StoredProcedure.Controllers
{
    public class StudentController : Controller
    {
        public StoredProcDbContext _context;
        public IConfiguration _confiq;

        public StudentController(StoredProcDbContext context, IConfiguration config)
        {
            _context = context;
            _confiq = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string connectionStr = _confiq.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spSearchStudent";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Student> model = new List<Student>();
                while (sdr.Read())
                {
                    var details = new Student();
                    details.FirstName = sdr["FirstName"].ToString();
                    details.LastName = sdr["LastName"].ToString();
                    details.Gender = sdr["Gender"].ToString();
                    details.Age = Convert.ToInt32(sdr["Age"]);
                    details.Class = sdr["Class"].ToString();
                    model.Add(details);
                }

                return View(model);
            }
        }
    }
}
