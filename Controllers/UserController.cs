using System.Collections.Generic;
using System.Linq;
using gustav_v2.db_context;
using gustav_v2.entity;
using gustav_v2.request;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gustav_v2.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<User> _logger;

        public UserController(ILogger<User> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/GetAllUsers")]
        public IEnumerable<User> Get()
        {
            using (AdvertContext db = new AdvertContext())
            {
                return db.Users.ToList();
            }
        }

        [HttpGet]
        [Route("api/CheckUser")]
        public User Get(string phone, string password)
        {
            using (AdvertContext db = new AdvertContext())
            {
                IEnumerable<User> users = db.Users.ToList();
                foreach (var u in users)
                {
                    if (u.Phone.Equals(phone) && u.Password.Equals(password))
                    {
                        return u;
                    }
                }
            }
            return null;
        }

        [HttpPost]
        [Route("api/CreateUser")]
        public void CreateUser(CreateUserRequest request)
        {
            User user = new User(
                request.Name,
                request.Surname,
                request.Phone,
                request.Password);
            using (AdvertContext db = new AdvertContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}