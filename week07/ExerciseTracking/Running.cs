namespace ExerciseTracking
{
    public class Running : Activity  // <-- Inherits from Activity
    {
        private double _distance; // in km (private)

        // Constructor: passes date/minutes to the BASE, and keeps distance here
        public Running(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        // Override the math using the formulas from the spec
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