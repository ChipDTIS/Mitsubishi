using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NC20.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using NC20.Web.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using NC20.Web.Mappers;

namespace NC20.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ConfigurationHelper Configuration { get; set; }
        protected NC20DBRepository NC20DBRepository { get; private set; }
        public BaseController(NC20DBRepository repository)
        {
            this.NC20DBRepository = repository;
            Configuration = repository.ServiceProvider.GetService<IOptions<ConfigurationHelper>>()?.Value;
        }
        private UserModel currentUser;
        protected UserModel CurrentUser
        {
            get
            {
                if (currentUser != null)
                {
                    string jwt = this.HttpContext.Request.Cookies["auth"];
                    if (string.IsNullOrEmpty(jwt) || jwt == "null") return null;

                    var payloadString = JwtHelper.Decode(jwt);
                    if (string.IsNullOrEmpty(payloadString)) return null;

                    var payload = JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadString);
                    var token = payload["token"];
                    if (string.IsNullOrEmpty(token)) return null;

                    var loginSession = NC20DBRepository.UserLoginTokenRepository.GetAll()
                        .Include("User.UserProfilers.Image")
                        .Include("User.UserRoles.Role")
                        .FirstOrDefault(x => x.Token == token);
                    if (loginSession == null || loginSession.User == null) return null;

                    if (loginSession?.User?.Status == Common.eUserStatus.Deactive) return null;

                    if (loginSession?.ExpiredDated < DateTime.Now) return null;

                    currentUser = Mapper.ToModel(loginSession.User);
                    if (currentUser != null)
                    {
                        currentUser.UserProfiles = loginSession.User.UserProfiles.Select(x =>
                        {
                            var profile = Mapper.ToModel(x);
                            if (profile != null)
                            {
                                profile.Image = Mapper.ToModel(x.Image);
                            }
                            return profile;
                        }).ToList();
                        currentUser.UserRoles = loginSession.User.UserRoles.Select(x =>
                        {
                            var role = Mapper.ToModel(x);
                            if (role != null)
                            {
                                role.Role = Mapper.ToModel(x.Role);
                            }
                            return role;
                        }).ToList();
                    }
                }
                return currentUser;
            }
        }

       
    }
}