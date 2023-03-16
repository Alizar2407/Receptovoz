using Microsoft.AspNetCore.Mvc;
using Receptovoz.Data.Repository;
using Receptovoz.Interfaces;
using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Controllers
{
    public class NewsController : Controller
    {
        private readonly IArticleRepository _articles;

        public NewsController(IArticleRepository iArticleRepository)
        {
            this._articles = iArticleRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Article> articles = _articles.allArticles;
            return View(articles);
        }
    }
}
