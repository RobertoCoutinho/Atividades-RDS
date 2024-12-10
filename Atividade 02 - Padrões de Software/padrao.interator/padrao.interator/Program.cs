using System;
using System.Collections.Generic;

public class Program
{
    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
    }

    public static void PrintGeneric<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
    public static void Main(string[] args)
    {
        //essa parte exemplifica o problema, temos que ter duas funções para imprimir, uma para lista e outra para array
        //isso porque para descobrimos o tamanho de uma lista usamos a propriedade Count e para array a propriedade Length
        int[] numbersArray = { 1, 2, 3, 4, 5 };
        List<int> numbersList = new List<int> { 6, 7, 8, 9, 10 };

        Console.WriteLine("Imprimindo o array:");
        PrintArray(numbersArray);
        Console.WriteLine("Imprimindo a lista:");
        PrintList(numbersList);

        //essa parte exemplifica a solução que o padrão Iterator tras, usando a mesma função para printar uma lista e um array,
        //isso é possivel pois IEnumerable implementa o padrão Interator, então conseguimos interar sobre a coleção da mesma forma.
        IEnumerable<int> numbersCollectionArray = numbersArray;
        IEnumerable<int> numbersCollectionList = numbersList;
        Console.WriteLine("Imprimindo coleção Array:");
        PrintGeneric(numbersArray);
        Console.WriteLine("Imprimindo coleção Lista:");
        PrintGeneric(numbersList);

    }
}