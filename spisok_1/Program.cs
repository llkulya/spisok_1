using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int listSize = 100000;
        const int addSize = 1000;
        Random random = new Random();

        ArrayList arrayList = new ArrayList();
        LinkedList<int> linkedList = new LinkedList<int>();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nВиберiть операцiю для виконання:");
            Console.WriteLine("1. Заповнення списку даними");
            Console.WriteLine("2. Доступ до елементу (Random Access та Sequential Access)");
            Console.WriteLine("3. Вставка елементу на початок списку");
            Console.WriteLine("4. Вставка елементу в кiнець списку");
            Console.WriteLine("5. Вставка елементу в середину списку");
            Console.WriteLine("6. Вихiд з програми");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Time("Заповнення ArrayList", () => FillList(arrayList, listSize, random));
                        Time("Заповнення LinkedList", () => FillList(linkedList, listSize, random));
                        break;

                    case 2:
                        FillList(arrayList, listSize, random);
                        FillList(linkedList, listSize, random);

                        Time("Random Access ArrayList", () => RandomAccess(arrayList, random));
                        Time("Random Access LinkedList", () => RandomAccess(linkedList, random));

                        Time("Sequential Access ArrayList", () => SequentialAccess(arrayList));
                        Time("Sequential Access LinkedList", () => SequentialAccess(linkedList));
                        break;

                    case 3:
                        FillList(arrayList, listSize, random);
                        FillList(linkedList, listSize, random);

                        Time("Вставка на початок ArrayList", () => AddAtStart(arrayList, addSize));
                        Time("Вставка на початок LinkedList", () => AddAtStart(linkedList, addSize));
                        break;

                    case 4:
                        FillList(arrayList, listSize, random);
                        FillList(linkedList, listSize, random);

                        Time("Вставка в кiнець ArrayList", () => AddAtEnd(arrayList, addSize));
                        Time("Вставка в кiнець LinkedList", () => AddAtEnd(linkedList, addSize));
                        break;

                    case 5:
                        FillList(arrayList, listSize, random);
                        FillList(linkedList, listSize, random);

                        Time("Вставка в середину ArrayList", () => AddAtMiddle(arrayList, addSize));
                        Time("Вставка в середину LinkedList", () => AddAtMiddle(linkedList, addSize));
                        break;

                    case 6:
                        isRunning = false;
                        Console.WriteLine("Програма завершена.");
                        break;

                    default:
                        Console.WriteLine("Невiрний вибiр! Спробуйте ще раз.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть число.");
            }
        }
    }
    static void FillList(IList list, int size, Random random)
    {
        list.Clear();
        for (int i = 0; i < size; i++)
        {
            list.Add(random.Next(0, size));
        }
    }
    static void FillList(LinkedList<int> list, int size, Random random)
    {
        list.Clear();
        for (int i = 0; i < size; i++)
        {
            list.AddLast(random.Next(0, size));
        }
    }
    static void RandomAccess(IList list, Random random)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var _ = list[random.Next(0, list.Count)];
        }
    }
    static void RandomAccess(LinkedList<int> list, Random random)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int index = random.Next(0, list.Count);
            var node = GetNodeAt(list, index);
        }
    }
    static LinkedListNode<int> GetNodeAt(LinkedList<int> list, int index)
    {
        var node = list.First;
        for (int i = 0; i < index; i++)
        {
            node = node.Next;
        }
        return node;
    }
    static void SequentialAccess(IList list)
    {
        foreach (var item in list) { }
    }
    static void SequentialAccess(LinkedList<int> list)
    {
        foreach (var item in list) { }
    }
    static void AddAtStart(IList list, int size)
    {
        for (int i = 0; i < size; i++)
        {
            list.Insert(0, i);
        }
    }
    static void AddAtStart(LinkedList<int> list, int size)
    {
        for (int i = 0; i < size; i++)
        {
            list.AddFirst(i);
        }
    }
    static void AddAtEnd(IList list, int size)
    {
        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }
    }
    static void AddAtEnd(LinkedList<int> list, int size)
    {
        for (int i = 0; i < size; i++)
        {
            list.AddLast(i);
        }
    }
    static void AddAtMiddle(IList list, int size)
    {
        for (int i = 0; i < size; i++)
        {
            list.Insert(list.Count / 2, i);
        }
    }
    static void AddAtMiddle(LinkedList<int> list, int size)
    {
        var node = GetNodeAt(list, list.Count / 2);
        for (int i = 0; i < size; i++)
        {
            list.AddAfter(node, i);
        }
    }
    static void Time(string description, Action action)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        Console.WriteLine($"{description}: {stopwatch.ElapsedMilliseconds} ms");
    }
}
