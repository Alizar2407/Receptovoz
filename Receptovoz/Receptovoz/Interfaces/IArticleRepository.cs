using Receptovoz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receptovoz.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> allArticles { get; }

        Article getArticle(int id);
    }
}
