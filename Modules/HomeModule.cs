using Nancy;
using System.Collections.Generic;
using Tamagotchi.Objects;

namespace Tamagotchi
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };
        }
    }
}
