using System.Web;
using System.Web.Mvc;

namespace DeveloperTest_Fruit_SA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
