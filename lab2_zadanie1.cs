using System;

class Licz
{
    private int wartosc;

    public Licz(int wartosc)
    {
        this.wartosc = wartosc;
    }

    public int Dodaj(int liczba)
    {
        wartosc += liczba;
        return wartosc;
    }

    public int Odejmij(int liczba)
    {
        wartosc -= liczba;
        return wartosc;
    }

    public void WypiszStan()
    {
        Console.WriteLine("Aktualna wartość: " + wartosc);
    }
}

class Program
{
    static void Main()
    {
        Licz mojaLiczba = new Licz(10);

        mojaLiczba.WypiszStan();

        mojaLiczba.Dodaj(5);
        mojaLiczba.WypiszStan();

        mojaLiczba.Odejmij(3);
        mojaLiczba.WypiszStan();
    }
}
