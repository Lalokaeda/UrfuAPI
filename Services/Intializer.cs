using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrfuAPI.Implementations;
using UrfuAPI.Implementations;
using UrfuAPI.Interfaces;

namespace UrfuAPI.Services
{
    public static class Intializer
    {
         public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}