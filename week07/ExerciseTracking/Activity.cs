using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        // 1. Private member variables (Encapsulation)
        private DateTime _date;
        private int _minutes;

        // 2. Constructor to set the shared data
        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // 3. Public getters so derived classes can read the private data
        public DateTime Date => _date;
        public int Minutes => _minutes;

        // 4. ABSTRACT methods (no code here yet, we force the children to write the math)
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();
    }
}
        // Virtual so children could change it, but we don't need to.
        public string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
                   $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, " +
                   $"Pace {GetPace():0.0} min per km";
        }