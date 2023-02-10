string variable = "21 + 32 - 567";
List<string> operations = new List<string>();
char[] operators = new[] { '+', '-', '*', '/' };

string buff = "";
char? oper = null;
foreach (var s in variable)
{
    if (s == ' ')
    {
        continue;
    }
    
    if (Char.IsDigit(s))
    {
        buff += s;
    }
    else if (operators.Contains(s))
    {
        if (oper is null)
        {
            operations.Add(buff);
            buff = "";
            oper = s;
        }
        else
        {
            operations.Add(buff);
            operations.Add(oper.ToString());
            buff = "";
            oper = null;
        }
    }
}

if (buff != "")
{
    operations.Add(buff);
}

if (oper is not null)
{
    operations.Add(oper.ToString());
}

foreach (var op in operations)
{
    Console.WriteLine(op);
}
