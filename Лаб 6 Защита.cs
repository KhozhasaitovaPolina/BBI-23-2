using System.Runtime.InteropServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

struct People
{
    public string familia;
    public double[] prig;

    public double Bestresult { get; private set; }

    public People(string familia, double[] prig)
    {
        this.familia = familia;
        this.prig = prig;
        double max = prig[0];
        for (int i = 1; i < prig.Length; i++)
        {
            if (prig[i] > max)
            {
                max = prig[i];
            }
        }
        Bestresult = max;
    }

    public void Printinf()
    {
        Console.Write("Фамилия: {0} \t Попытки: ", familia);
        foreach (var attempt in prig)
        {
            Console.Write("{0} ", attempt);
        }
        Console.WriteLine("\t Лучший результат: {0}", Bestresult);
    }

    public static void GnomeSort(People[] set)
    {
        int index = 1;
        int nextind = index + 1;
        while (index < set.Length)
        {
            if (set[index - 1].Bestresult >= set[index].Bestresult)
            {
                index = nextind;
                nextind++;
            }
            else
            {
                People temp = set[index - 1];
                set[index - 1] = set[index];
                set[index] = temp;
                index--;
                if (index == 0)
                {
                    index = nextind;
                    nextind++;
                }
            }
        }
    }
}
public class Program
{
    static void Main()
    {
        People[] set = new People[6];
        set[0] = new People("Безруков", new double[] { 3.34, 2.25, 3.44 });
        set[1] = new People("Безногов", new double[] { 2.22, 1.88, 2.76 });
        set[2] = new People("Бабайкин", new double[] { 0.99, 3.75, 3.13 });
        set[3] = new People("Бугайкин", new double[] { 2.34, 2.97, 3.12 });
        set[4] = new People("Левошоловин", new double[] { 1.87, 2.13, 1.86 });
        set[5] = new People("Акипов", new double[] { 2.99, 4.01, 3.67 });
        People.GnomeSort(set);
        foreach (var person in set)
        {

            person.Printinf();
        }
    }
}

