using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBE.Feature.Language.Repositories
{
    using CBE.Feature.Language.Models;

    public interface ILanguageRepository
    {
        Language GetActive();
        IEnumerable<Language> GetSupportedLanguages();
    }
}
