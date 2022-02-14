using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBE.Feature.Search.Factories
{
    using CBE.Feature.Search.Models;
    using CBE.Feature.Search.Services;
    using CBE.Foundation.DependencyInjection;
    using CBE.Foundation.Indexing.Models;

    [Service]
    public class SearchResultsViewModelFactory
    {
        public SearchResultsViewModelFactory(FacetQueryStringService facetQueryStringService)
        {
            this.FacetQueryStringService = facetQueryStringService;
        }

        public SearchResultsViewModel Create(IQuery searchQuery, ISearchResults results, int pagesToShow, int resultsOnPage)
        {
            var facets = searchQuery.Facets == null ? null : this.FacetQueryStringService.GetFacetQueryString(searchQuery.Facets);
            return new SearchResultsViewModel
            {
                VisiblePagesCount = pagesToShow,
                TotalResults = results.TotalNumberOfResults,
                ResultsOnPage = resultsOnPage,
                Query = searchQuery.QueryText,
                Facets = facets,
                Results = results,
                Page = searchQuery.Page
            };
        }

        private FacetQueryStringService FacetQueryStringService { get; }
    }
}