using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_3_Question_6
{
    class Program
    {

        public static List<int> TraverseAscending(BTree node)
        {
            if (node != null)
            {
                // handle "less than" children
                TraverseAscending(node.ltChild);

                if (node.isData)
                {
                    intList.Add(node.data);
                }

                // handle "greater than or equal to children"
                TraverseAscending(node.gteChild);

                
            }
            return intList;

        }
        static List<int> returnList = new List<int>();
        public static List<int> MedianList (List<int> nodeList)
        {
            if(nodeList.Count == 1)
            {
                returnList.Add(nodeList[0]);
            }
            else
            {
                if (nodeList.Count % 2 == 0)
                {
                    returnList.Add(nodeList[(nodeList.Count) / 2]);
                    MedianList(nodeList.GetRange(0, ((nodeList.Count) / 2) - 1));
                    MedianList(nodeList.GetRange(((nodeList.Count) / 2), ((nodeList.Count) / 2)));
                }
                else
                {
                    returnList.Add(nodeList[(nodeList.Count) / 2]);
                    MedianList(nodeList.GetRange(0, (nodeList.Count) / 2));
                    MedianList(nodeList.GetRange(((nodeList.Count) / 2) + 1, (nodeList.Count) / 2));
                }
            }
           

            return returnList;

            
        }


        public static List<int> intList = new List<int>();

        static void Main(string[] args)
        {

            BTree uNode = null;
            BTree uRoot = null;

            uNode = new BTree(1, null);
            uRoot = uNode;

            uNode = new BTree(5, uRoot);
            uNode = new BTree(15, uRoot);
            uNode = new BTree(20, uRoot);
            uNode = new BTree(21, uRoot);
            uNode = new BTree(22, uRoot);
            uNode = new BTree(23, uRoot);
            uNode = new BTree(24, uRoot);
            uNode = new BTree(25, uRoot);
            uNode = new BTree(30, uRoot);
            uNode = new BTree(35, uRoot);
            uNode = new BTree(37, uRoot);
            uNode = new BTree(40, uRoot);
            uNode = new BTree(55, uRoot);
            uNode = new BTree(60, uRoot);

            List<int> thisList = TraverseAscending(uRoot);

            List<int> balancedList = MedianList(thisList);

            Console.Write("Median List: ");

            for(int mInt = 0; mInt < balancedList.Count; ++mInt)
            {
                if (mInt == balancedList.Count - 1)
                {
                    Console.Write(balancedList[mInt]);
                }
                else
                {
                    Console.Write(balancedList[mInt] + ", ");
                }
            }

            Console.WriteLine();


            BTree bNode = null;
            BTree bRoot = null;

            uNode = new BTree(balancedList[0], null);
            bRoot = bNode;

            for(int i = 1; i < balancedList.Count; ++i)
            {
                uNode = new BTree(balancedList[i], bRoot);
            }

            List<int> thisBalancedList = TraverseAscending(bRoot);


            Console.Write("Tree in ascending order: ");

            for (int bInt = 0; bInt < thisBalancedList.Count; ++bInt)
            {
                if (bInt == thisBalancedList.Count - 1)
                {
                    Console.Write(thisBalancedList[bInt]);
                }
                else
                {
                    Console.Write(thisBalancedList[bInt] + ", ");
                }
            }







        }
    }

    public class BTree
    {
        
        // the "less than" branch off of this node
        public BTree ltChild;

        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        // the data contained in this node
        public int data;

        // a boolean to indicate if this is actual data or seed data to prime the tree
        public bool isData;


        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int data
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree
        public BTree(int nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            // if the new node >= the tree node (use the operator overrides)
            if (newNode >= treeNode)
            {
                // if there is not a child node greater than this tree node (ie. gteChild == null)
                if (treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                // the new node < this tree node
                // if there is not a child node less than this tree node (ie. ltChild == null)
                if (treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        // Delete a node from a tree or branch
        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode)
        {
            // base case: we reached the end of the branch
            if (treeNode == null)
            {
                return treeNode;
            }

            // traverse the tree to find the target node
            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                // this is the node to be deleted  

                // case #1: treeNode has no children
                // case #2: treeNode has one child
                // set treeNode to it's non-null child (if there is one)
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild;
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                // case #3: treeNode has two children
                // Get the in-order successor (smallest value  
                // in the "greater than or equal to" branch)  

                // step to the next greater value
                BTree nextValNode = treeNode.gteChild;

                // while not at the end of the branch
                while (nextValNode != null)
                {
                    // replace this "deleted" node with the next sequential data value
                    treeNode.data = nextValNode.data;

                    // walk to next lower value
                    nextValNode = nextValNode.ltChild;
                }

                // delete the in-order successor (which was copied to the "deleted" node)
                nodeToDelete.data = treeNode.data;
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }


        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        


      
       
    }

}
