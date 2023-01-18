using InternsManager.BL.Interfaces;
using InternsManager.Constants;
using InternsManager.DAL.Entities;
using InternsManager.DAL.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using bCrypt = BCrypt.Net.BCrypt;

namespace InternsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly IRoleLogic _roleLogic;

        public SecurityController(ApplicationDbContext context, IConfiguration configuration, IMemoryCache memoryCache,
            IRoleLogic roleLogic)
        {
            _context = context;
            _configuration = configuration;
            _cache = memoryCache;
            _roleLogic = roleLogic ?? throw new ArgumentNullException(nameof(roleLogic));
        }

        /// <summary>
        /// Log in an user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">Loged in, token created</response>
        /// <response code="401">Encoding Error</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">User Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            User existingUser = await _context.Users.Where(u => u.Mail == user.Mail)
                .Select(user => new User()
                {
                    IdUser = user.IdUser,
                    Username = user.Username,
                    Mail = user.Mail,
                    Password = user.Password,
                    IdRole = user.IdRole,
                    IdPerson = user.IdPerson,
                }).SingleOrDefaultAsync() ?? throw new ArgumentNullException(nameof(user));

            HttpResponseMessage httpResponse = new();

            if (existingUser == null || !bCrypt.Verify(user.Password, existingUser.Password))
            {
                return NotFound();
            }

            List<Claim> authClaims = new();

            authClaims.Add(new Claim(UserClaimType.UserId.ToString(), existingUser.IdUser.ToString()));
            var roles = await _roleLogic.GetAll();
            Console.WriteLine("  [Role] : " + existingUser.IdRole);
            string result = roles.FirstOrDefault(role => existingUser.IdRole == role.IdRole).RoleName.ToString();
            authClaims.Add(new Claim(ClaimTypes.Role, result));

            SymmetricSecurityKey authSigninKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            DateTime dateTime = DateTime.Now.AddHours(1);

            JwtSecurityToken token = new(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: dateTime,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );


            var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(token);

            _cache.Set("token", tokenEncoded, token.ValidTo);

            return Ok(new Cookie("token", tokenEncoded));


        }

        /// <summary>
        /// Register an user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">Register user</response>
        /// <response code="201">User has been created!</response>
        /// <response code="403">An user with this username already exist</response>
        /// <response code="404">User Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {

            if (UserExists(user.Username))
            {
                return new ContentResult() { Content = "An user with this username already exist", StatusCode = 403 };
            }

            user.Password = bCrypt.HashPassword(user.Password);

            user.IdRole = 1;

            _context.Add(user);

            await _context.SaveChangesAsync();

            return new ContentResult() { Content = "User has been created!", StatusCode = 201 };

        }


        private bool UserExists(string username)
        {
            return _context.Users.Any(user => user.Username == username);
        }

        /// <summary>
        /// Log out an user
        /// </summary>
        /// <response code="200">Loged user out</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">User Not Found</response>
        /// <response code="500">Server problems</response>
        /// <response code="429">Too Many Requests</response>
        [HttpGet]
        public void Logout()
        {
            var authorization = Request.Headers["Authorization"];

            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {

                var parameter = headerValue.Parameter;

                Console.WriteLine(parameter);

            }

        }
    }
}
