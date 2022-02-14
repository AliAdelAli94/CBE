namespace CBE.Feature.Person.Controllers
{
    using System.Web.Mvc;
    using CBE.Feature.Person.Repositories;
    using CBE.Foundation.SiteExtensions.Extensions;
    using Sitecore.Mvc.Presentation;

    public class PersonController : Controller
    {
        private readonly PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public ActionResult EmployeesList()
        {
            var items = this.personRepository.Get(RenderingContext.Current.Rendering.Item);
            return this.View(items);
        }

        public ActionResult EmployeesCarousel()
        {
            var items = this.personRepository.Get(RenderingContext.Current.Rendering.Item);
            return this.View(items);
        }
    }
}