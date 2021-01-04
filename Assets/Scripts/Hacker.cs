using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string user = "Keith";
        DisplayMainMenu(user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayMainMenu(string user = null)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(GenerateGreeting(user));
        Terminal.WriteLine("Who are you targeting today?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the police station.");
        Terminal.WriteLine("Press 3 for NASA.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    private string GenerateGreeting(string user = null)
    {
        string greeting = "Hello ";
        greeting += user == null ?  "Anonymous." : user + "!";

        return greeting;
    }
}
