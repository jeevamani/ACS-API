using Interview.Interface;
using Interview.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Service
{
    public class AuthenticateService : IAuthentication
    {
		AppSettings _appSettings;
		public AuthenticateService(IOptions<AppSettings> appsettings)
		{
			_appSettings = appsettings.Value;
		}
        public UserCred Authenticate(UserCred userCred)
        {
			try
			{
				UserCred users = new UserCred();
				if (userCred.IsSuperAdmin == true)
				{
					using (DB_A3E3FF_scampusMaster2020Context db = new DB_A3E3FF_scampusMaster2020Context())
					{
						var user = db.InUsers.Where(x => x.Username == userCred.Username && x.Password == userCred.Password && x.IsActive == true).FirstOrDefault();
						//if user not found
						if (user == null)
						{
							return null;
						} else {

							//if user found
							var confdata = db.ConfigurationMaster.Where(x => x.ConfigId.ToString() == user.Configuration.ToString() && x.BaseUrl == userCred.BaseUrl && x.IsActive == true).FirstOrDefault();
							if(confdata != null) { 
							var tokenHandler = new JwtSecurityTokenHandler();
						var key = Encoding.ASCII.GetBytes(_appSettings.Key);

								var tokenDescriptor = new SecurityTokenDescriptor
								{
									Subject = new ClaimsIdentity(new Claim[] {
										new Claim(ClaimTypes.Name, user.Username),
										new Claim(ClaimTypes.Role, user.Role),
										new Claim(ClaimTypes.Version, "3.1")
									}),
									Expires = DateTime.UtcNow.AddMinutes(15),
									SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
						};
						var token = tokenHandler.CreateToken(tokenDescriptor);
						users.Token = tokenHandler.WriteToken(token);
						users.Role = user.Role;
						users.userId = user.Id;
						users.ConfigId = user.Configuration;
						users.BaseUrl = user.BaseUrl;
							} else
							{
								return null;
							}
						}

					}
				} else
				{
					List<ConfigurationMaster> configurationMaster = new DB_A3E3FF_scampusMaster2020Context().ConfigurationMaster.Where(x => x.IsActive == true).ToList();
					using (DB_A3E3FF_scampus2020Context db1 = new DB_A3E3FF_scampus2020Context())
					{
						var user = db1.AdminUsers.Where(x => x.Username == userCred.Username && x.Password == userCred.Password &&  x.Status == true).FirstOrDefault();
						//if user not found
						if (user == null)
						{
							return null;
						}
						else
						{
							var confiData = configurationMaster.Where(x => x.ConfigId == user.ConfigSettings &&x.BaseUrl == userCred.BaseUrl && x.IsActive == true).FirstOrDefault();
							//if user found
							if (confiData != null)
							{
								var tokenHandler = new JwtSecurityTokenHandler();
								var key = Encoding.ASCII.GetBytes(_appSettings.Key);

								var tokenDescriptor = new SecurityTokenDescriptor
								{
									Subject = new ClaimsIdentity(new Claim[] {
							new Claim(ClaimTypes.Name, user.Username),
							new Claim(ClaimTypes.Role, user.Role),
							new Claim(ClaimTypes.Version, "3.1")
								}),
									Expires = DateTime.UtcNow.AddMinutes(15),
									SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
								};
								var token = tokenHandler.CreateToken(tokenDescriptor);
								users.Token = tokenHandler.WriteToken(token);
								users.Role = user.Role;
								users.userId = user.Userid;

								users.BaseUrl = user.Baseurl;
								users.ConfigId = user.ConfigSettings;
							} else
							{
								return null;
							}
						}
						return users;
					}
				}
				return users;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
