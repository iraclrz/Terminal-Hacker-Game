using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal_Hacker2 : MonoBehaviour
{
    const string menuHint = "You may type the word menu any time"; //Used para makuha or ma-type niya yung hint sa kanya
                                                                    //Nagbibigay lang tayo ng hint na kailangan i-type ni user yung word na "menu" kung gsuto niya bumalik sa main screen
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" }; //Make an array list of passwords that we are going to use for level 1.
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" }; //Make an array list of passwords that we are going to use for level 2.

    //GAME STATE
    int level; //Dito siya sa taas nilagay kasi gagamitin siya palagi. Gagamitin siya throughout the game. Dapat kasi alam natin palagi ito para malaman kung anong screen siya.
               //int level; is a GLOBAL VARIABLE which is accessible to all functions.
    enum Screen { MainMenu, Password, Win }; //Yung nasa loob ng bracket ay array list of screens na gagamitin sa buong game.
    Screen currentScreen;
    // Start is called before the first frame update
    //void Start() --> magra-run siya pagka-play mo ng game mo.
    string password;

    // Start is called before the first frame update
    void Start()
    {
        //string greeting = "Hello, Ira Clariz!"; --> //Hindi lalabas sa screen since after nilagay natin siya BEFORE ng ClearScreen()
        //Terminal.WriteLine(greeting); --> //Hindi lalabas sa screen since nilagay natin siya BEFORE ng ClearScreen() kasi magcclear-screen pa kaya mawawala or mabubura ito.

        //Every start ng game, tatawagin niya yung function na "ShowMainMenu"
        //ENCAPSULATING - refactoring then moving it into another function na tatawagin mo nalang.
        ShowMainMenu();
        ///////ANOTHER METHOD////////
        ///   ShowMainMenu("Hello, Ira Clariz!"); --> 1

    }

    void ShowMainMenu()
    ///   void ShowMainMenu(string greeting) --> 2
    {
        //Ito yung lalabas sa screen 
        //EX WRITE YOUR WELCOME MENU
        Terminal.ClearScreen(); //Mag-clear once na mag-start uli yung game or kapag uulit ng game yung user
        string greeting = "Hello, Ira Clariz!"; //Make a simple greeting
        Terminal.WriteLine(greeting); //Print the greeting
                                      //Lalabas sa screen yung name output na ito dahil after ng ClearScreen() siya nilagay.
        ///    Terminal.WriteLine(greeting); --> 3 It will print "Hello, Ira Clariz!"
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
    }


    //Hiwalay na ito kasi hindi natin nilagay sa void start, so OUTSIDE FUNCTION na siya. So, magra-run siya ng sarili niya. Hindi rin kasi siya kailangan every start of the game kaya inihiwalay.
    //OnUserInput - function siya na may lamang message
    //GAGAWIN LANG NITO IS YUNG MAINSCREEN LANG OR YUNG SA USER INPUT LANG NA IPEPRESS NI USER. 
    //FOCUS LANG ITO SA IINPUT NG USER.
    void OnUserInput(string input)
    {
        ///print(input); --> //Para makita natin kung may pumapasok na input sa console. IPIPRINT SA CONSOLE
        ///Terminal.WriteLine(input); --> //If gusto natin I-PRINT SA TERMINAL.

        if (input == "menu") //If tinype ng user ay "menu"
                              //Dito kapag menu tinype, sa menu lang siya papasok. Hindi ka makakapag-input
        {
            ShowMainMenu(); //Then, ibabalik siya sa Main Menu.
        }
        else if (currentScreen == Screen.MainMenu) //Dito pwede ka na maglagay ng mga input
            RunMainMenu(input); //Gagawin niuto ay dapat magra-run yung Main Menu mo upon choosing yung inputs mo or ininput mo
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input); //Call the function that will check the passowrd
        }
    }

    void RunMainMenu(string input) //Magra-run yung main menu kapag nag-input ka ng ganitong number
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input); //Need natin i-parse para maging int siya. Yung ipaparse natin is yung mga iinput na text.
            AskForPassword();
        }
        //if (input == "1")
        //{
        //    level = 1;
        //    password = level1Passwords[2]; //Ang makukuha niyang password ay yung "shelf" kasi iyon yung may index 2 from the array list of level 1 passwords. 
        //                                    //So kapag hindi "shelf" yung tinype mo, it will display "Please Try Again". Otherwise, kapag tama, it will display, "Well Done!"
        //    StartGame(); //Kapag tinawag yung function na StartGame, magsisimula yung gamer
        //                 // Ilalagay rin sa loob mg paremthesis yung 1 kasi yun yung ininput natin para mag-run yung start game. Yung 1 na character ay kinonvert into an integer automatically.
        //}
        //else if (input == "2")
        //{
        //    level = 2;
        //    password = level2Passwords[1]; //Ang makukuha niyang password ay yung "handcuffs" kasi iyon yung may index 1 from the array list of level 2 passowrds.
        //                                    //So kapag hindi "handcuffs" yung tinype mi, it will display "Please Try Again". Otherwise, kapag tama, it will display, "Well Done!".
        //    StartGame(); 
        //}
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond!");
        }
        else if (currentScreen == Screen.MainMenu) //If yung currentScreen mo ay MainMenu, then the below codes yung mga pwede mong gawin.
        {
            //RunMainMenu(input); //kung ano yung ira-run base sa user input natin.
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
            Terminal.WriteLine(menuHint);
        }
    }

    //GAGAWIN LAHAT NG NASA BABA AY YUNG IRA-RUN MO.
    //void RunMainMenu(string input)
    //{
    //    if (input == "1") //If tinype ng user ay 1
    //    {
    //        level = 1;
    //        StartGame(); //Then, it will call the StartGame() function
    //    }
    //    else if (input == "2") //If tinype ng user ay 2
    //    {
    //        level = 2;
    //        StartGame(); //Then, it will call the StartGame() function
    //    }
    //    else if (input == "001")
    //    {
    //        Terminal.WriteLine("Please select a level.");
    //    }
    //    else
    //    {
    //        Terminal.WriteLine("Please choose a valid level.");
    //    }
    //}

    void AskForPassword() //Function that accepts the level that the user input
                          //Kapag ininput mo ay 1 or 2, dito agad siya didiretso.
    {
        currentScreen = Screen.Password; //This time, you need to change your screen from Main Menu to Password Screen (yung mismong game na) becasue nakapili ka na ng level.
        Terminal.ClearScreen(); //Clear the screen afterwards

        SetRandomPassword(); //Used to randomized the password
        Terminal.WriteLine("Enter your password, Hint:" + password.Anagram()); //Dito everytime na gusto maglaro ng player dapat napapalitan yung password or namimix. "Anagram" jumbles the words
        Terminal.WriteLine(menuHint);

        //Terminal.WriteLine("You have chosen a level " + level); --> //This is going to be the output kapag nilagay ng user ay 1
        //Terminal.WriteLine("Please enter your password: ");
        //currentScreen = Screen.Password; //Lilipat ng screen. Ididispaly yung screen kung saan pwede ka na magsimula maglaro
        //Terminal.WriteLine("You have chosen a level "); //Print the level input by the user
    }

    void SetRandomPassword() //used to randomized the password
    {
        switch (level) //Usually ginagamit itong switch case kapag may mga level or may pagpipilian.
        {
            case 1:
                //password = level1Passwords[1]; --> //Kapag ininput niya ay level 1, yung password na may array number or index 1 yung gagamitin since yun nilagay natin dito sa loob ng parenthesis.
                password = level1Passwords[Random.Range(0, level1Passwords.Length)]; //Dito irarandomize na natin yung mga passwords from level 1. Need natin maglagay ng minimum and maximum range. In this case, the minimum range is 0 and the maximum is yung length or sukat or gano karami yung level 1 passwords.
                break; //Need lagyan ng break kasi mag-eerror kapag walang break.

            case 2:
                //password = level2Passwords[2]; --> //Kapag ininput niya ay level 2, yung password na may array number or index 2 yung gagamitin since yun nilagay natin dito sa loob ng parenthesis.
                password = level2Passwords[Random.Range(0, level2Passwords.Length)]; //Dito irarandomize na natin yung mga passwords from level 2. Need natin maglagay ng minimum and maximum range. In this case, the minimum range is 0 and the maximum is yung length or sukat or gano karami yung level 2 passwords.
                break; //Need lagyan ng break kasi mag-eerror kapag walang break.

            default: //Kapag may switch case, automatic na need din maglagay ng default.
                Debug.LogError("Invalid level");
                break;
        }
    }

    void CheckPassword (string input) //Function that checks the password and tumatanggap siya ng string input ni user
    {
        if (input == password)
        {
            DisplayWinScreen(); //This will run if tama yung password na nilagay ng user
                                //Kapag nanalo siya, ito yung ididisplay niya na screen
        }
        else
        {
            Terminal.WriteLine("Please Try Again!"); //This will run if mali yung password na nilagay ng user
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win; //Para malaman kung nasaang screen ka
        Terminal.ClearScreen(); //Clear screen natin siya
        ShowLevelReward(); //Used para malaman ng player kung nanalo siya
    }

    void ShowLevelReward() //Used para malaman ng player if nanalo siya
    {
        switch (level) //Used switch case kasi gumagamit ulit ng level
        {
            case 1: //This is for level 1 which is the library
                Terminal.WriteLine("Grab a book!");
                Terminal.WriteLine(@"
    _________
   /       //
  /       //
 /       //
(_______(/
");
                break;

            case 2: //This is for level 2 which is the police station
                Terminal.WriteLine("Have the Key!");
                Terminal.WriteLine(@"
 _
/0\_________
\_/----='='='
");
                break;

            default:
                Debug.LogError("Invalid level reached");
                break;

        }
        
        //Terminal.WriteLine("Well Done!");
    }
}
