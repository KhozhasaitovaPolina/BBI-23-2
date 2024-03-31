using System;
using System.Runtime.InteropServices;
using static Boys;

// Абстрактный класс "Дисциплина"
public abstract class Sportsmens
{
    protected string _club;
    protected string _familia;
    protected double _res;

    public string Club => _club;
    public string Familia => _familia;
    public double Res => _res;
   
    public Sportsmens (string club, string familia, double res)
    {
        _club = club;
        _familia = familia;
        _res= res;
    }
    public void PrintInfo()
    {
        Console.WriteLine("Команда: {0} \t Фамилия: {1} \t балл: {2}", Club, Familia, Res);
    }
}
//  Класс "Лыжники", наследуемый от класса "Спортсмены"
public class Boys : Sportsmens
{
    private string club;
    private string familia;
    private double res;



    public Boys(string club, string familia, double res) : base(club, familia, res)
    {
        this.club = club;
        this.familia = familia;
        this.res = res;
    }
    // Класс "Лыжницы", наследуемый от класса "Спортсмены"
    public class Girls : Sportsmens
    {
        private string club;
        private string familia;
        private double res;

        public Girls(string club, string familia, double res) : base(club, familia, res)
        {
            this.club = club;
            this.familia = familia;
            this.res = res;

        }
        public void PrintInfo()
        {
            Console.WriteLine("Команда: {0} \t Фамилия: {1} \t балл: {2}", Club, Familia, Res);
        }
    }
}
class Program
{
    static void Main()
    {
        List<Boys> Club1 = new List<Boys>();
        List<Boys> Club2 = new List<Boys>();
        Boys[] set = new Boys[6];
        set[0] = new Boys("Лыжники 1", "Меньшов", 2);
        set[1] = new Boys("Лыжники 2", "Кукурузников", 5);
        set[2] = new Boys("Лыжники 2", "Горошкин", 10);
        set[3] = new Boys("Лыжники 1", "Горшков", 5);
        set[4] = new Boys("Лыжники 2", "Сажик", 2);
        set[5] = new Boys("Лыжники 1", "Кузнечик", 10);

        List<Girls> Club3 = new List<Girls>();
        List<Girls> Club4 = new List<Girls>();
        Girls[] set1 = new Girls[6];
        set1[0] = new Girls("Лыжницы 1", "Меньшова", 2);
        set1[1] = new Girls("Лыжницы 2", "Кукурузникова", 9);
        set1[2] = new Girls("Лыжницы 2", "Горошкина", 9);
        set1[3] = new Girls("Лыжницы 1", "Горшкова", 6);
        set1[4] = new Girls("Лыжницы 2", "Сажикова", 5);
        set1[5] = new Girls("Лыжницы 1", "Кузнечик", 7);

        Console.WriteLine("Таблицы Лыжников по командам");
        Console.WriteLine(" ");
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i].Club == "Лыжники 1") { Club1.Add(set[i]); }
            if (set[i].Club == "Лыжники 2") { Club2.Add(set[i]); }
        }
        Club1 = Club1.OrderByDescending(n => n.Res).ToList();
        foreach (var club1 in Club1) { club1.PrintInfo(); }
        Club2 = Club2.OrderByDescending(m => m.Res).ToList();
        foreach (var club2 in Club2) { club2.PrintInfo(); }
        Console.WriteLine(" ");
        for (int i = 0; i < set1.Length; i++)
        {
            if (set1[i].Club == "Лыжницы 1") { Club3.Add(set1[i]); }
            if (set1[i].Club == "Лыжницы 2") { Club4.Add(set1[i]); }
        }
        Club3 = Club3.OrderByDescending(k => k.Res).ToList();
        foreach (var club3 in Club3) { club3.PrintInfo(); }
        Club4 = Club4.OrderByDescending(r => r.Res).ToList();
        foreach (var club4 in Club4) { club4.PrintInfo(); }

        Console.WriteLine(" ");
        Console.WriteLine("Таблицы Лыжников и Лыжниц по результатам ");
        Console.WriteLine(" ");
        // Объединение результатов двух групп 
        List<Boys> Results = Club1.Concat(Club2).ToList();
        List<Girls> Results1 = Club3.Concat(Club4).ToList();

        Results = Results.OrderByDescending(x => x.Res).ToList();
        Results1 = Results1.OrderByDescending(z=> z.Res).ToList();
        foreach (var result in Results) { result.PrintInfo(); }
        Console.WriteLine("  ");
        foreach (var result1 in Results1)
        {
            result1.PrintInfo();
        }
        Console.WriteLine(" ");
        Console.WriteLine("Таблица всех спортсменов по результатам");
        Console.WriteLine(" ");
        List<Sportsmens> AllSportsmens = Results.Cast<Sportsmens>().Concat(Results1).Cast<Sportsmens>().ToList();
        AllSportsmens = AllSportsmens.OrderByDescending(s => s.Res).ToList();

        foreach (var sportsman in AllSportsmens)
        {
            sportsman.PrintInfo();
        }

    }
}