using AaDSLab1;

Console.WriteLine("Enter size of the labyrinth:");
int lines = Convert.ToInt32(Console.ReadLine());
int columns = Convert.ToInt32(Console.ReadLine());

Labyrinth field = new Labyrinth(lines, columns);
Labyrinth.ReadFromFile(field);
field.Write();

Stack<Pair> path = new Stack<Pair>();

int successWays = 0;
for (int j = 0; j < columns; j++)
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
                    Pair indexes = path.Pop();
                    i = indexes.I;
                    j = indexes.J;
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
                    Pair indexes = new Pair(i, j);
                    while (path.Count() > 0 && field.Field[indexes.I, indexes.J].PossibleWaysToGo == 0)
                    {
                        indexes = path.Pop();
                        field.Field[indexes.I, indexes.J].Value = 1;
                    }
                    successWays++;
                    i++;
                    break;
                }
        }
        if (i == lines)
        {
            break;
        }
    }
}

Console.WriteLine("Answer: {0}", successWays);