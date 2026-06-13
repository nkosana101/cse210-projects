namespace Shapes
{
    public class Shape
    {
        // Member variable for color
        private string _color;

        // Constructor
        public Shape(string color)
        {
            _color = color;
        }

        // Getter and Setter for color
        public string GetColor()
        {
            return _color;
        }

        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual method – can be overridden by derived classes
        public virtual double GetArea()
        {
            return 0; // default, though we expect override
        }
    }
}