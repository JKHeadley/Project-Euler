using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    class Node
    {
        public Node Parent;
        public List<Node> Children;
        public int Value;
        public int Sum;
        public bool DeadBranch;
        public Node(int value)
        {
            Sum = 0;
            Value = value;
            DeadBranch = false;
        }
        public Node(Node parent, int value)
        {
            Sum = 0;
            Parent = parent;
            Value = value;
            DeadBranch = false;
        }
    }
    class MultisetTree
    {
        public List<Node> Root;
        public List<Node> Summations;
        public int Height;
        public long Size;
        public MultisetTree(List<int> set, int height)
        {
            Size = set.Count;
            Root = new List<Node>();
            foreach (int num in set)
            {
                Node node = new Node(num);
                Root.Add(node);
            }
            Height = height;

            for (int i = 0; i < Root.Count; i++)
            {
                RecursiveBuild(Root[i], i, Height);
            }
        }

        public MultisetTree(List<int> set, int height, int sumTo)
        {
            Size = set.Count;
            Summations = new List<Node>();
            Root = new List<Node>();
            foreach (int num in set)
            {
                Node node = new Node(num);
                Root.Add(node);
            }
            Height = height;

            for (int i = 0; i < Root.Count; i++)
            {
                RecursiveBuildWithSum(Root[i], i, Height, sumTo);
            }
        }

        private void RecursiveBuild(Node currentNode, int rootIndex, int height)
        {
            if (currentNode.Parent != null)
            {
                currentNode.Sum = currentNode.Value + currentNode.Parent.Sum;
            }
            else
            {
                currentNode.Sum = currentNode.Value;
            }
            if (height == 1)
            {
                return;
            }
            currentNode.Children = new List<Node>();
            for (int i = rootIndex; i < Root.Count; i++)
            {
                Node node = new Node(currentNode, Root[i].Value);
                currentNode.Children.Add(node);
                RecursiveBuild(node, i, height - 1);
            }
            return;
        }

        private void RecursiveBuildWithSum(Node currentNode, int rootIndex, int height, int sumTo)
        {
            if (currentNode.Parent != null)
            {
                currentNode.Sum = currentNode.Value + currentNode.Parent.Sum;
            }
            else
            {
                currentNode.Sum = currentNode.Value;
            }
            if (currentNode.Sum >= sumTo)
            {
                if (currentNode.Sum == sumTo)
                    Summations.Add(currentNode);
                currentNode.DeadBranch = true;
                currentNode.Parent.DeadBranch = true;
                return;
            }
            if (height == 1)
            {
                return;
            }
            currentNode.Children = new List<Node>();
            for (int i = rootIndex; i < Root.Count; i++)
            {
                if (!currentNode.DeadBranch)
                {
                    Node node = new Node(currentNode, Root[i].Value);
                    currentNode.Children.Add(node);
                    Size++;
                    RecursiveBuildWithSum(node, i, height - 1, sumTo);
                }
                else
                {
                    return;
                }
            }
            return;
        }

    }
}
