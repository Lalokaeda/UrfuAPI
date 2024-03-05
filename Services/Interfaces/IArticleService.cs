using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrfuAPI.Models;

namespace UrfuAPI.Interfaces
{
    public interface IArticleService
    {
        Task<IBaseResponse<Article>> GetArticle(int Id);
        Task<IBaseResponse<List<Article>>> GetArticles();
    }
}