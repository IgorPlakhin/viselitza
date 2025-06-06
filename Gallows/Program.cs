using System;
using System.Collections.Generic;
using System.IO;

public class WordLoader
{
    private List<string> words = new List<string>();
    private Random random = new Random();

    public WordLoader(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                var lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    var trimmed = line.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                        words.Add(trimmed);
                }
            }
            else
            {
                Console.WriteLine($"Файл {filename} не найден. Используйте встроенный список слов.");
                // Можно добавить встроенный список по умолчанию
                words = new List<string> { "APPLE", "ORANGE", "BANANA", "GRAPE" };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            // Встроенный список
            words = new List<string> { "APPLE", "ORANGE", "BANANA", "GRAPE" };
        }
    }

    public string GetRandomWord()
    {
        if (words.Count == 0)
            return null;
        int index = random.Next(words.Count);
        return words[index].ToUpper();
    }
}

public class Game
{
    public string Word { get; private set; }
    public HashSet<char> GuessedLetters { get; private set; } = new HashSet<char>();
    public int Errors { get; private set; } = 0;
    public int MaxErrors { get; private set; } = 6;

    public Game(string word)
    {
        Word = word.ToUpper();
        GuessedLetters.Clear();
        Errors = 0;
    }

    public bool CheckLetter(char letter)
    {
        letter = Char.ToUpper(letter);
        if (GuessedLetters.Contains(letter))
            return false; // уже угадывали

        GuessedLetters.Add(letter);

        if (!Word.Contains(letter))
        {
            Errors++;
            return false;
        }
        return true;
    }

    public bool IsWin()
    {
        foreach (var ch in Word)
        {
            if (!GuessedLetters.Contains(ch))
                return false;
        }
        return true;
    }

    public bool IsLose()
    {
        return Errors >= MaxErrors;
    }

    public void Reset(string newWord)
    {
        Word = newWord.ToUpper();
        GuessedLetters.Clear();
        Errors = 0;
    }
}
public class ConsoleUI
{
    private static readonly string[] HangmanStages = new string[]
    {
        @"
  +---+
      |
      |
      |
     ===",
        @"
  +---+
  O   |
      |
      |
     ===",
        @"
  +---+
  O   |
  |   |
      |
     ===",
        @"
  +---+
  O   |
 /|   |
      |
     ===",
        @"
  +---+
  O   |
 /|\  |
      |
     ===",
        @"
  +---+
  O   |
 /|\  |
 /    |
     ===",
        @"
  +---+
  O   |
 /|\  |
 / \  |
     ==="
    };

    public static void DrawHangman(int errors)
    {
        Console.WriteLine(HangmanStages[errors]);
    }

    public static void DisplayWord(string word, HashSet<char> guessedLetters)
    {
        foreach (var ch in word)
        {
            if (guessedLetters.Contains(ch))
                Console.Write(ch + " ");
            else
                Console.Write("_ ");
        }
        Console.WriteLine();
    }

    public static char? GetInput(HashSet<char> guessedLetters)
    {
        Console.Write("Введите букву: ");
        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || input.Length != 1)
        {
            Console.WriteLine("Пожалуйста, введите одну букву.");
            return null;
        }

        char letter = Char.ToUpper(input[0]);
        if (!Char.IsLetter(letter))
        {
            Console.WriteLine("Пожалуйста, введите букву.");
            return null;
        }

        if (guessedLetters.Contains(letter))
        {
            Console.WriteLine("Эта буква уже была угадана.");
            return null;
        }

        return letter;
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
class Program
{
    static void Main(string[] args)
    {
        string filename = "words.txt";
        var loader = new WordLoader(filename);
        var word = loader.GetRandomWord();

        var game = new Game(word);

        while (true)
        {
            Console.Clear();
            ConsoleUI.DrawHangman(game.Errors);
            ConsoleUI.DisplayWord(game.Word, game.GuessedLetters);
            var input = ConsoleUI.GetInput(game.GuessedLetters);

            if (input == null)
                continue;

            bool correct = game.CheckLetter(input.Value);

            if (game.IsWin())
            {
                Console.Clear();
                ConsoleUI.DrawHangman(game.Errors);
                ConsoleUI.DisplayWord(game.Word, game.GuessedLetters);
                ConsoleUI.ShowMessage("Поздравляем! Вы выиграли!");
                break;
            }
            else if (game.IsLose())
            {
                Console.Clear();
                ConsoleUI.DrawHangman(game.Errors);
                ConsoleUI.DisplayWord(game.Word, game.GuessedLetters);
                ConsoleUI.ShowMessage($"Вы проиграли! Загаданное слово: {game.Word}");
                break;
            }
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}