using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity beyond the core requirements: the program uses a small library of scriptures
        // and randomly selects one each run to make practice more varied and engaging.
        string[] scriptures =
        {
            "John 3:16 For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.",
            "Proverbs 3:5-6 Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.",
            "Philippians 4:13 I can do all things through Christ who strengthens me.",
            "1 Nephi 3:7 And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he hath commanded them."
        };

        Random random = new Random();
        string selectedScripture = scriptures[random.Next(scriptures.Length)];

        string[] words = selectedScripture.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> referenceTokens = new List<string>();
        int index = 0;

        while (index < words.Length && !words[index].Contains(":"))
        {
            referenceTokens.Add(words[index]);
            index++;
        }

        if (index < words.Length)
        {
            referenceTokens.Add(words[index]);
            index++;
        }

        string referenceText = string.Join(" ", referenceTokens);
        string text = "";
        for (int i = index; i < words.Length; i++)
        {
            if (i > index)
            {
                text += " ";
            }

            text += words[i];
        }

        string[] referenceParts = referenceText.Split(' ');
        Reference reference;

        if (referenceParts.Length >= 2)
        {
            string book = "";
            for (int i = 0; i < referenceParts.Length - 1; i++)
            {
                if (i > 0)
                {
                    book += " ";
                }

                book += referenceParts[i];
            }

            string verseToken = referenceParts[referenceParts.Length - 1];
            string[] verseParts = verseToken.Split(':');
            int chapter = int.Parse(verseParts[0]);

            if (verseParts[1].Contains("-"))
            {
                string[] verseRange = verseParts[1].Split('-');
                int startVerse = int.Parse(verseRange[0]);
                int endVerse = int.Parse(verseRange[1]);
                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(verseParts[1]);
                reference = new Reference(book, chapter, verse);
            }
        }
        else
        {
            reference = new Reference("Unknown", 0, 0);
        }

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}