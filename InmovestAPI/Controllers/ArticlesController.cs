using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Extensions;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Articles",
            Description = "Get All Articles already stored",
            Tags = new[] { "Articles" }
         )]
        [HttpGet]
        public async Task<IEnumerable<ArticleResource>> GetAllAsync()
        {
            var articles = await _articleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return resources;
        }

        [SwaggerOperation(
            Summary = "Post a Article",
            Description = "Post a Article to the database",
            Tags = new[] { "Articles" }
         )]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var article = _mapper.Map<SaveArticleResource, Article>(resource);

            var result = await _articleService.SaveAsync(article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Resource);

            return Ok(articleResource);
        }

        [SwaggerOperation(
            Summary = "Delete a Article",
            Description = "Delete a Article in the database",
            Tags = new[] { "Articles" }
         )]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _articleService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Resource);

            return Ok(articleResource);
        }

        [SwaggerOperation(
            Summary = "Update a Article",
            Description = "Update a Article in the database",
            Tags = new[] { "Articles" }
         )]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());
            var article = _mapper.Map<SaveArticleResource, Article>(resource);

            var result = await _articleService.UpdateAsync(id, article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleResource = _mapper.Map<Article, ArticleResource>(result.Resource);

            return Ok(articleResource);
        }
        
    }
}