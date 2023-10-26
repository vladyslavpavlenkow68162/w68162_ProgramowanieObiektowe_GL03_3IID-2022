using System;

class Program {
  public static void Main (string[] args) {
    Random random = new Random();
    int num = random.Next(1, 10);
    int tried = 0;
    while (tried < 3) {
    Console.WriteLine("Enter the number: ");
    int user = Convert.ToInt32(Console.ReadLine());
    if (num == user) {
      Console.WriteLine("You're right!");
      tried++;
      break;
      }
    else {
      Console.WriteLine("You're not right");
      tried++;
      }
    }
    }
  }