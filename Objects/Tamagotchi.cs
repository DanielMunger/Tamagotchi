using System;
using System.Collections.Generic;

namespace Tamagotchis.Objects
{
    public class Tamagotchi
    {
        private string _name;
        private int _hunger;
        private int _happiness;
        private int _sleep;
        private bool _alive;
        private int _id;
        private static List<Tamagotchi> _instances = new List<Tamagotchi> {};

        public Tamagotchi(string tamaName)
        {
            _name = tamaName;
            _hunger = 5;
            _happiness = 5;
            _sleep = 5;
            _alive = true;
            _instances.Add(this);
            _id = _instances.Count;
        }

        public void SetName(string tamaName)
        {
            _name = tamaName;
        }
        public string GetName()
        {
            return _name;
        }
        public int GetHunger()
        {
            return _hunger;
        }
        public int GetHappiness()
        {
            return _happiness;
        }
        public int GetSleep()
        {
            return _sleep;
        }
        public bool GetAlive()
        {
            return _alive;
        }
        public void Hunger()
        {
            if(_hunger < 5 && _alive)
            {
                _hunger += 1;
            }
        }
        public void Sleep()
        {
            if(_sleep < 5 && _alive)
            {
                _sleep += 1;
            }
        }
        public void Happiness()
        {
            if(_happiness < 5 && _alive)
            {
                _happiness++;
            }
        }
        public void PassTime()
        {
            _hunger -= 1;
            _happiness -= 1;
            _sleep -= 1;
        }
        public void CheckAlive()
        {
            if(_hunger <= 0 || _happiness <= 0 || _sleep <= 0)
            {
                _alive = false;
            }
        }
        public int GetId()
        {
            return _id;
        }
        public static List<Tamagotchi> GetAll()
        {
            return _instances;
        }
        public static Tamagotchi Find(int searchId)
        {
            return _instances[searchId-1];
        }
        public static void RemoveTama(int searchId)
        {
            _instances.RemoveAt(searchId - 1);
        }
    }
}
