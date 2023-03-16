
using Receptovoz.Models;
using Receptovoz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Receptovoz.Interfaces;

namespace Receptovoz.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDBContent appDBContent;

        public ArticleRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Article> allArticles => this.appDBContent.Article.ToArray();

        public Article getArticle(int id) => this.appDBContent.Article.FirstOrDefault(a => a.id == id);
    }
}
