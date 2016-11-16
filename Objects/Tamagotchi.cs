using Nancy;
using System;
using System.Collections.Generic;
using System.Timers;

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
        private static System.Timers.Timer aTimer;
        private static List<Tamagotchi> _instances = new List<Tamagotchi> {};

        public Tamagotchi(string tamaName)
        {
            SetTimer();

            _name = tamaName;
            _hunger = 20;
            _happiness = 20;
            _sleep = 20;
            _alive = true;
            _instances.Add(this);
            _id = _instances.Count;
        }

        private static void SetTimer()
        {
           // Create a timer with a two second interval.
           aTimer = new System.Timers.Timer(10000);
           // Hook up the Elapsed event for the timer.
           aTimer.Elapsed += OnTimedEvent;
           aTimer.AutoReset = true;
           aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime);
            // Console.WriteLine("Timer started event");
            foreach(Tamagotchi tama in _instances)
            {
                tama.PassTime();
                tama.CheckAlive();
            }
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
            if(_hunger < 20 && _alive)
            {
                _hunger++;
            }
        }
        public void Sleep()
        {
            if(_sleep < 20 && _alive)
            {
                _sleep++;
            }
        }
        public void Happiness()
        {
            if(_happiness < 20 && _alive)
            {
                _happiness++;
            }
        }
        public void PassTime()
        {
            if(_hunger > 0 || _happiness > 0 || _sleep > 0)
            {
                _hunger--;
                _happiness--;
                _sleep--;
            }
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
