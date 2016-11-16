using System.Collections.Generic;

namespace Tamagotchi.Objects
{
    public class Tamagotchi
    {
        private string _name;
        private int _hunger;
        private int _attention;
        private int _sleep;
        private bool _alive;
        private int _id;
        private List<Tamagotchi> _instances = new List<Tamagotchi> {};

        private Tamagotchi(string tamaName)
        {
            _name = tamaName;
            _hunger = 5;
            _attention = 5;
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
            if(_hunger<5)
            {
                _hunger += 1;
            }
        }
        public void Sleep()
        {
            if(_sleep < 5)
            {
                _sleep += 1;
            }
        }
        public void Attention()
        {
            if(_attention < 5)
            {
                _attention++;
            }
        }
    }
}
