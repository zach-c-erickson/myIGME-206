using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Unit_Test_3_Question_2
{

    public class Node 
    {
        public int nState;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;
     

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }

    public class LinkedNode
    {
        public string color;
        

        public int nextCost;
        public int prevCost;


        public LinkedNode link1;
        public LinkedNode link2;

        public int link1Cost;
        public int link2Cost;
        
    }

    class Program
    {

        // Red = 0 = R
        // Indigo = 1 = I
        // Grey = 2 = Gry
        // Blue = 3 = B
        // Yellow = 4 = Y
        // Orange = 5 = O
        // Purple = 6 = P
        // Green = 7 = Grn

        public enum Color
        {
            Red,
            Indigo,
            Grey,
            Blue,
            Yellow,
            Orange,
            Purple,
            Green
        }

       
        
        static int[,] mGraph = new int[,]
        {
                // R    I   Gry    B     Y     O     P    Grn
          /*R*/  {-1,   1,   5,   -1,   -1,   -1,   -1,   -1},
          /*I*/  {-1,  -1,  -1,    1,    8,   -1,   -1,   -1},
        /*Gry*/  {-1,  -1,  -1,    0,   -1,    1,   -1,   -1},
          /*B*/  {-1,   1,   0,   -1,   -1,   -1,   -1,   -1},
          /*Y*/  {-1,  -1,  -1,   -1,   -1,   -1,   -1,    6},
          /*O*/  {-1,  -1,  -1,   -1,   -1,   -1,    1,   -1},
          /*P*/  {-1,  -1,  -1,   -1,    1,   -1,   -1,   -1},
        /*Grn*/  {-1,  -1,  -1,   -1,   -1,   -1,   -1,   -1}
        };


        static int[][] lGraph = new int[][]
        {
               /*Red*/ new int[] { 1, 2 }, /* Indigo, Grey */
            /*Indigo*/ new int[] { 3, 4 }, /* Blue, Yellow */
              /*Grey*/ new int[] { 3, 5 }, /* Blue, Orange */
              /*Blue*/ new int[] { 1, 2 }, /* Indigo, Grey */
            /*Yellow*/ new int[] { 7 },    /* Green */
            /*Orange*/ new int[] { 6 },    /* Purple */
            /*Purple*/ new int[] { 4 },    /* Yellow */
             /*Green*/ null
        };

        static int[][] wGraph = new int[][]
        {
               /*Red*/ new int[] { 1, 5 },
            /*Indigo*/ new int[] { 1, 8 }, 
              /*Grey*/ new int[] { 0, 1 }, 
              /*Blue*/ new int[] { 1, 0 },
            /*Yellow*/ new int[] { 6 },
            /*Orange*/ new int[] { 1 }, 
            /*Purple*/ new int[] { 1 },
             /*Green*/ null
        };


        static List<Node> nodeList = new List<Node>();

        static LinkedList<LinkedNode> linkedNodeList = new LinkedList<LinkedNode>();

        static void Main(string[] args)
        {
            

            Node node;

            int i = 0;

            for(i = 0; i < lGraph.Length; ++i)
            {
                node = new Node(i);
                nodeList.Add(node);
            }

            for( i = 0; i < lGraph.Length; ++i)
            {
                int[] thisState = lGraph[i];
                int[] thisWeight = wGraph[i];

                if (thisState is null || thisWeight is null)
                {
                    continue;
                }
                else
                {
                    for (int wCntr = 0; wCntr < thisState.Length; ++wCntr)
                    {
                        nodeList[i].AddEdge(thisWeight[wCntr], nodeList[thisState[wCntr]]);
                    }
                }
                
            }

            List<Node> shortestPath = GetDijkstra();

            Console.Write("Depth-First Search: ");

            DFS(0);

            Console.WriteLine();

            Console.Write("Shortest Path: ");

            foreach(Node pathNode in shortestPath)
            {
                Console.Write((Color)pathNode.nState + " -> ");
            }

            Console.WriteLine();

            LinkedNode yellow = new LinkedNode();
            yellow.color = "Yellow";
            yellow.nextCost = 6;
            yellow.prevCost = 1;

            LinkedNode indigo = new LinkedNode();
            indigo.color = "Indigo";
            indigo.nextCost = 1;
            indigo.prevCost = -1;
            indigo.link1 = yellow;
            indigo.link1Cost = 8;

            LinkedNode blue = new LinkedNode();
            blue.color = "Blue";
            blue.nextCost = 0;
            blue.prevCost = 1;

            LinkedNode grey = new LinkedNode();
            grey.color = "Grey";
            grey.nextCost = 1;
            grey.prevCost = 0;

            LinkedNode orange = new LinkedNode();
            orange.color = "Orange";
            orange.nextCost = 1;
            orange.prevCost = 1;

            LinkedNode purple = new LinkedNode();
            purple.color = "Purple";
            purple.nextCost = 1;
            purple.prevCost = 1;

            LinkedNode green = new LinkedNode();
            green.color = "Green";
            green.nextCost = -1;
            green.prevCost = 6;

            LinkedNode red = new LinkedNode();
            red.color = "Red";
            red.link1 = indigo;
            red.link1Cost = 1;
            red.link2 = grey;
            red.link2Cost = 5;


            linkedNodeList.AddLast(indigo);
            linkedNodeList.AddLast(blue);
            linkedNodeList.AddLast(grey);
            linkedNodeList.AddLast(orange);
            linkedNodeList.AddLast(purple);
            linkedNodeList.AddLast(yellow);
            linkedNodeList.AddLast(green);
            linkedNodeList.AddLast(red);

            Console.WriteLine();

            Console.WriteLine("First Node: " + linkedNodeList.First.Value.color + "   Next Cost: " + linkedNodeList.First.Value.nextCost);

            Console.WriteLine();

            Console.WriteLine("Extra Node: " + linkedNodeList.Last.Value.color + "   Link Costs: " + linkedNodeList.Last.Value.link1Cost + ", " + linkedNodeList.Last.Value.link2Cost);

        }

        static void DFS(int nState)
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(nState, ref visited);
        }

        static void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;

            Console.Write((Color)v + " -> ");

            int[] thisStateList = lGraph[v];

            if(thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, ref visited);
                    }
                }
            }

            
        }

        static public List<Node> GetDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(nodeList[7]);
            BuildShortestPath(shortestPath, nodeList[7]);
            shortestPath.Reverse();
            return shortestPath;
        }

        static public void DijkstraSearch()
        {
            Node start = nodeList[0];

            start.minCostToStart = 0;
            List<Node> priorityQueue = new List<Node>();

            priorityQueue.Add(start);

            do
            {
                // priorityQueue.Sort();

                priorityQueue = priorityQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((n) => n.minCostToStart).ToList();
                priorityQueue = priorityQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = priorityQueue.First();
                priorityQueue.Remove(node);


                if (node == nodeList[7])
                {
                    return;
                }
                else
                {
                    foreach (Edge cnn in node.edges.OrderBy(e => e.cost).ToList())
                    {
                        Node childNode = cnn.connectedNode;
                        if (childNode.visited)
                        {
                            continue;
                        }

                        if (childNode.minCostToStart == int.MaxValue || node.minCostToStart + cnn.cost < childNode.minCostToStart)
                        {
                            childNode.minCostToStart = node.minCostToStart + cnn.cost;
                            childNode.nearestToStart = node;
                            if (!priorityQueue.Contains(childNode))
                            {
                                priorityQueue.Add(childNode);
                            }
                        }
                    }
                }

                

                node.visited = true;

                


            } while (priorityQueue.Any());

            
        }

        static public void BuildShortestPath(List<Node> list, Node node)
        {
            if(node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }



    }
}