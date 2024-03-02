namespace CodinGame;

class Program
{
    static void Main(string[] args)
    {
        
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        var nodes = new List<Node>();
        String[,] grid = new String[height,width];
        // Console.WriteLine($"width : {width} height={height}");
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            
            for (int x = 0; x < width; x++)
            {
                grid[i,x]=line[x].ToString();
                
            }
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[y, x] == "0")
                {
                    nodes.Add(new Node(x, y));
                }
            }
        }
        static Node FindRightNeighbor(Node node, String[,] grid, int w, int h)
        {
            for (int i = node.X + 1; i < w; i++)
            {
                if (grid[node.Y, i] == "0")
                {
                    return new Node(i, node.Y);
                }
            }

            return new Node(-1, -1);
        }

        static Node FindBottomNeighbor(Node node, String[,] grid, int w, int h)
        {
            for (int i = node.Y + 1; i < h; i++)
            {
                if (grid[i, node.X] == "0")
                {
                    return new Node(node.X, i);
                }
            }

            return new Node(-1, -1);
        }
        foreach (var node in nodes)
        {
            Node rightNeighbor = FindRightNeighbor(node, grid, width, height);
            Node bottomNeighbor = FindBottomNeighbor(node, grid, width, height);

            Console.WriteLine($"{node.X} {node.Y} {rightNeighbor.X} {rightNeighbor.Y} {bottomNeighbor.X} {bottomNeighbor.Y}");
        }

       
        
    }
}
class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public Node(int x, int y)
    {
        X = x;
        Y = y;
    }
}
