global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Collections;
using Collection_M3L1.Models;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MyCollection<object> collection = new MyCollection<object>();
collection.Add("lol");
collection.Add("kek");
object[] someArray = new object[] { 1, 2, 3 };
collection.AddRange(someArray);
collection.Add("cheburek");

foreach (var item in collection)
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("\nBeginnign fun with sort method");

collection.Sort(2);

foreach (var item in collection)
{
    Console.WriteLine(item.ToString());
}

Console.WriteLine("\nBeginnign fun with remove methods");
collection.RemoveAt(0);
collection.Remove(1);
collection.Remove(3);

foreach (var item in collection)
{
    Console.WriteLine(item.ToString());
}

Console.ReadLine();
