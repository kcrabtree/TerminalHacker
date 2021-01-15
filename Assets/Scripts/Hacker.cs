using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int currentLevel;
    enum Screen { MainMenu, PasswordEntry, Win};
    Screen state;

    // Start is called before the first frame update
    void Start()
    {
        DisplayMainMenu();
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            DisplayMainMenu();
        } else if (state == Screen.MainMenu)
        {
            HandleMenuSelection(input);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("current state: " + state);
    }

    private void HandleMenuSelection(string input)
    {
        if (input == "1")
        {
            currentLevel = 1;
            StartGame();
        }
        else if (input == "2")
        {
            currentLevel = 2;
            StartGame();
        }
        else if (input == "3")
        {
            currentLevel = 3;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }


    private void StartGame()
    {
        state = Screen.PasswordEntry;
        Terminal.WriteLine("You have selected level " + currentLevel);
        Terminal.WriteLine("Please enter your password: ");
    }

    private void DisplayMainMenu()
    {
        state = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Who are you targeting today?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for NASA.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }
}
