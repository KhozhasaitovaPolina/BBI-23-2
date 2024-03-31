using System.Runtime.InteropServices;

abstract class People
{
  protected  string familia;
    protected int prop;
    protected int mark;
    public string Familia => familia;
    public int Prop => prop;
    public int Mark => mark;


    public People(string familia, int mark, int prop)
    {
        this.familia = familia;
        this.mark = mark;
        this.prop = prop;
      
    }

    public virtual void Printinf()
    {
        Console.WriteLine("Фамилия: {0} \t  Пропуски {1}  ", Familia, Prop);
    }
}
class Informatic : People
{
    public Informatic(string familia, int mark, int prop): base (familia, mark, prop)
    {

    }
    public override void Printinf()
    {
        Console.WriteLine("Фамилия: {0} \t  Оценка {1}\t  Пропуски {2} ",this.familia, this.mark, this.prop );
    }
}

class Math : People
{
    public Math(string familia, int mark, int prop) : base(familia, mark, prop)
    {

    }
    public override void Printinf()
    {
        Console.WriteLine("Фамилия: {0} \t  Оценка {1}\t  Пропуски {2} ", this.familia, this.mark, this.prop);
    }
}


class Program
{
    static void Main()
    {
        Informatic [] set = new Informatic[6];
        set[0] = new Informatic("Безруков", 4, 2);
        set[1] = new Informatic("Безногов", 2, 8);
        set[2] = new Informatic("Баабайкин", 0, 6);
        set[3] = new Informatic("Бугайкин", 2, 5);
        set[4] = new Informatic("Левошоловин", 5, 0);
        set[5] = new Informatic("Акипов", 2, 4);


        Math [] set1 = new Math[6];
        set1[0] = new Math("Безруков", 5, 2);
        set1[1] = new Math("Безногов", 4, 8);
        set1[2] = new Math("Баабайкин", 2, 6);
        set1[3] = new Math("Бугайкин", 3, 5);
        set1[4] = new Math("Левошоловин", 2, 0);
        set1[5] = new Math("Акипов", 4, 4);
        Console.WriteLine("Информатика");
        for (int i = 0; i < set.Length; i++)
        {
            if (set[i].Mark == 2)
            {
                set[i].Printinf();
            }
        }
        Console.WriteLine( );
        Console.WriteLine("Математика");
        for (int i = 0; i < set1.Length; i++)
        {
            if (set1[i].Mark == 2)
            {
                set1[i].Printinf();
            }
        }
    }
}

