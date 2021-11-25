using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
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

    class Program
    {
        static void Main(string[] args)
        {

            Node n1 = new Node(0);
            Node n2 = new Node(1);

            List<Node> nodeList = new List<Node>();
            List<Node> queue = new List<Node>();

            nodeList.Add(n1);
            nodeList.Add(n2);



            Node start = nodeList[0];

            start.minCostToStart = 0;

            queue.Add(start);

            Node node = queue.First();

            queue.Remove(node);

            node.visited = true;


            if (nodeList[0].visited) { Console.WriteLine(nodeList[0].minCostToStart); }
        }
    }
}
