using AaDSLab1;

Console.WriteLine("Enter size of the labyrinth:");
int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter k: ");
int k = Convert.ToInt32(Console.ReadLine());

Labyrinth field = new Labyrinth(n, m);
field.ReadFromFile();
field.Write();
Stack<Pair> path = new Stack<Pair>();

int successWays = 0;
for (int j = 0; j < m; j++)
{
    int i = 0;
    field.Field[i, j].IsVisited = true;
    if (field.Field[i, j].Value == 1)
        continue;
    while (true)
    {
        char direction = field.Direction(i, j);
        if (direction == 't')
        {
            field.Field[i, j].IsVisited = true;
            Pair tmp = path.Pop();
            i = tmp.I;
            j = tmp.J;
            field.Field[i, j].IsVisited = true;
            field.Field[i, j].PossibleWaysToGo--;
        }
        else if (direction == 'l')
        {
            path.Push(new Pair(i, j));
            j--;
            field.Field[i, j].IsVisited = true;
            field.Field[i, j].PossibleWaysToGo--;
        }
        else if (direction == 'd')
        {
            path.Push(new Pair(i, j));
            i++;
            field.Field[i, j].IsVisited = true;
            field.Field[i, j].PossibleWaysToGo--;
        }
        else if (direction == 'r')
        {
            path.Push(new Pair(i, j));
            j++;
            field.Field[i, j].IsVisited = true;
            field.Field[i, j].PossibleWaysToGo--;
        }
        else if (direction == 'u')
        {
            path.Push(new Pair(i, j));
            i--;
            field.Field[i, j].IsVisited = true;
            field.Field[i, j].PossibleWaysToGo--;
        }
        else if (direction == 'e')
        {
            path.Push(new Pair(i, j));
            Pair currentIndexes = new Pair(i, j);
            while (path.Count() > 0 && field.Field[currentIndexes.I, currentIndexes.J].PossibleWaysToGo == 0)
            {
                currentIndexes = path.Pop();
                field.Field[currentIndexes.I, currentIndexes.J].Value = 1;
            }
            successWays++;
            break;
        }
    }
}

Console.WriteLine("Answer: {0}", successWays);





struct Pair
{
    public int I { get; set; }
    public int J { get; set; }

    public Pair(int i, int j)
    {
        this.I = i;
        this.J = j;
    }
}