using System.Collections.Generic;

namespace Tamagotchi.Objects
{
    public class Tamagotchi
    {
        private string _name;
        private int _hunger;
        private int happiness;
        private int _sleep;
        private bool _alive;
        private int _id;
        private List<Tamagotchi> _instances = new List<Tamagotchi> {};

        private Tamagotchi(string tamaName)
        {
            _name = tamaName;
            _hunger = 5;
            happiness = 5;
            _sleep = 5;
            _alive = true;
            _instances.Add(this);
            _id = _instances.Count;
        }

        private void SetName(string tamaName)
        {
            _name = tamaName;
        }
        public string GetName()
        {
            return _name;
        }
        public void Feed()
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
            if(happiness < 5 && _alive)
            {
                happiness++;
            }
        }
        public void CheckAlive()
        {
            if(_hunger <= 0, _happiness <= 0, _sleep <= 0)
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
        public static Tamagotchi Find(searchId)
        {
            return _instances[searchId-1];
        }
    }
}
