using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Day3Demos.MyControls
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Dictionary<string,string> urlNames)
        {
            Dictionary<string, string> data = GetNavigationUrlLinks(urlNames);
            return View(data);
        }

        private Dictionary<string, string> GetNavigationUrlLinks(Dictionary<string, string> names)
        {
            Dictionary<string, string> urlList = new Dictionary<string, string>();
            foreach (var item in names)
            {
                urlList.Add(item.Key,item.Value);
            }
            return urlList;
        }
    }
}
