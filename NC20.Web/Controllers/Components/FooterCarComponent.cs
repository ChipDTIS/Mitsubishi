using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NC20.Repository;
using NC20.Web.Models;

namespace NC20.Web.Controllers.Components
{
    public class FooterCarComponent : BaseViewComponent
    {
        public FooterCarComponent(NC20DBRepository repository) : base(repository)
        {
        }

        public override async Task<IViewComponentResult> InvokeAsync(string parameters, string queryParams = null)
        {
            var viewmodel = GetHeaderCars();
            return View(viewmodel);
        }
        public List<HeaderCarModel> GetHeaderCars()
        {
            return new List<HeaderCarModel>()
            {
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/mirage.png")
                    },
                    Price = "Giá đặc biệt từ 370 triệu đồng",
                    Title = "Mirage"
                },
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/attrage.png")
                    },
                    Price = "Giá đặc biệt từ 410 triệu đồng",
                    Title = "Attrage"
                },
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/outlander.png")
                    },
                    Price = "Giá đặc biệt từ 808 triệu đồng",
                    Title = "Outlander"
                },
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/new-pajero-sport.png")
                    },
                    Price = "Giá đặc biệt từ 1.260 tỉ đồng",
                    Title = "All New Pajero Sport"
                },
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/triton.png")
                    },
                    Price = "Giá đặc biệt từ 576 triệu đồng",
                    Title = "Triton"
                },
                new HeaderCarModel()
                {
                    Id = 1,
                    Image = new ImageModel()
                    {
                        Id = 1,
                        Url = Path.Combine(ConfigurationHelper.RootPath, "uploads/2017/05/pajero.png")
                    },
                    Price = "Giá đặc biệt từ 1.956 tỉ đồng",
                    Title = "Pajero"
                }
            };
        }
    }
}
