using SinglyLinkedList;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        #region Linked List
        //Node node = new Node { Value = 1 };
        //Node node1 = new Node { Value = 3 };
        //Node node2 = new Node { Value = 8 };
        //Node node3 = new Node { Value = 5 };

        //node.Next = node1;
        //node1.Next = node2;
        //node2.Next = node3;
        //node3.Next = null!;

        //NodeService nodeService = new NodeService();
        //nodeService.RemoveIndex(node, 1);
        #endregion


        int[] array = { 1, 3, 5, 2, 9, 8, 7, 3, 5, 6, 4 };
        SortService sortService = new SortService();
        sortService.InsertionSort(array);


    }
    public class SortService
    {
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            Console.WriteLine("Result: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
            Console.WriteLine("Result: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void InsertionSort(int[] array)
        {
            int j;
            int index;
            int temp0;
            for (int i = 1; i < array.Length ; i++)
            {
                j = i - 1;
                index = i;
                temp0 = array[i];
                while (j >= 0)
                {
                    if (temp0 < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                    i--;
                    j--;
                }
                i = index;
            }
            Console.WriteLine("Result: ");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class NodeService
    {
        public NodeService() { }

        public void PrintNode(Node head)
        {
            if (head.Next == null)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                Node temp = head;
                while (temp != null)
                {
                    Console.WriteLine(temp.Value);
                    if (temp.Next != null)
                    {
                        Console.WriteLine(" -->");
                    }
                    temp = temp.Next;
                }
            }

        }

        public void AddHead(Node head, int newValue)
        {
            Node newNode = new Node { Value = newValue };
            if (head == null)
            {
                PrintNode(newNode);
            }
            else
            {
                newNode.Next = head;
                PrintNode(newNode);
            }
        }

        public void AddLast(Node head, int newValue)
        {
            Node newNode = new Node { Value = newValue };
            if (head == null)
            {
                PrintNode(newNode);
            }
            else
            {
                Node temp = head;
                while (temp != null)
                {
                    Console.WriteLine(temp);
                    if (temp.Next == null)
                    {
                        temp.Next = newNode;
                        newNode.Next = null!;
                    }
                    temp = temp.Next;
                }
                PrintNode(head);
            }
        }

        public void AddIndex(Node head, int newValue, int index)
        {
            Node newNode = new Node { Value = newValue };
            if (head == null) { PrintNode(newNode); }
            else
            {
                Node temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    if (count == index)
                    {
                        newNode.Next = temp.Next;
                        temp.Next = newNode;
                    }
                    temp = temp.Next;
                }
                PrintNode(head);
            }
        }

        public void RemoveHead(Node head)
        {
            if (head == null || head.Next == null)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                Node newHead = head.Next;
                head.Next = null!;
                PrintNode(newHead);
            }
        }

        public void RemveLast(Node head)
        {
            if (head == null || head.Next == null)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.Next.Next == null)
                    {
                        temp.Next = null!;
                    }
                    temp = temp.Next;
                }
                PrintNode(head);
            }
        }

        public void RemoveIndex(Node head, int index)
        {
            if (head == null || head.Next == null)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                if (index == 0)
                {
                    Node temp = head.Next;
                    head.Next = null!;
                    PrintNode(temp);
                }
                else
                {
                    int count = 0;
                    Node temp = head;
                    while (temp != null)
                    {
                        count++;
                        if (count == index)
                        {
                            temp.Next = temp.Next.Next;
                        }
                        else
                        {
                            temp = temp.Next;
                        }
                    }
                    PrintNode(head);
                }
            }
        }
    }
}