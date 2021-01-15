﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "homocide", "locker", "detective", "window", "badge", "fingerprint"};

    int currentLevel;
    string password;
    enum Screen { MainMenu, PasswordEntry, Win};
    Screen state = Screen.MainMenu;

    string[] passwords = new string[] { "book", "shotgun", "satellite" };


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
        } else if (state == Screen.PasswordEntry)
        {
            CheckPassword(input);
        } else if (state == Screen.Win)
        {
            Terminal.WriteLine("Go again?");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinMessage();
        }
        else
        {
            Terminal.WriteLine("Incorrect password, please try again:");
        }
    }

    private void DisplayWinMessage()
    {
        state = Screen.Win;
        Terminal.WriteLine("Access granted. Congratulations!");
    }

    private void HandleMenuSelection(string input)
    {
        if (input == "1")
        {
            currentLevel = 1;
            password = level1Passwords[2]; // todo: make random later
            StartGame();
        }
        else if (input == "2")
        {
            currentLevel = 2;
            password = level2Passwords[4];
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
        Terminal.WriteLine("Please enter password: ");
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
