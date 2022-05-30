using Helper.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;
using UserProfile.Model;
using UserProfile.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserProfile
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{login}")]
        public Guid Get(string login) =>_usersRepository.GetUserGuid(login.Trim('{', '}'));

        // POST api/<UserController>/Registration
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(RegistrateUserViewModel registrateUserViewModel)
        {
            if (registrateUserViewModel is null)
                BadRequest();

            var user = new SimpleUser(registrateUserViewModel.Login, registrateUserViewModel.Password)
            {
                FirstName = registrateUserViewModel.FirstName,
                LastName = registrateUserViewModel.LastName,
                Email = registrateUserViewModel.Email,
            };

            try
            {
                _usersRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok();
        }

        // Get api/<UserController>/Login
        [HttpGet]
        [Route("Login/{login}&{password}")]
        public IActionResult Login(string login, string password)
        {
            var user = _usersRepository.FindUser(new UserViewModel() {Login = login, Password = password });
            if (user is null)
                return Problem("Пользователь не найден");

            return new OkObjectResult(user.Guid);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
