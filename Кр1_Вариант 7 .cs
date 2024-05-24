using System;

struct Goods
{
    private string name { get; }
    private int unicart { get; }
    private double coust { get; }
    private int much { get; }

    public Goods(string name, int unicart, double coust, int much)
    {
        this.name = name;
        this.unicart = unicart;
        this.coust = coust;
        this.much = much;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {name}\t Артикул: {unicart}\t Цена: {coust}\t Количество: {much}");
    }
}

public class Program
{
    static void Main()
    {
        Goods[] set = new Goods[5];
        set[0] = new Goods("BagPurple", 228659, 2300, 8);
        set[1] = new Goods("BagRed", 2302486, 9300, 16);
        set[2] = new Goods("Moonshine", 230638, 1000, 47);
        set[3] = new Goods("Redbread", 574077, 300, 64);
        set[4] = new Goods("Welldrest", 2302486, 9300, 16);

        foreach (Goods goods in set)
        {
            goods.PrintInfo();
        }
    }
}



