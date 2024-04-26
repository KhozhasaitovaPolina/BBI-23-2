using System;

abstract class Task
{
    private string text = "hfhjskkkhfjjs";
    public string Text
    {
        get=> text; 
        set => text = value;    
    }
    
}
class Task_1: Task
{
    
}
class Program
{
    static void Main()
    { string path = "C:\\Users\\m2302486\\Desktop";
        string file = "Answer";
        path = Path.Combine(path, file);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string f1 = "task_1.json";
        string f2 = "task_2.json";
        
        f1= Path.Combine(path,f1);
        f2 = Path.Combine(path, f2);
        
        if (!File.Exists(f1))
        {
            File.Create(f1);
        }
        if (!File.Exists(f2))
        {
            File.Create(f2);
        }
    }
}


