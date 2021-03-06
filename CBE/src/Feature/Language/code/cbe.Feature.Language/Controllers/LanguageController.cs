using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Language.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Sitecore.Abstractions;
    using CBE.Feature.Language.Infrastructure.Pipelines;
    using CBE.Feature.Language.Models;
    using CBE.Feature.Language.Repositories;
    using CBE.Foundation.SiteExtensions.Attributes;
    using Sitecore.Pipelines;

    public class LanguageController : Controller
    {
        public const string ChangeLanguagePipeline = "language.changeLanguage";

        private ILanguageRepository LanguageRepository { get; }
        private BaseCorePipelineManager PipelineManager { get; }

        public LanguageController(ILanguageRepository languageRepository, BaseCorePipelineManager pipelineManager)
        {
            this.LanguageRepository = languageRepository;
            this.PipelineManager = pipelineManager;
        }

        [HttpPost]
        [SkipAnalyticsTracking]
        public JsonResult ChangeLanguage(string newLanguage, string currentLanguage)
        {
            var args = new ChangeLanguagePipelineArgs(currentLanguage, newLanguage);
            this.PipelineManager.Run(ChangeLanguagePipeline, args, false);

            return new JsonResult {Data = args.CustomData};
        }

        public ActionResult LanguageSelector()
        {
            var model = new LanguageSelector
            {
                ActiveLanguage = this.LanguageRepository.GetActive(),
                SupportedLanguages = this.LanguageRepository.GetSupportedLanguages().ToList()
            };
            return this.View(model);
        }
    }
}