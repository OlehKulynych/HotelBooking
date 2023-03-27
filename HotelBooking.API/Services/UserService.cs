using AutoMapper;
using HotelBooking.API.Interfaces;
using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBooking.API.Services
{
    public class UserService: IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Register(RegisterUserDto registerUserDto)
        {

            var identityUser = _mapper.Map<User>(registerUserDto);
            var identityResult = await _userManager.CreateAsync(identityUser, registerUserDto.Password);

            return identityResult;
        }

        public async Task<string> LogIn(LogInUserDto userDto)
        {

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(userDto.EmailAddress, userDto.Password, false, false);
            if (signInResult.Succeeded)
            {
                User identityUser = await _userManager.FindByNameAsync(userDto.EmailAddress);
                string JSONWebTokenAsString = await GenerateJsonWebToken(identityUser);
                return JSONWebTokenAsString;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var identityUser = _mapper.Map<UserDto>(user);
            return identityUser;
        }

        public static async Task CreateDefaultAdmin(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            bool x = await roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new Role();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);


                var user = new User();
                user.Email = "admin@admin.com";
                user.UserName = user.Email;
                user.Surname = "admin";
                user.Name = "admin";

                string password = "Qwe123!";

                var identityUser = await userManager.CreateAsync(user, password);

                if (identityUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");
                }
            }

        }

        private async Task<string> GenerateJsonWebToken(User identityUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };

            IList<string> roleNames = await _userManager.GetRolesAsync(identityUser);
            claims.AddRange(roleNames.Select(roleName => new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.UtcNow.AddDays(28),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
