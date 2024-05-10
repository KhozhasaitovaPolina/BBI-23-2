using System.Text.RegularExpressions;
using System.Threading.Tasks;

abstract class Task
{
    public string _text;
    public Task(string text) { _text = text; }
    public virtual void ParseText(string text) { _text = text; }


}

class Task1 : Task
{
    private string result;
    public Task1(string text) : base(text) { }
    public override void ParseText(string text)
    {
        text = text.ToLower();
        string pattern = "[а-я]"; //символы русского языка в нижнем регистре
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        string newtext = "";

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                newtext += match.Value;
            }
            Frequency(newtext);
        }

        else
        {
            Console.WriteLine("В тексте нет русских букв");
        }
    }
    private void Frequency(string text)
    {
        int[] letterFrqsy = new int[32]; //массив с кодами букв
        for (int i = 0; i < 32; i++) { letterFrqsy[i] = 1072 + i; }
        double cnt = 0;
        for (int i = 0; i < letterFrqsy.Length; i++)
        {
            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] == letterFrqsy[i]) { cnt++; }
            }
            result += $"Частота буквы {(char)letterFrqsy[i]} составляет {cnt / text.Length * 100}%" + "\n";
            cnt = 0;
        }
    }
    public override string ToString()
    {
        return result;
    }
}

class Task3 : Task
{
    private string split;
    public Task3(string text) : base(text) { }
    public override void ParseText(string text)
    {
        string pattern = @".{1,50}(\s)"; //символы в диапазоне [1;50], строка завершается пробелом
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                split += match.Value + "\n";
            }
        }
    }
    public override string ToString()
    {
        return split;
    }
}
class Task5 : Task
{
    private string result;

    public Task5(string text) : base(text) { }

    public override void ParseText(string text)
    {
        Dictionary<char, double> kakchasto = new Dictionary<char, double>();
        int countSymbols = 0;

        foreach (char letter in text.ToLower())
        {
            if (char.IsLetter(letter))
            {
                countSymbols++;
                if (kakchasto.ContainsKey(letter))
                {
                    kakchasto[letter]++;
                }
                else
                {
                    kakchasto.Add(letter, 1);
                }
            }
        }

        var sortedKakchasto = kakchasto.OrderByDescending(bukva => bukva.Value);

        foreach (var bukva in sortedKakchasto)
        {
            double frequency = bukva.Value / countSymbols;
            result += $"Буква '{bukva.Key}' встречается с частотой {frequency:P}\n";
        }
    }

    public override string ToString()
    {
        return result;
    }
}
class Task7 : Task
{
    private string result = "Слова, содержащие заданную последовательность" + "\n";
    public Task7(string text) : base(text) { }

    public override void ParseText(string text)
    {
        Regex regex = new Regex(@"\b\w*(ьорд)\w*\b");
        MatchCollection matches = regex.Matches(text);

        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                result += match.Value + "\n";
            }
        }

    }
    public override string ToString()
    {
        return result;
    }
}


class Task11 : Task
{
    private string[] names;

    public Task11(string namesString) : base(namesString)
    {
        names = namesString.Split(',');
    }

    private void BubbleSort(string[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                {
                    string temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public override string ToString()
    {
        BubbleSort(names);

        string result = "Отсортированный список фамилий:\n";
        foreach (string name in names)
        {
            result += name.Trim() + "\n";
        }
        return result;
    }
}

class Task14 : Task
{
    private int sum;

    public Task14(string text) : base(text) { }

    public override void ParseText(string text)
    {
        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            if (int.TryParse(word, out int number))
            {
                if (number >= 1 && number <= 10)
                {
                    sum += number;
                }
            }
        }
    }

    public override string ToString()
    {
        return $"Сумма чисел от 1 до 10 в тексте: {sum}";
    }
}
class Program
{
    static void Main()
    {
        Task1 task1 = new Task1("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий. ");
        task1.ParseText(task1._text);
        Console.WriteLine(task1.ToString());


        Task3 task3 = new Task3("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.");
        task3.ParseText(task3._text);
        Console.WriteLine(task3.ToString());


        string inputkakchasto = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
        Task5 task5 = new Task5(inputkakchasto);
        task5.ParseText(task5._text);
        Console.WriteLine(task5.ToString());

        string root = "лед";
        Task7 task7 = new Task7("Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.");
        task7.ParseText(task7._text);
        Console.WriteLine(task7.ToString());

        string inputNames = "Кукушкин, Петров, Бобиков, Бабайкин, Анапов, Сочин";
        Task11 task11 = new Task11(inputNames);
        Console.WriteLine(task11.ToString());

        string inputText = "Найти сумму чисел: 3 5 12 8 9 2";
        Task14 task14 = new Task14(inputText);
        task14.ParseText(task14._text);
        Console.WriteLine(task14.ToString());
    }
}
