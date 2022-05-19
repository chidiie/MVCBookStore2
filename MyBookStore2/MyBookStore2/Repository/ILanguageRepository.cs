using MyBookStore2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookStore2.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}