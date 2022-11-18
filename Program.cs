using System.Globalization;
using System.Runtime.ExceptionServices;
List<int> AllReminders(int input)
{
    List<int> result = new List<int>();
    for (int i = 0; i < 26; i++)
    {
        if (!result.Contains(input * i % 26))
        {
            result.Add(input * i % 26);
        }
    }
    return result;
}
Console.WriteLine("Введите ключ + шифровку (без пробелов)");
string input = Console.ReadLine();
List<char> keyArray = new List<char>();
List<char> encoding = new List<char>();
for (int i = 0; i < input.Length; i++)
{
    if (char.IsNumber(input[i]))
    {
        keyArray.Add(input[i]);
    }
    else
    {
        encoding.Add(input[i]);
    }
}

string temp2 = string.Join("", keyArray.ToArray());
int.TryParse(temp2, out int key);
List<int> reminders = AllReminders(key);
List<int> result = new List<int>();

if (reminders.Count == 26)
{
    for (int i = 0; i < encoding.Count; i++)
    {
        for (int j = 0; j < 26; j++)
        {
            if (j * key % 26 - (byte)(encoding[i] % 97) == 0)
            {
                result.Add(j);
                break;
            }
        }
    }
}
else
{
    Console.WriteLine("Impossible to decode");
}
foreach (int temp in result)
{
    Console.Write((char)(temp + 97));
}
