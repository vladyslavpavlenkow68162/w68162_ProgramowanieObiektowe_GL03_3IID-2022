using System;

class Sumator
{
    private int[] Liczby;

    public Sumator(int[] liczby)
    {
        Liczby = liczby;
    }

    public int Suma()
    {
        int sum = 0;
        foreach (int liczba in Liczby)
        {
            sum += liczba;
        }
        return sum;
    }

    public int SumaPodziel3()
    {
        int sum = 0;
        foreach (int liczba in Liczby)
        {
            if (liczba % 3 == 0)
            {
                sum += liczba;
            }
        }
        return sum;
    }

    public void IleElementow()
    {
        int ilosc = Liczby.Length;
        Console.WriteLine("Ilość elementów: " + ilosc);
    }

    public void Wszystkie()
    {
        foreach (int liczba in Liczby)
        {
            Console.WriteLine(liczba);
        }
    }

    public void WypiszElementy(int lowIndex, int highIndex)
    {
        if (lowIndex < 0)
            lowIndex = 0;

        if (highIndex >= Liczby.Length)
            highIndex = Liczby.Length - 1;

        for (int i = lowIndex; i <= highIndex; i++)
        {
            Console.WriteLine("Element o indeksie " + i + ": " + Liczby[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        int[] liczbyArray = { 1, 2, 3, 4, 5, 6 };

        Sumator sumator = new Sumator(liczbyArray);
        int suma = sumator.Suma();
        int sumap3 = sumator.SumaPodziel3();
        Console.WriteLine("Suma liczb: " + suma);
        Console.WriteLine("Suma liczb podzielnych przez 3: " + sumap3);
        sumator.IleElementow();
        sumator.Wszystkie();
        sumator.WypiszElementy(1, 4);
    }
}
