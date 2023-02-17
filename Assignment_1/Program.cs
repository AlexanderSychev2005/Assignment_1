string input = "22 + 3*(56-     45)^435345";

string b = "";
string[] result = new String[50];
int index = 0;

foreach (var x in input)
{
    if (Char.IsDigit(x))
    {
        b += x;
    }
    else
    { 
        if (! (x == ' '))
        {
            if (b.Length > 0)
            {
                result[index] = b;
                b = "";
                index += 1;
            }
            result[index] = x.ToString();
            index += 1;
        }
        
    }
}

if (b.Length > 0)
{
    result[index] = b;
}
Console.WriteLine("result: b=" + b);