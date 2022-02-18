using AaDSLab1;

Console.WriteLine("Enter size of the labyrinth:");
int n = Convert.ToInt32(Console.ReadLine());
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter k: ");
int k = Convert.ToInt32(Console.ReadLine());

Labyrinth field = new Labyrinth(n, m);
Labyrinth.ReadFromFile(field);
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
        Direction direction = field.GetDirection(i, j);
        switch(direction)
        {
            case Direction.DeadEnd:
                {
                    field.Field[i, j].IsVisited = true;
                    Pair tmp = path.Pop();
                    i = tmp.I;
                    j = tmp.J;
                    field.Field[i, j].IsVisited = true;
                    field.Field[i, j].PossibleWaysToGo--;
                    break;
                }
            case Direction.Left:
                {
                    path.Push(new Pair(i, j));
                    j--;
                    field.Field[i, j].IsVisited = true;
                    field.Field[i, j].PossibleWaysToGo--;
                    break;
                }
            case Direction.Down:
                {
                    path.Push(new Pair(i, j));
                    i++;
                    field.Field[i, j].IsVisited = true;
                    field.Field[i, j].PossibleWaysToGo--;
                    break;
                }
            case Direction.Right:
                {
                    path.Push(new Pair(i, j));
                    j++;
                    field.Field[i, j].IsVisited = true;
                    field.Field[i, j].PossibleWaysToGo--;
                    break;
                }
            case Direction.Up:
                {
                    path.Push(new Pair(i, j));
                    i--;
                    field.Field[i, j].IsVisited = true;
                    field.Field[i, j].PossibleWaysToGo--;
                    break;
                }
            default:
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
}

Console.WriteLine("Answer: {0}", successWays);