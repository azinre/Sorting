using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Helper
    {
        public static void Main()
        {            
            int size = 100;
            int[] arr = GenerateIntArrayWithRandValues(size);
            Console.WriteLine("Lab3 implrmrnrtrf by Azin RezaeianGhaargozlou\n");
            Console.WriteLine("The intial unsorted integer array is:\n");
            PrintIntArrayToConsole(arr);
            int[] copiedArray = new int[size];
            arr.CopyTo(copiedArray, 0);
            int swaps = BubbleSort(copiedArray);
            Console.WriteLine("\nBubble Sort made " + swaps + " swaps to sort the data.\n");
            Console.WriteLine("The Sorted array is:\n");
            PrintIntArrayToConsole(copiedArray);            
            string searchAgain;
            do
            {
                Console.WriteLine("Enter an integer to search in the sorted array: ");
                int searchKey = int.Parse(Console.ReadLine());
                int comparisonCount;
                int LinearIndex = LinearSearch(arr, searchKey, out comparisonCount);
                if (LinearIndex != -1)
                {
                    Console.WriteLine("The Linear search made " + comparisonCount + " comparisons to find out that " + searchKey + " is at index  " + LinearIndex + " in this unsorted array.");
                }
                else
                {
                    Console.WriteLine("Value NOT found in the array using Linear Search after " + comparisonCount + " comparisons.");
                    //Console.WriteLine("Number of comparisons: " + comparisonCount);
                }
                int comparisonCount2;
                int BinaryIndex = BinarySearch(copiedArray, searchKey, out comparisonCount2);
                if (BinaryIndex != -1)
                {
                    Console.WriteLine("The Binary search made " + comparisonCount2 + " comparison to find out that " + searchKey + " is at index  " + BinaryIndex + " in this sorted array.");                 
                }
                else
                {
                    Console.WriteLine("Value NOT found in the array using Binary Search after "+ comparisonCount + " comparisons.");
                    //Console.WriteLine("Number of comparisons: " + comparisonCount2);
                }
                Console.WriteLine("Do you want to search another integer? (y/n)");
                searchAgain = Console.ReadLine();

            } while (searchAgain == "y" || searchAgain == "Y");

            Console.WriteLine("\nPress Enter to exit");
            Console.Read();            
        }
        public static int[] GenerateIntArrayWithRandValues(int sizeOfArray)
        {
            Random random = new Random();
            int[] array = new int[sizeOfArray];
            for (int i = 0; i < sizeOfArray; i++)
            {
                array[i] = random.Next(0, 101);
            }
            return array;
        }
        public static void PrintIntArrayToConsole(int[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                Console.Write(arrayToPrint[i] + "\t");
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }
        }
        public static int LinearSearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                numOfComparison++;

                if (haystack[i] == niddle)
                {
                    return i;
                }

            }
            return -1;
        }
        public static int BubbleSort(int[] array)
        {
            int swaps = 0;
            bool isSorted;
            for (int i = 0; i < array.Length - 1; i++)
            {
                isSorted = true;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swaps++;
                        isSorted = false;
                    }
                }
                if (isSorted)
                    break;
            }
            return swaps;
        }
        public static int BinarySearch(int[] haystack, int niddle, out int numOfComparison)
        {

            numOfComparison = 0;
            int firstIndex = 0;
            int lastIndex = haystack.Length -1 ;
            while (firstIndex <= lastIndex)
            {
                int middleIndex = (firstIndex + lastIndex) / 2;
                numOfComparison++;
                try
                {
                    //Console.WriteLine(middleIndex);
                    if (haystack[middleIndex] == niddle)
                    {
                        return middleIndex;
                    }
                    else if (haystack[middleIndex] < niddle)
                    {
                        firstIndex = middleIndex + 1;
                    }
                    else
                    {
                        lastIndex = middleIndex - 1;
                    }

                    //if (lastIndex == firstIndex + 1)
                    //{
                    //    return -1;
                    //}
                }
                catch (IndexOutOfRangeException ex)
                {
                    // Handle the exception
                    Console.WriteLine("An index out of range exception occurred: " + ex.Message);
                    Console.WriteLine("Caught index: " + middleIndex);
                    return -1;
                }
            }
            return -1;
           
        }           
    }            
}


    


    