using Nancy;
using System;
using System.Collections.Generic;
using Tamagotchis.Objects;

namespace Tamagotchis
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
            Post["/tamagotchis/{id}"] = parameters => {
                string whichButton = Request.Form["which-button"];
                Tamagotchi selectedTama = Tamagotchi.Find(parameters.id);
                if(whichButton == "remove")
                {
                    Tamagotchi.RemoveTama(parameters.id);
                    List<Tamagotchi> allTamagotchis = Tamagotchi.GetAll();
                    return View["tamagotchis.cshtml", allTamagotchis];
                }
                else
                {
                    selectedTama.PassTime();
                    if(whichButton == "hunger")
                    {
                        selectedTama.Hunger();
                    }
                    else if(whichButton == "happiness")
                    {
                        selectedTama.Happiness();
                    }
                    else if(whichButton == "sleep")
                    {
                        selectedTama.Sleep();
                    }
                    selectedTama.CheckAlive();
                    return View["tamagotchi.cshtml", selectedTama];
                }
            };
        }
    }
}
