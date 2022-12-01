using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApplication.Settings;

namespace StoreViewerApplication.Pages
{
    public class IndexModel : PageModel
    {
        public List<Store> Stores { get; }
        public AppDisplaySettings AppSettings { get; }

        public IndexModel(IConfiguration config)
        {
            AppSettings = new AppDisplaySettings()
            {
                AppTitle = config["HomePageSettings:Title"],
                ShowCopyright = bool.Parse(
                    config["HomePageSettings:ShowCopyright"])
            };
        }
        
        //public IndexModel(
        //    IOptions<List<Store>> stores,
        //    IOptions<AppDisplaySettings> appSettings
        //    )
        //{
        //    Stores = stores.Value;
        //    AppSettings = appSettings.Value;
        //}


        public void OnGet()
        {

        }
    }
}
