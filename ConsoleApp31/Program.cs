using ConsoleApp31; 
AnimalController animal = new AnimalController(new Animal());
animal.Say("Woof!", "Dog");
animal.Save("Woof!", "Dog ", "animal.txt");
animal.Load("animal.txt");
string filePath = "figure.txt";
FigureService figureService = new FigureService(filePath);
FigureController figureController = new FigureController(figureService); 
while (true)
{ 
    Console.WriteLine("1.Add figure");
    Console.WriteLine("2.Show figures");
    Console.WriteLine("3.Bye"); 
    string tmp = Console.ReadLine(); 
    switch (tmp)
    {
        case "1":
            figureController.Add();
            break;
        case "2":
            figureController.Figures();
            break;
        case "3":
            return;
        default: 
            break;
    } 
}