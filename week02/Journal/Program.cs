/*
 * Creativity/Exceeding Requirements:
 * 1. Mood tracking: Users rate their mood from 1-5 when writing an entry,
 *    and the mood is displayed as a label (Terrible/Bad/Okay/Good/Great).
 * 2. Proper CSV saving/loading: The program correctly handles commas and
 *    quotation marks in entry content, allowing the journal file to be
 *    opened directly in Excel or other spreadsheet applications.
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Console.Write("Rate your mood (1-Terrible, 2-Bad, 3-Okay, 4-Good, 5-Great): ");
                int mood = int.Parse(Console.ReadLine());

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);
                Console.WriteLine("Entry added.\n");
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename to load: ");
                string loadFile = Console.ReadLine();
                journal.LoadFromFile(loadFile);
            }
        } while (choice != 5);
    }
}
