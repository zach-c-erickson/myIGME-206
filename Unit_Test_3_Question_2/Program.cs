using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Author: Zachary Erickson
// Purpose: Unit Test 3 Questions 2-5

namespace Unit_Test_3_Question_2
{
    // Class: Node
    // Purpose: Used for Dijkstra's Algorithm
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

    // Class: Edge
    // Purpose: Used for Dijkstra's Algorithm
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

    // Class: LinkedNode
    // Purpose: Used for LinkedList
    public class LinkedNode
    {

        // color string
        public string color;

        // bool stating if the node is on the connected path
        public bool connected;
        
        // holds the costs of the connected path weights
        public int nextCost;
        public int prevCost;

        // used for LinkedNodes that are outside the connected path
        public LinkedNode link1;
        public LinkedNode link2;

        // used for weights of the previous links
        public int link1Cost;
        public int link2Cost;
        
    }

    // Class: Program
    // Purpose: Questions 2-5 in order
    class Program
    {
        // Key for color indexes and abreviations

        // Red = 0 = R
        // Indigo = 1 = I
        // Grey = 2 = Gry
        // Blue = 3 = B
        // Yellow = 4 = Y
        // Orange = 5 = O
        // Purple = 6 = P
        // Green = 7 = Grn

        // Create an enum to use index to access color string
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

       
        // Adjacent Matrix (indicates a link from row to column, number indicates weight)
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

        // Adjacent list
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

        // Weight list
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


        // Create the nodeList and LinkedLists
        static List<Node> nodeList = new List<Node>();

        static LinkedList<LinkedNode> linkedNodeList = new LinkedList<LinkedNode>();


        // Method: Main
        // Purpose: Starts with Depth-First Search, then fills out the nodeList for Dijkstra's Algorithm and runs the algorithm, then creates the LinkedList
        static void Main(string[] args)
        {         
            
            /************** Depth-First Search ******************/

            Console.Write("Depth-First Search: ");

            // Call the Depth-First Search method on the first node (Red)

            DFS(0);


            /************** Dijkstra's Algorithm ******************/


            // Intialize node and counter
            Node node;
            int i = 0;


            // Add each node to the nodeList
            for(i = 0; i < lGraph.Length; ++i)
            {
                node = new Node(i);
                nodeList.Add(node);
            }

            // Add the edge list for each node
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

            // Call the GetDijkstra method and save the result as shortestPath
            List<Node> shortestPath = GetDijkstra();

            Console.WriteLine();

            Console.Write("Shortest Path: ");

            // Print each node's color in order
            foreach(Node pathNode in shortestPath)
            {
                Console.Write((Color)pathNode.nState + " -> ");
            }


            /************** LinkedList ******************/

            Console.WriteLine();


            // Create nodes for each color
            LinkedNode yellow = new LinkedNode();
            yellow.color = "Yellow";
            yellow.nextCost = 6;
            yellow.prevCost = 1;
            yellow.connected = true;

            LinkedNode indigo = new LinkedNode();
            indigo.color = "Indigo";
            indigo.nextCost = 1;
            indigo.prevCost = -1;
            indigo.link1 = yellow;
            indigo.link1Cost = 8;
            indigo.connected = true;

            LinkedNode blue = new LinkedNode();
            blue.color = "Blue";
            blue.nextCost = 0;
            blue.prevCost = 1;
            blue.connected = true;

            LinkedNode grey = new LinkedNode();
            grey.color = "Grey";
            grey.nextCost = 1;
            grey.prevCost = 0;
            grey.connected = true;

            LinkedNode orange = new LinkedNode();
            orange.color = "Orange";
            orange.nextCost = 1;
            orange.prevCost = 1;
            orange.connected = true;

            LinkedNode purple = new LinkedNode();
            purple.color = "Purple";
            purple.nextCost = 1;
            purple.prevCost = 1;
            purple.connected = true;

            LinkedNode green = new LinkedNode();
            green.color = "Green";
            green.nextCost = -1;
            green.prevCost = 6;
            green.connected = true;

            // red is not included in the connected path

            LinkedNode red = new LinkedNode();
            red.color = "Red";
            red.link1 = indigo;
            red.link1Cost = 1;
            red.link2 = grey;
            red.link2Cost = 5;
            red.connected = false;

            // Add each node to the LinkedList

            linkedNodeList.AddLast(indigo);
            linkedNodeList.AddLast(blue);
            linkedNodeList.AddLast(grey);
            linkedNodeList.AddLast(orange);
            linkedNodeList.AddLast(purple);
            linkedNodeList.AddLast(yellow);
            linkedNodeList.AddLast(green);
            linkedNodeList.AddLast(red);


            // Example code to show functionality
            Console.WriteLine();

            Console.WriteLine("First Node: " + linkedNodeList.First.Value.color + "   Next Cost: " + linkedNodeList.First.Value.nextCost);

            Console.WriteLine();

            Console.WriteLine("Extra Node: " + linkedNodeList.Last.Value.color + "   Link Costs: " + linkedNodeList.Last.Value.link1Cost + ", " + linkedNodeList.Last.Value.link2Cost);

        }

        // Method: DFS
        // Purpose: create visited bool array, call DFSUtil with parameters of index and the bool array
        static void DFS(int nState)
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(nState, ref visited);
        }

        // Method: DFSUtil
        // Purpose: Recursive function that prints out the Depth-First Search
        static void DFSUtil(int v, ref bool[] visited)
        {
            // mark that the index was visited
            visited[v] = true;

            // print the color
            Console.Write((Color)v + " -> ");

            // retrieve the adjacent nodes
            int[] thisStateList = lGraph[v];

            // if there are adjacent nodes
            if(thisStateList != null)
            {
                // for each adjacent node, if it hasn't been visited, call the function on the index.
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, ref visited);
                    }
                }
            }

            
        }

        // Method: GetDijkstra
        // Purpose: returns a Node List containing Dijkstra's shortest path 
        static public List<Node> GetDijkstra()
        {
            // Calls DijkstraSearch
            DijkstraSearch();

            // Initialize return List
            List<Node> shortestPath = new List<Node>();

            // Add the final node to shortestPath
            shortestPath.Add(nodeList[7]);

            // Call BuildShortestPath
            BuildShortestPath(shortestPath, nodeList[7]);

            // Reverse the List
            shortestPath.Reverse();

            // return the shortest path
            return shortestPath;
        }


        // Method: DijkstraSearch
        // Purpose: Finds the nearestToStart Node for each Node in nodeList
        static public void DijkstraSearch()
        {

            // Set the first Node to start
            Node start = nodeList[0];

            // Set minCostToStart to 0
            start.minCostToStart = 0;

            // Create the priority queue
            List<Node> priorityQueue = new List<Node>();

            // Add first node to the priority queue
            priorityQueue.Add(start);

            // while the priority queue is not empty
            do
            {
                // priorityQueue.Sort();

                // Sort the priority queue based on minCostToStart

                priorityQueue = priorityQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                priorityQueue = priorityQueue.OrderBy((n) => n.minCostToStart).ToList();
                priorityQueue = priorityQueue.OrderBy(n => n.minCostToStart).ToList();

                // Set node to the Node with the smallest minCostToStart in the queue
                Node node = priorityQueue.First();

                // Remove this node
                priorityQueue.Remove(node);

                // if this is the final node, return
                if (node == nodeList[7])
                {
                    return;
                }

                // otherwise
                else
                {
                    // Get the edges from the node, ordered by their cost
                    foreach (Edge cnn in node.edges.OrderBy(e => e.cost).ToList())
                    {
                        // Set childNode to the edge's connected node
                        Node childNode = cnn.connectedNode;

                        // if the node has already been visited, continue
                        if (childNode.visited)
                        {
                            continue;
                        }

                        // otherwise, if the minCostToStart is still the default value, or it is greater than the parent node's
                        // minCostToStart + the edge cost, then set the child's minCost to the parents cost plus the weight cost, and set the child's nearestToStart node as the
                        // parent. Finally, add the child to the priority queue
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

                
                // set the parent visited bool to true
                node.visited = true;

                


            } while (priorityQueue.Any());

            
        }

        // Method: BuildShortestPath
        // Purpose: Starting with the last node, uses the nearestToStart node to build the path back to the start
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