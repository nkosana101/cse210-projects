namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; // in km/h

        public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return _speed * (Minutes / 60.0); // distance = speed * time (in hours)
        }

        public override double GetSpeed()
        {
            return _speed; // we already know it!
        }

        public override double GetPace()
        {
            return 60.0 / _speed; // min per km
        }
    }
}