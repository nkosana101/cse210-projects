namespace ExerciseTracking
{
    public class Running : Activity  // <-- Inherits from Activity
    {
        private double _distance; // in km (private)

        
        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        
        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (_distance / Minutes) * 60; // km/h
        }

        public override double GetPace()
        {
            return Minutes / _distance; // min per km
        }
    }
}