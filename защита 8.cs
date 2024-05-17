

using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    public string _text;
    public Task(string text) { _text = text; }
    public virtual void ParseText(string text) { _text = text; }
}


class Task11 : Task
{
        public override string ToString()
        {
            string currentWord = "";
            List<string> result = new List<string>();
            for (int index = 0; index < _text.Length; ++index)
            {
                char c = _text[index];
                if (c != ',')
                {
                    currentWord += c;
                    continue;
                }
                result.Add(currentWord);

                currentWord = "";
            }
            if (currentWord != "")
                result.Add(currentWord);

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < result.Count - 1; i++)
                {
                    bool needSwap = false;
                    for (int j = 0; j < Math.Min(result[i].Length, result[i + 1].Length); j++)
                    {
                        if (result[i][j] > result[i + 1][j])
                        {
                            needSwap = true;
                            break;
                        }
                        else if (result[i][j] < result[i + 1][j])
                        {
                            break;
                        }
                    }

                    if (needSwap)
                    {
                        string temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
            while (swapped);



            StringBuilder stringBuilder = new StringBuilder();
            foreach (string Name in result)
                stringBuilder.AppendLine(Name);

            return stringBuilder.ToString();
        }
        public Task11(string _text)
            : base(_text)
        {
        }
}

class Program
{
    static void Main()
    {
        string inputNames = " Рыббкин, Петров, Бобиков, Бабайкин, Анапов, Сочин";
        Task11 task11 = new Task11(inputNames);
        Console.WriteLine(task11.ToString());
    }
}
