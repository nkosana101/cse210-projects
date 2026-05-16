namespace JournalProgram
{
    public class Entry
    {
        public string _date;
        public string _promptText;
        public string _entryText;

        public Entry(string date, string prompt, string response)
        {
            _date = date;
            _promptText = prompt;
            _entryText = response;
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_promptText}");
            Console.WriteLine($"Response: {_entryText}");
            Console.WriteLine();
        }

        // For saving to file (formatted with separator)
        public string GetFileRepresentation()
        {
            return $"{_date}|{_promptText}|{_entryText}";
        }
    }
}