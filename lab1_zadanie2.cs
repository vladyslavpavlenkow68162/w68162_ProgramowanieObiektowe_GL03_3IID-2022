using System;
class Program
{
 static void Main(string[] args)
 {
 Console.WriteLine("Enter the number: ");
 int n = Convert.ToInt32(Console.ReadLine());
 for (int i = 1; i < n; i++) {
    if (i % 2 == 0){
        Console.WriteLine(i);
    }

 }
 }
}
