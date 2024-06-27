
using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Dtos.AuthDtos;
using BusinessLogic.Dtos.RequestDtos;
using BusinessLogic.Exceptions;
using BusinessLogic.Repostitory;
using BusinessLogic.Utiliti;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FSAM.BusinessLogic.Services
{
    //public interface ILoginService
    //{
    //    Task<LoginResult> login(LoginRequest login);
    //    public SecurityToken GenerateJwtToken(User user);

    //}
    public class AuthBusiness
    {
        private readonly IRepository<User,int> _userRepository;

        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IRepository<RefreshToken, int> _refreshTokenRepository;
        private readonly IMapper _mapper;

        public AuthBusiness(IRepository<User, int> userRepository, IConfiguration configuration
            , TokenValidationParameters tokenValidationParameters, IRepository<RefreshToken, int> refreshTokenRepository, IMapper mapper)
        {

            _configuration = configuration;
            _tokenValidationParameters = tokenValidationParameters;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseModel> Login(LoginModel login)
        {

            var userExist = await _userRepository.FindByCondition(u => u.Email == login.Email).FirstOrDefaultAsync();
            var userModel = _mapper.Map<UserModel>(userExist);
            string passwordToCheck = login.Password;
            bool passwordVerified = false;
            if (userExist is null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Email not exist"

                };

            }
            string storedPassword = userExist.Password;
            if (storedPassword.Length == 60 && storedPassword.StartsWith("$2a$"))
            {
                // Mật khẩu đã được mã hóa, sử dụng Verify của BCrypt để xác minh
                passwordVerified = BCrypt.Net.BCrypt.Verify(passwordToCheck, storedPassword);
            }
            else
            {
                // Mật khẩu chưa được mã hóa, mã hóa mật khẩu trước khi xác minh
                passwordVerified = (passwordToCheck == storedPassword);
            }

            if (!passwordVerified)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Message = "Wrong password"
                };
            }

            return new LoginResponseModel
            {
                Success = true,
                Data = await GenerateJwtToken(userModel),
                Message = "Login success"
            };

        }
        public async Task<bool> Register(CreateUserModel createUserModel)
        {
            try
            {
                var userExist = await _userRepository.GetAll().Where(u => u.Username == createUserModel.Username).FirstOrDefaultAsync();
                if (userExist != null)
                {
                    throw new BadRequestException("User has exist");
                }
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserModel.Password);

                var newUser = new User
                {
                    Username = createUserModel.Username,
                    Email = createUserModel.Email,
                    Address = createUserModel.Address,
                    DoB = createUserModel.DoB,
                    Fullname = createUserModel.Fullname,
                    Password = passwordHash,
                    Phone = createUserModel.Phone,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Role = SD.Role_User,
                    Status = SD.ACTIVE
                };
                await _userRepository.AddAsync(newUser);
                var result = await _userRepository.Commit();
                return result > 0;
            }
            catch (Exception)
            {

                throw new InternalServerErrorException("Cannot Create");
            }

        }
        public async Task<TokenModel> GenerateJwtToken(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var expries = DateTime.Now.Add(TimeSpan.Parse(_configuration.GetSection("JwtSettings:ExpiryTimeFrame").Value));
            var handler = new JwtSecurityTokenHandler();


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value));
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid,user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString()),
                    new Claim(ClaimTypes.Role,  user.Role)
        }),
                Expires = expries,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)

            };
            var token = handler.CreateToken(tokenDescription);
            var accessToken = handler.WriteToken(token);
            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                Token = RandomStringGeneration(),
                IssuedAt = DateTime.Now,
                ExpriedAt = DateTime.UtcNow.AddDays(1),
                IsRevoked = false,
                IsUsed = false,
                UserId = user.Id

            };
            await _refreshTokenRepository.AddAsync(refreshToken);
            await _refreshTokenRepository.Commit();
            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
            public async Task<LoginResponseModel> VerifyAndGenerateToken(TokenModel token)
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    //_tokenValidationParameters.ValidateLifetime = false;
                    var tokenVerification = jwtTokenHandler.ValidateToken(token.AccessToken, _tokenValidationParameters, out var validatedToken);
                    if (validatedToken is JwtSecurityToken jwtToken)
                    {
                        var result = jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                        if (result == false)

                            return null;

                    }
                    var utcExpiryDate = long.Parse(tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                    var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);
                    if (expiryDate > DateTime.Now)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Token is not expired yet"
                        };
                    }
                else
                {
                    return new LoginResponseModel
                    {
                        Success = false,
                        Message = "Token has expired"
                    };
                }
                var storedToken = await _refreshTokenRepository.FindByCondition(x => x.Token == token.RefreshToken).FirstOrDefaultAsync();
                    if (storedToken == null)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Refresh token does not exist"
                        };
                    }
                    if (storedToken.IsUsed)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Refresh token has been used"
                        };
                    }
                    if (storedToken.IsRevoked)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Refresh token has been revoked"
                        };
                    }
                    var jti = tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                    if (storedToken.JwtId != jti)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Invalid Token"
                        };
                    }
                    if (storedToken.ExpriedAt < DateTime.UtcNow)
                    {
                        return new LoginResponseModel
                        {
                            Success = false,
                            Message = "Exprired Token"
                        };
                    }
                    storedToken.IsUsed = true;
                    _refreshTokenRepository.Update(storedToken);
                    await _refreshTokenRepository.Commit();
                    var dbUser = await _userRepository.FindByCondition(u => u.Id == storedToken.UserId).FirstOrDefaultAsync();
                    var userModel = _mapper.Map<UserModel>(dbUser);
                    var accessToken = GenerateJwtToken(userModel);
                    return new LoginResponseModel
                    {
                        Success = true,
                        Data = accessToken,
                        Message = "Verify And GenerateToken success"
                    };
                }
                catch (Exception ex)
                {
                var storedToken = await _refreshTokenRepository.FindByCondition(x => x.Token == token.RefreshToken).FirstOrDefaultAsync();
                storedToken.IsUsed = true;
                _refreshTokenRepository.Update(storedToken);
                await _refreshTokenRepository.Commit();
                var dbUser = await _userRepository.FindByCondition(u => u.Id == storedToken.UserId).FirstOrDefaultAsync();
                var userModel = _mapper.Map<UserModel>(dbUser);
                var accessToken = GenerateJwtToken(userModel);
                return new LoginResponseModel
                {
                    Success = true,
                    Data = accessToken,
                    Message = "Verify And GenerateToken success"
                };
            }

            }

        private DateTime UnixTimeStampToDateTime(long utcExpiryDate)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(utcExpiryDate).ToLocalTime();
            return dateTimeVal;
        }

        private string RandomStringGeneration()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

    }
}

