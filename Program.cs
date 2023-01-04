
string input = string.Empty;
int stunden = 0, minuten = 0;
int number = 0;
int differenz = 0;
int donation = 0;
bool InvalidInput= false;



PrintWelcome();
PrintParkingTime();
input = EnterCoins(input);

bool IsDigit = Int32.TryParse(input, out number);
if (IsDigit) { Parkscheinautomat(); }

void Parkscheinautomat()
{
    while (IsDigit)
    {
        switch (number)
        {
            case 1: differenz += 100; break;
            case 2: differenz += 200; break;
            case 50: differenz += 50; break;
            case 20: differenz += 20; break;
            case 10: differenz += 10; break;
            case 5: differenz += 5; break;
        }
        AddParkingTime(number);
        PrintParkingTime();
        input = EnterCoins(input);

        IsDigit = Int32.TryParse(input, out number);

    }
}

if (input == "d" || input == "D")
{
    IfInputD();
}

void PrintWelcome()
{
    Console.WriteLine("GUTEN TAG!");
    Console.WriteLine("Parketscheinautomat mit Mindestparkdauer 30 Min und Höchstparkdauer 1:30 Stunden");
    Console.WriteLine("Tarif pro Stunde: 1 Euro");
    Console.WriteLine("Zulässige Münzen: 50 (Cents), 10 (Cents), 5 (Cents), 20 (Cents), 1 (Euro), 2 (Euro)");
    Console.WriteLine("Parkschein drucken mit d oder D");
    Console.WriteLine();
}

string EnterCoins(string eingabe)
{
    Console.Write("Ihre Eingabe: ");
    eingabe = Console.ReadLine()!;

    InvalidInput =  eingabe != "50" && eingabe != "20" && eingabe != "10" && eingabe != "5" && eingabe != "1" && eingabe!="2" && eingabe!="d";

    while (InvalidInput)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("INVALID INPUT!");
        Console.WriteLine("Try again...");
        Console.ResetColor();

        Console.Write("Ihre Eingabe: ");
        eingabe= Console.ReadLine()!;

        InvalidInput = false;
    }
    
    return eingabe;
}

void AddParkingTime(int nummer)
{


    switch (nummer)
    {
        case 50: minuten += 30; break;
        case 20: minuten += 12; break;
        case 10: minuten += 6; break;
        case 5: minuten += 3; break;
        case 1: stunden += 1; break;
        case 2: stunden += 2; break;
    }

    if (minuten >= 60)
    {
        minuten -= 60;
        stunden += 1;
    }
}

void PrintParkingTime()
{
    Console.WriteLine($"Parkzeit bisher: {stunden}:{minuten}");
}

void PrintDonation()
{
    Console.WriteLine($"Danke für Ihre Spende von {donation / 100} Euro und {donation % 100} Cent");
}

void IfInputD()
{
    donation = differenz - 150;

    if (stunden == 0 && minuten == 0)
    {
        Console.WriteLine("Mindesteinwurf 50 Cent, bisher haben Sie 0 Cent eingeworfen");
        input =EnterCoins(input);
        IsDigit = Int32.TryParse(input, out number);
        if (IsDigit) { Parkscheinautomat(); IfInputD(); }
    }
    else if (stunden >= 1 && minuten > 30 || stunden > 1)
    {
        Console.WriteLine();
        Console.WriteLine($"Sie dürfen 1:30 Stunden parken");
        PrintDonation();
        PrintGoodbye();
    }
    else if (stunden <= 1 && minuten <= 30)
    {
        Console.WriteLine();
        Console.WriteLine($"Sie dürfen {stunden}:{minuten} Stunden parken");

        PrintGoodbye();
    }


}

void PrintGoodbye()
{
    Console.WriteLine();
    Console.WriteLine("AUF WIEDERSEHEN!");
}