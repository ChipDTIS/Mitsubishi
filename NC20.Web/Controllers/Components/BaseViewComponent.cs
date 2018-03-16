using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NC20.Repository;
using NC20.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC20.Web.Controllers.Components
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected NC20DBRepository NC20DBRepository { get; private set; }
        public BaseViewComponent(NC20DBRepository repository)
        {
            this.NC20DBRepository = repository;
        }
        private UserModel currentUser;

        protected UserModel CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    string jwt = this.HttpContext.Request.Cookies["auth"];

                    if (string.IsNullOrEmpty(jwt) || jwt == "null") return null;

                    var payloadString = JwtHelper.Decode(jwt);

                    if (string.IsNullOrEmpty(payloadString)) return null;

                    var payLoad = JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadString);
                    var token = payLoad["token"];
                    if (string.IsNullOrEmpty(token)) return null;

                    var loginSession = NC20DBRepository.UserLoginTokenRepository.GetAll()
                        .Include("User.UserProfiles.Image")
                        .FirstOrDefault(x => x.Token == token);
                    if (loginSession == null || loginSession.User == null) return null;
                    currentUser = Mappers.Mapper.ToModel(loginSession.User);
                    if (currentUser != null)
                    {
                        currentUser.UserProfiles = loginSession.User.UserProfiles.Select(x =>
                        {
                            var profile = Mappers.Mapper.ToModel(x);
                            if (profile != null)
                            {
                                profile.Image = Mappers.Mapper.ToModel(x.Image);
                            }
                            return profile;
                        }).ToList();
                    }
                }
                return currentUser;
            }
        }
        public abstract Task<IViewComponentResult> InvokeAsync(string parameters, string queryParams = null);
    }
}
