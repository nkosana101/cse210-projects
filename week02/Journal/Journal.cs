using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        public List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }

        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries yet.\n");
                return;
            }
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.GetFileRepresentation());
                }
            }
            Console.WriteLine($"Journal saved to {filename}\n");
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    Entry entry = new Entry(date, prompt, response);
                    loadedEntries.Add(entry);
                }
            }
            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename} ({_entries.Count} entries)\n");
        }
    }
}