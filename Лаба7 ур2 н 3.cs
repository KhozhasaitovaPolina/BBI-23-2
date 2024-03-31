using System.Runtime.InteropServices;

// Абстрактный класс "Дисциплина"
public abstract class Discipline
{
    protected string disciplineName;
    protected string _sportsmen;
    protected double _res1;
    protected double _res2;
    protected double _res3;
    public string DisciplineName => disciplineName;
    public string Sportsmen => _sportsmen;
    public double Res1 => _res1;
    public double Res2 => _res2;
    public double Res3 => _res3;

    public Discipline(string disname, string sportsmen, double res1, double res2, double res3)
    {
        disciplineName = disname;
        _sportsmen = sportsmen;
        _res1 = res1;
        _res2 = res2;
        _res3 = res3;

    }



}
class BestResult
{
    public string Sportsmen { get; set; }
    public double BestRes { get; set; }
}


// Класс "Прыжки в длину", наследуемый от класса "Дисциплина"
public class LongJump : Discipline
{
    private string sportsmen;
    private double res1;
    private double res2;
    private double res3;


    public LongJump(string discipline, string sportsmen, double res1, double res2, double res3) : base(discipline, sportsmen, res1, res2, res3)
    {
        this.sportsmen = sportsmen;
        this.res1 = res1;
        this.res2 = res2;
        this.res3 = res3;



    }
    // Класс "Прыжки в длину в высоту", наследуемый от класса "Дисциплина"
    public class JumpHight : Discipline
    {
        private string sportsmen;
        private double res1;
        private double res2;
        private double res3;

        public JumpHight(string discipline, string sportsmen, double res1, double res2, double res3) : base(discipline, sportsmen, res1, res2, res3)
        {
            this.sportsmen = sportsmen;
            this.res1 = res1;
            this.res2 = res2;
            this.res3 = res3;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            JumpHight[] vid = new JumpHight[6];
            vid[0] = new JumpHight("Прыжки в длинну", "Безруков", 3.34, 2.25, 3.44);
            vid[1] = new JumpHight("Прыжки в длинну", "Безногов", 2.22, 1.88, 2.76);
            vid[2] = new JumpHight("Прыжки в длинну", "Бабайкин", 0.99, 3.75, 3.13);
            vid[3] = new JumpHight("Прыжки в длинну", "Бугайкин", 2.34, 2.97, 3.12);
            vid[4] = new JumpHight("Прыжки в длинну", "Левошоловин", 1.87, 2.13, 1.86);
            vid[5] = new JumpHight("Прыжки в длинну", "Акипов", 2.99, 4.01, 3.67);

            LongJump[] vid1 = new LongJump[6];
            vid1[0] = new LongJump("Прыжки в высоту", "Безруков", 2.24, 3.52, 3.14);
            vid1[1] = new LongJump("Прыжки в высоту", "Безногов", 2.31, 2.28, 3.76);
            vid1[2] = new LongJump("Прыжки в высоту", "Бабайкин", 0.99, 5.75, 2.53);
            vid1[3] = new LongJump("Прыжки в высоту", "Бугайкин", 1.34, 3.57, 1.11);
            vid1[4] = new LongJump("Прыжки в высоту", "Левошоловин", 1.47, 3.13, 1.76);
            vid1[5] = new LongJump("Прыжки в высоту", "Акипов", 3.56, 5.61, 2.67);


            BestResult[] bestResultsVid = new BestResult[6];
            for (int i = 0; i < vid.Length; i++)
            {
                double bestRes = Math.Max(vid[i].Res1, Math.Max(vid[i].Res2, vid[i].Res3));
                bestResultsVid[i] = new BestResult { Sportsmen = vid[i].Sportsmen, BestRes = bestRes };
            }

            Array.Sort(bestResultsVid, (a, b) => b.BestRes.CompareTo(a.BestRes)); // Сортировка массива лучших результатов

            Console.WriteLine("Лучшие результаты для Прыжков в длину:");
            foreach (var elem in bestResultsVid)
            {
                Console.WriteLine($"{elem.Sportsmen} - {elem.BestRes}");
            }

            BestResult[] bestResultsVid1 = new BestResult[6];
            for (int i = 0; i < vid1.Length; i++)
            {
                double bestRes = Math.Max(vid1[i].Res1, Math.Max(vid1[i].Res2, vid1[i].Res3));
                bestResultsVid1[i] = new BestResult { Sportsmen = vid1[i].Sportsmen, BestRes = bestRes };
            }

            Array.Sort(bestResultsVid1, (a, b) => b.BestRes.CompareTo(a.BestRes)); // Сортировка массива лучших результатов

            Console.WriteLine("Лучшие результаты для Прыжков в высоту:");
            foreach (var elem in bestResultsVid1)
            {
                Console.WriteLine($"{elem.Sportsmen} - {elem.BestRes}");
            }
        }
    }
}
