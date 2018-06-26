using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using FSBetTest.Models;
using FSBetTest.Controllers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FSBetTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<BetsDB>(new BetsInitializer());


            RootObject MyRez = tryToFetch();

            string b = "bojan-";
        }

        public RootObject tryToFetch()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.fifa.com/api/v1/calendar/matches");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            RootObject rootObject = null;
            HttpResponseMessage response = client.GetAsync($"?idseason=254645&idcompetition=17&language=en-GB&count=1").Result;

            if (response.IsSuccessStatusCode)
            {
                rootObject = response.Content.ReadAsAsync<RootObject>().Result;
            } else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return rootObject;
        }
    }
}
