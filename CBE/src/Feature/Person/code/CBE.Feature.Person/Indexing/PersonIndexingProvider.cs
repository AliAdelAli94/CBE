namespace CBE.Feature.Person.Indexing
{
    using System;
    using System.Collections.Generic;
    using System.Configuration.Provider;
    using System.Linq.Expressions;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using CBE.Foundation.Dictionary.Repositories;
    using CBE.Foundation.Indexing.Infrastructure;
    using CBE.Foundation.Indexing.Models;
    using Sitecore.Web.UI.WebControls;

    public class PersonIndexingProvider : ProviderBase, ISearchResultFormatter, IQueryPredicateProvider
    {
        public Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
        {
            var fieldNames = new[]
            {
                Templates.Person.Fields.Title_FieldName, Templates.Person.Fields.Summary_FieldName, Templates.Person.Fields.Name_FieldName, Templates.Employee.Fields.Biography_FieldName
            };
            return GetFreeTextPredicateService.GetFreeTextPredicate(fieldNames, query);
        }

        public string ContentType => DictionaryPhraseRepository.Current.Get("/Person/Search/Content Type", "Employee");

        public IEnumerable<ID> SupportedTemplates => new[]
        {
            Templates.Employee.ID
        };

        public void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
            formattedResult.Title = FieldRenderer.Render(contentItem, Templates.Person.Fields.Name.ToString());
            formattedResult.Description = FieldRenderer.Render(contentItem, Templates.Person.Fields.Summary.ToString());
            formattedResult.Media = ((ImageField)contentItem.Fields[Templates.Person.Fields.Picture])?.MediaItem;
            formattedResult.ViewName = "~/Views/Person/EmployeeSearchResult.cshtml";
        }
    }
}