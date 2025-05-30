using System;
using System.Collections.Generic;

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
