using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrfuAPI.Implementations;
using UrfuAPI.Interfaces;

namespace UrfuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
    private readonly ILogger<ArticleController> _logger;
    private readonly IArticleService _ArticleService;


    public ArticleController(ILogger<ArticleController> logger, IArticleService articleService)
    {
        _logger = logger;
        _ArticleService=articleService;

    }

    [HttpGet("~/GetArticleById")]
    public async Task<IActionResult> GetArticle(int id){
        
        var response = await _ArticleService.GetArticle(id);

             if (response.StatusCode == Enums.StatusCode.OK)
            {
                return Ok(response.Data);
            }

            return NotFound(response.Description);

    }

    [HttpGet("~/GetArticles")]
    public async Task<IActionResult> GetArticles(){
        
        var response = await _ArticleService.GetArticles();

             if (response.StatusCode == Enums.StatusCode.OK)
            {
                return Ok(response.Data);
            }

            return NotFound(response.Description);

    }
    }
}