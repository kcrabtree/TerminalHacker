using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "homocide", "arrest", "detective", "uniform", "holster", "fingerprint"};

    int currentLevel;
    string password;
    enum State { MainMenu, PasswordEntry, Win};
    State state = State.MainMenu;

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
        } else if (state == State.MainMenu)
        {
            HandleMenuSelection(input);
        } else if (state == State.PasswordEntry)
        {
            CheckPassword(input);
        } else if (state == State.Win)
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
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect password.");
        }
    }

    private void DisplayWinScreen()
    {
        state = State.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (currentLevel)
        {
            case 1:
                Terminal.WriteLine("Clever, eh? Have a book..");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /_______//
(_______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Nice. You could give Sherlock Holmes a run for his money!");
                Terminal.WriteLine(@"
        _,--,            _
   __,-'____| ___      /' |
 /'   `\,--,/'   `\  /'   |
(       )  (       )'
 \_   _/'  `\_   _/
   '''        '''

                ");
                break;
            default:
                Debug.LogError("Unable to display level reward for invalid level: " + currentLevel);
                break;
        }
        
    }

    private void HandleMenuSelection(string input)
    {
        bool isValidLevel = (input == "1" || input == "2");

        if (isValidLevel)
        {
            currentLevel = int.Parse(input);
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
        state = State.PasswordEntry;
        Terminal.ClearScreen();
        switch(currentLevel)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
        Terminal.WriteLine("Enter password. Hint: " + password.Anagram());
    }

    private void DisplayMainMenu()
    {
        state = State.MainMenu;
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
