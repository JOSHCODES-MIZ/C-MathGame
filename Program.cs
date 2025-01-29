using System.Reflection.Metadata.Ecma335;

namespace MathGame;

class Program
{
    static void Main(string[] args)
    {
     
     bool IsValid = false;
     int number = 0;
       

        Console.WriteLine("Enter your name: ");
        try{
        string input = Console.ReadLine()!;

        if(input == ""){
           Console.WriteLine("Error. Enter a name this time.");
        }
        }catch(FormatException){
            Console.WriteLine("Error: Enter a name.");
        }

        int DiffLevel = DifficultyLevel(IsValid, number);
        int Limit = QuestionLimit(IsValid, number);

        Questions(DiffLevel, Limit);

    }
    public static int DifficultyLevel(bool ValidInput, int userInput){
          ValidInput = false;
        while(!ValidInput){
     Console.WriteLine("Select Difficulty Level: ");

     try{
       userInput = int.Parse(Console.ReadLine()!);
        if(userInput >= 1 && userInput <= 3){
           ValidInput = true; 

         }else{
         Console.WriteLine("Error: Enter an integer value between 1 and 3");
       }
     }catch(FormatException){
        Console.WriteLine("Error: Enter a valid Integer");
     }
        }
        return userInput;
    }
        
    
    public static int QuestionLimit(bool ValidInput, int userInput){
          ValidInput = false;
          
         while(!ValidInput){

    Console.WriteLine("Enter how many Questions you want:");
    try{
      userInput = int.Parse(Console.ReadLine()!);
      if(userInput >= 3 && userInput <= 10){
        ValidInput = true;
      }else{
        Console.WriteLine("Error: Enter Question amount(3-10)!");
      }
    }catch(FormatException){
         Console.WriteLine("Error: Enter a Valid Integer");
    }
    }

      return userInput;

}
//Functiuon to ask User Math Questions
  public static void Questions(int difficultyLevel, int questionLimit){
   Random random = new Random(); 
   int correctAnswers = 0;
  for(int i = 0; i < questionLimit; i++){
    int num1 = 0, num2 = 0, correctAnswer = 0;

    switch(difficultyLevel){

      case 1: //Level one difficulty
      num1 = random.Next(1,10);
      num2 = random.Next(1,10);
      break;

      case 2: //Level 2 difficulty
      num1 = random.Next(10,100);
      num2 = random.Next(10,100);
      break;

      case 3: //Level 3 difficulty
      num1 = random.Next(100,1000);
      num2 = random.Next(100,1000);
      break;

      default:
      Console.WriteLine("Invalid Question amount");
      return;

    }

    correctAnswer = num1 + num2;
    int attempts = 0;
    bool IsRight = false;

    while(attempts < 3 && !IsRight){
    Console.WriteLine($"Question{i+1}: What is {num1} + {num2}?");
    try{
      int userInput = int.Parse(Console.ReadLine()!);
      if(userInput == correctAnswer){
        Console.WriteLine("YAY! You got it right!!");
        correctAnswers++;
        IsRight = true;
      }
      else{
        Console.WriteLine("OOPS! You got it wrong!!");
      }
    }catch(FormatException){
      Console.WriteLine("Error: Invalid Input. Enter a number");

    }
    attempts++; //increments attempt to count number of attempts

     if (attempts == 3 && !IsRight)
            {
                Console.WriteLine($"Sorry, the correct answer was {correctAnswer}.");
            }
    }
   

  }
   double percentage = FinalScore(correctAnswers, questionLimit);

   // Output final score and percentage with two decimal places
        Console.WriteLine($"\nYou answered {correctAnswers} out of {questionLimit} questions correctly.");
        Console.WriteLine($"Your score is: {percentage:F2}%");
    
    
  }

  public static double FinalScore(int correctAnswers, int questionLimit){
    Console.WriteLine("Congrats. You completed the Addding Game!!");

    return (double)correctAnswers / questionLimit * 100;

    
  }

}
