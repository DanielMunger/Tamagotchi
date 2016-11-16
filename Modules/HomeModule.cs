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
            Get["/tamagotchis"] = _ => {
                List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
                return View["tamagotchis.cshtml", allTamagotchis];
            };
            Get["/tamagotchis/new"] = _ => {
                return View["tamagotchi_form.cshtml"];
            };
            Get["/tamagotchis/{id}"] = parameters => {
                Tamagotchi selectedTama = Tamagotchi.Find(parameters.id);
                return View["tamagotchi.cshtml", selectedTama];
            };
            Post["/tamagotchis"] = _ => {
                string tamaName = Request.Form["tama-name"];
                Tamagotchi newTama = new Tamagotchi(tamaName);
                List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
                return View["tamagotchis.cshtml", allTamagotchis];
            };
        }
    }
}
