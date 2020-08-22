using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Data
    string[] level1Password = { "Pleasant", "Hanger", "Branger" };
    string[] level2Password = { "Praises", "Plaigerize", "Bonus" };
    string[] level3Password = { "Anger", "Response", "Weather" };
    
    //keeps the game state
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;


    // Start is called before the first frame update
    void Start()
    {
        ShowMenu();
    }

    // displays welxome screen
    void ShowMenu()
    {
        Screen currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Player");
        Terminal.WriteLine("Please select Where you want to hack into");
        Terminal.WriteLine("Press 1 to hack into CBN");
        Terminal.WriteLine("Press 2 to hack into DSS");
        Terminal.WriteLine("Press 3 to hack into NASRAD");
        Terminal.WriteLine("Enter your Selection: ");
    }

    // gets user inputs and process it
    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if ( currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ShowWinScreen();
        }


    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            System.Random rand = new System.Random();
            password = level1Password[0];//rand.Next(0, level1Password.Length - 1)];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            System.Random rand = new System.Random();
            password = level2Password[0];//rand.Next(0, level2Password.Length - 1)];
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
             System.Random rand = new System.Random();

            password = level3Password[rand.Next(0, level3Password.Length - 1)];
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a Valid level or type \"menu\" to go back to Menu");
        }
    }


    //updates the state to  enter password
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have selected Level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
       if (password == input)
       {
          Terminal.WriteLine("Yeah Your Password is Correct");
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Password Wrong");
        }
    }


    void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Congratulations You are a Winner this is your reward!!!");
        ShowReward();
    }


    void ShowReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("You conquered Level " + level);
                Terminal.WriteLine(@"
       __________
      //  W    //
     //   I   //
    //    N  //
    (_______(/
            ");
                break;
            case 2:
                Terminal.WriteLine("You conquered level"+ level);
                Terminal.WriteLine(@"
                
                    
         _____________
        /      |      \
     __/_______|_______\__
    //         -      -   \\
    |      WIN       WIN    |
    |___                 ___|
       \\_______________//     
        ()--------------()
                ");
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
