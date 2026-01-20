using Pet_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Core
{
    internal class OfficeTree
    {
        // Внутренний приватный класс узла. Он знает о Worker.
        private class Node
        {
            public Worker Worker { get; set; } // Храним целого сотрудника
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node _root; // Единственная приватная переменная — корень.


        public void Add(Worker worker) 
        { 
            Node currentNode = _root;
            if (currentNode == null)
            { _root = new Node() { Worker = worker}; return; }

            while (currentNode != null)
            {
                if (worker.ID < currentNode.Worker.ID)
                { 
                    if(currentNode.Left == null)
                    {
                        currentNode.Left = new Node() { Worker = worker };
                        return;
                    }
                    currentNode = currentNode.Left; 
                }

                else if (worker.ID > currentNode.Worker.ID)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new Node() { Worker = worker };
                        return;
                    }
                    currentNode = currentNode.Right; 
                }
            }
        } 

        public Worker FindById(int id) 
        {
            Node currentNode = _root;

            while (currentNode != null)
            {
                if (currentNode.Worker.ID == id)
                {
                    return currentNode.Worker;
                }

                else if ( currentNode.Worker.ID < id)
                {
                    currentNode = currentNode.Left;
                }

                else if ( currentNode.Worker.ID > id)
                {
                    currentNode = currentNode.Right;
                }
            }
            return null;
        } 

        public void PrintInOrder() 
        {
            if (_root == null) return;
            else { PrintInOrderRecursive(_root); }

        }

        // ВОПРОС Нужно переделать, чтобы возвращал строку?
        private void PrintInOrderRecursive(Node node) // Как это работает.....
        {
            if (node == null) return;
            PrintInOrderRecursive(node.Left);
            Console.WriteLine(node.Worker.ID + " " + node.Worker.MainInfo);
            PrintInOrderRecursive(node.Right);
        }
    }
}
