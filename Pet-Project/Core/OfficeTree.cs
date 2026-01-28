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

        public Worker GetWorkerById(int id) 
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



        public List<Worker> GetAllWorkers()
        {
            List<Worker> result = new List<Worker>();
            CollectWorkersInOrder(_root, result);
            return result;
        }

        private void CollectWorkersInOrder(Node node, List<Worker> result)
        {
            if (node == null) return;

            // Рекурсивный обход "левый-узел-правый" (in-order)
            CollectWorkersInOrder(node.Left, result);  // 1. Левые
            result.Add(node.Worker);                    // 2. Текущий
            CollectWorkersInOrder(node.Right, result); // 3. Правые
        }

        public bool Remove(int id)
        {
            // Рекурсивный поиск и удаление
            _root = RemoveRecursive(_root, id, out bool removed);
            return removed;
        }


        // РАЗОБРАТЬ
        private Node RemoveRecursive(Node node, int id, out bool removed)
        {
            removed = false;
            if (node == null) return null;

            // Поиск узла
            if (id < node.Worker.ID)
                node.Left = RemoveRecursive(node.Left, id, out removed);
            else if (id > node.Worker.ID)
                node.Right = RemoveRecursive(node.Right, id, out removed);
            else
            {
                // УЗЕЛ НАЙДЕН - УДАЛЯЕМ
                removed = true;

                // Случай 1: Нет потомков или один потомок
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Случай 2: Два потомка
                // Находим минимальный в правом поддереве (преемника)
                Node successor = FindMin(node.Right);

                // Копируем данные преемника в текущий узел
                node.Worker = successor.Worker;

                // Рекурсивно удаляем преемника
                node.Right = RemoveRecursive(node.Right, successor.Worker.ID, out _);
            }

            return node;
        }

        private Node FindMin(Node node)
        {
            // Самый левый узел — минимальный
            while (node.Left != null)
                node = node.Left;
            return node;
        }
    }
}
