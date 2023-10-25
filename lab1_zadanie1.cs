using System;
class Zadanie1
{
 static void Main(string[] args)
 {
Console.WriteLine("Enter the number: ");
 int a = Convert.ToInt32(Console.ReadLine());
 if (a%2 == 0) {
    Console.WriteLine(a + " jest parzyste");
 }
 else {
    Console.WriteLine(a + " nie jest parzyste");
 }
 }
}
