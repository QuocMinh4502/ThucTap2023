using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThucTap.Data;
using ThucTap.Models;

namespace ThucTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DbContextClass _context;
        private readonly AppSetting _appSettings;

        public LoginController(DbContextClass context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(p =>
            p.UserName == model.UserName && model.Password == p.Password);
            if (user == null) //không đúng
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Tên người dùng hoặc mật khẩu không hợp lệ"
                });
            }

            // Cấp Token

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Đăng nhập thành công",
                Data = GenerateToken(user)
            });
        }

        [HttpGet("Dữ liệu tất cả người dùng")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Danh sách người dùng",
                Data = users
            });
        }

        [HttpPost("Tạo tài khoản")]
        public IActionResult AddUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Dữ liệu người dùng không hợp lệ"
                });
            }

            try
            {
                // Thêm người dùng mới vào cơ sở dữ liệu
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Người dùng đã được thêm thành công",
                    Data = newUser
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Success = false,
                    Message = "Đã xảy ra lỗi khi thêm người dùng",
                    ErrorDetails = ex.Message
                });
            }
        }


        [HttpGet("Lấy dữ liệu người dùng theo ID")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng"
                });
            }

            return Ok(new ApiResponse
            {
                Success = true,
                Data = user
            });
        }

        [HttpPut("Sửa thông tin người dùng")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng"
                });
            }

            // Cập nhật thông tin người dùng
            user.UserName = updatedUser.UserName;
            user.Password = updatedUser.Password;
            user.HoTen = updatedUser.HoTen;
            user.Email = updatedUser.Email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Cập nhật người dùng thành công",
                Data = user
            });
        }

        [HttpDelete("Xóa thông tin người dùng")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Không tìm thấy người dùng"
                });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Xóa người dùng thành công",
                Data = user
            });
        }

        private string GenerateToken(User user) 
        { 
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.HoTen),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserName", user.UserName),
                    new Claim("Id", user.Id.ToString()),

                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),// Thời gian của token
                SigningCredentials = new SigningCredentials(new  SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }


}
