using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InmovestAPI.Domain.Models;
using InmovestAPI.Domain.Repositories;
using InmovestAPI.Domain.Services;
using InmovestAPI.Domain.Services.Communication;

namespace InmovestAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IArticleRepository articleRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await _articleRepository.ListAsync();
        }

        public async Task<IEnumerable<Article>> ListByProjectIdAsync(int projectId)
        {
            return await _articleRepository.FindByProjectId(projectId);
        }

        public async Task<ArticleResponse> SaveAsync(Article article)
        {
            //VALIDATE PROJECTID
            
            var existingProject = _projectRepository.FindByIdAsync(article.ProjectId);

            if (existingProject == null)
                return new ArticleResponse("Invalid Project.");

            //Validate Name
            var existingArticleWithName = await _articleRepository.FindByNameAsync(article.Body);

            if (existingArticleWithName != null)
                return new ArticleResponse("Article name already exist.");

            try
            {
                await _articleRepository.AddAsync(article);
                await _unitOfWork.CompleteAsync();

                return new ArticleResponse(article);
            }
            catch (Exception e)
            {
                return new ArticleResponse($"An error occurred while saving the article: {e.Message}");
            }
        }

        public async Task<ArticleResponse> UpdateAsync(int id, Article article)
        {
            //VALIDATE ARTICLEID
            
            var existingArticle = await _articleRepository.FindByIdAsync(id);

            if (existingArticle == null)
                return new ArticleResponse("Article not found.");
            
            //VALIDATE PROJECTID
            
            var existingProject = _projectRepository.FindByIdAsync(article.ProjectId);

            if (existingProject == null)
                return new ArticleResponse("Invalid Project.");
            
            //Validate Name
            var existingArticleWithName = await _articleRepository.FindByNameAsync(article.Body);

            if (existingArticleWithName != null)
                return new ArticleResponse("Article name already exist.");

            existingArticle.Body = article.Body;
            existingArticle.ProjectId = article.ProjectId;
            
            try
            {
                _articleRepository.Update(existingArticle);
                await _unitOfWork.CompleteAsync();
                
                return new ArticleResponse(existingArticle);
            }
            catch (Exception e)
            {
                return new ArticleResponse($"An error occurred while updating the article: {e.Message}");

            }

        }

        public async Task<ArticleResponse> DeleteAsync(int id)
        {
            // VALIDATE ARTICLEID
            
            var existingArticle = await _articleRepository.FindByIdAsync(id);

            if (existingArticle == null)
                return new ArticleResponse("Article not found.");

            try
            {
                _articleRepository.Remove(existingArticle);
                await _unitOfWork.CompleteAsync();
                
                return new ArticleResponse(existingArticle);
            }
            catch (Exception e)
            {
                return new ArticleResponse($"An error occurred while deleting the article: {e.Message}");

            }
        }
    }
}