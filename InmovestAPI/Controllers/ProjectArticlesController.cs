using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Services;
using InmovestAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace InmovestAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/projects/{projectId}/articles")]
    public class ProjectArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;  

        public ProjectArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Articles By Project",
            Description = "Get All Articles for a given ProjectID",
            Tags = new[] {"Project"}
        )]
        [HttpGet]
        public async Task<IEnumerable<ArticleResource>> GetAllByProjectIdAsync(int projectId)
        {
            var articles = await _articleService.ListByProjectIdAsync(projectId);
            var resources = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleResource>>(articles);

            return resources;
        }
    }
}