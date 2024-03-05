using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrfuAPI.Enums;
using UrfuAPI.Interfaces;
using UrfuAPI.Models;

namespace UrfuAPI.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly UrfuBaseContext _DBcontext;

        public ArticleService(UrfuBaseContext dBcontext)
        {
            _DBcontext = dBcontext;
        }
        public async Task<IBaseResponse<Article>> GetArticle(int Id)
        {
             var baseResponse=new BaseResponse<Article>{
                Data= new Article()
            };
            try
            {
                 baseResponse.Data = await _DBcontext.Articles.Where(x => x.Id == Id).FirstOrDefaultAsync();
                 if (baseResponse==null)
                 {
                    baseResponse.Description="Найдено 0 элементов";
                    baseResponse.Data=new Article();
                    baseResponse.StatusCode=StatusCode.NotFound;
                    return baseResponse;
                 }
                 
            }
            catch(Exception ex)
            {
                return new BaseResponse<Article>{
                    Description="[GetArticle] : "+ ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
                baseResponse.StatusCode=StatusCode.OK;
                return baseResponse;
        }
        

        public async Task<IBaseResponse<List<Article>>> GetArticles()
        {
            var baseResponse=new BaseResponse<List<Article>>{
                Data= new List<Article>()
            };
            try
            {
                 baseResponse.Data = await _DBcontext.Articles.ToListAsync();
                 if (baseResponse==null)
                 {
                    baseResponse.Description="Найдено 0 элементов";
                    baseResponse.Data= new List<Article>();
                    baseResponse.StatusCode=StatusCode.NotFound;
                    return baseResponse;
                 }
                 
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<Article>>{
                    Description="[GetArticles] : "+ ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
                baseResponse.StatusCode=StatusCode.OK;
                return baseResponse;
        }
        }
    }
