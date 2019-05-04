using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of an array that you want to sort:");
            int n = int.Parse(Console.ReadLine());

            Stopwatch stp = new Stopwatch();
            double bubble = 0, insertion = 0, qui = 0, hip = 0, merge = 0;

            Random rd = new Random();
            int[] ar = new int[n];

            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = rd.Next(-50, 10000);
            }
            //foreach(int x in ar)
            //{
            //    Console.Write(x + ", ");
            //}

            Console.WriteLine("Select which algorithm you want to perform:");
            Console.Write("1. Insertion sort\n2. Bubble sort\n3. Quick sort\n4. Heap sort\n5. Merge sort\n6. All");
            Console.WriteLine();

            string st = Console.ReadLine();

            for (int i = 0; i < st.Length; i++)
            {
                //stugum e, te mutq arvac simvolner@ mijakayq en,te voch
                if (st.Length == 3 && st[1] == '-')
                {
                    //ete ayo,stugum e mijakayqi sahmannery
                    if (st[1] == '-' && st[0] == '1' && st[2] == '3')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion1 = InsertionSort.Sort(ar);
                        Print(arrInsertion1);
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '1' && st[2] == '2')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion1 = InsertionSort.Sort(ar);
                        Print(arrInsertion1);
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '1' && st[2] == '4')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion1 = InsertionSort.Sort(ar);
                        Print(arrInsertion1);
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '1' && st[2] == '5')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion1 = InsertionSort.Sort(ar);
                        Print(arrInsertion1);
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        Console.WriteLine("__MERGE SORT__");
                        int[] arrMerge = MergeSort.Sort(ar);
                        Print(arrMerge);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '2' && st[2] == '4')
                    {
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '2' && st[2] == '5')
                    {
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        Console.WriteLine("__MERGE SORT__");
                        int[] arrMerge = MergeSort.Sort(ar);
                        Print(arrMerge);
                        break;
                    }
                    else if (st[1] == '-' && st[0] == '3' && st[2] == '5')
                    {
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        Console.WriteLine("__MERGE SORT__");
                        int[] arrMerge = MergeSort.Sort(ar);
                        Print(arrMerge);
                        break;
                    }
                }
                else
                {
                    if (st[i] == '1')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion = InsertionSort.Sort(ar);
                        Print(arrInsertion);
                    }
                    else if (st[i] == '2')
                    {
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble = BubbleSort.Sort(ar);
                        Print(arrBubble);
                    }
                    else if (st[i] == '3')
                    {
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, ar.Length - 1);
                        Print(quick);
                    }
                    else if (st[i] == '4')
                    {
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                    }
                    else if (st[i] == '5')
                    {
                        Console.WriteLine("__MERGE SORT__");
                        int[] arrMerge = MergeSort.Sort(ar);
                        Print(arrMerge);
                    }
                    else if (st[i] == '6')
                    {
                        Console.WriteLine("__INSERTION SORT__");
                        int[] arrInsertion1 = InsertionSort.Sort(ar);
                        Print(arrInsertion1);
                        Console.WriteLine("__BUBBLE SORT__");
                        int[] arrBubble1 = BubbleSort.Sort(ar);
                        Print(arrBubble1);
                        Console.WriteLine("__QUICK SORT__");
                        int[] quick = ar;
                        QuickSort.Sort(quick, 0, quick.Length - 1);
                        Print(quick);
                        Console.WriteLine("__HEAP SORT__");
                        int[] heap = ar;
                        HeapSort.Sort(heap, ar.Length);
                        Print(heap);
                        Console.WriteLine("__MERGE SORT__");
                        int[] arrMerge1 = MergeSort.Sort(ar);
                        Print(arrMerge1);
                    }
                }
            }
            //Runtime-i tpum@
            Console.WriteLine("\n");

            double[] time = { InsertionSort.insertionTime, BubbleSort.bubbleTime, QuickSort.quickTime, HeapSort.hipTime, MergeSort.mergeTime };
            int num = 0;
            double min = time[0];

            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] != 0)
                {
                    num = i;
                    min = time[i];
                    break;
                }
            }

            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] < min && time[i] != 0)
                {
                    min = time[i];
                    num = i;
                }
            }
            Console.WriteLine("Sorting runtimes are : ");
            for (int i = 0; i < time.Length; i++)
            {
                if (time[i] != 0)
                {
                    if (i == num)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(time[i] + " ms, ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(time[i] + " ms, ");
                }
            }
            Console.WriteLine();

            //Memory using-i tpum@

            long[] memory = { InsertionSort.insertionMem, BubbleSort.bubbleMem, QuickSort.quickMem, HeapSort.hipMem, MergeSort.mergeMem };
            int num1 = 0;
            double max = memory[0];

            for (int i = 0; i < memory.Length; i++)
            {
                if (memory[i] != 0)
                {
                    num1 = i;
                    max = memory[i];
                    break;
                }
            }

            for (int i = 0; i < memory.Length; i++)
            {
                if (memory[i] > max && memory[i] != 0)
                {
                    max = memory[i];
                    num1 = i;
                }
            }
            Console.WriteLine("Sorting methods memory : ");

            for (int i = 0; i < memory.Length; i++)
            {
                if (memory[i] != 0)
                {
                    if (i == num1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(memory[i] + " byte, ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(memory[i] + " byte, ");
                }
            }
            Console.WriteLine();
        }

        public static void Print(int[] ar)
        {
            foreach (int x in ar)
                Console.Write(x + ", ");
            Console.WriteLine();
        }
    }
    class BubbleSort
    {
        public static double bubbleTime;
        public static long bubbleMem;

        public static int[] Sort(int[] ar)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            int a = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int k = 0; k < ar.Length - 1; k++)
                {
                    if (ar[k] > ar[k + 1])
                    {
                        a = ar[k];
                        ar[k] = ar[k + 1];
                        ar[k + 1] = a;
                    }
                }
            }
            stp.Stop();
            bubbleTime = stp.Elapsed.TotalMilliseconds;
            bubbleMem = GC.GetTotalMemory(false);
            return ar;
        }
    }

    class InsertionSort
    {
        public static long insertionMem;
        public static double insertionTime;

        public static int[] Sort(int[] ar)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            int h = 0;
            for (int i = 0; i < ar.Length - 1; i++)
            {
                for (int k = i + 1; k > 0; k--)
                {
                    if (ar[k - 1] > ar[k])
                    {
                        h = ar[k - 1];
                        ar[k - 1] = ar[k];
                        ar[k] = h;
                    }
                }
            }
            stp.Stop();
            insertionTime = stp.Elapsed.TotalMilliseconds;
            insertionMem = GC.GetTotalMemory(false);
            return ar;
        }
    }

    class MergeSort
    {
        public static long mergeMem;
        public static double mergeTime;

        public static int[] Sort(int[] ar)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            if (ar.Length < 2)
            {
                return ar;
            }

            int mid = ar.Length / 2;
            int[] left = new int[mid];
            int[] right;

            if (ar.Length % 2 == 0)
            {
                right = new int[mid];
            }
            else
            {
                right = new int[mid + 1];
            }
            //masiivy bajanum enq 2 masivneri
            for (int i = 0; i < mid; i++)
            {
                left[i] = ar[i];
            }
            int g = 0;
            for (int i = mid; i < ar.Length; i++)
            {
                right[g] = ar[i];
                g++;
            }
            left = Sort(left);
            right = Sort(right);
            stp.Stop();
            mergeTime = stp.Elapsed.TotalMilliseconds;
            mergeMem = GC.GetTotalMemory(false);

            return Compare(left, right);
        }

        static int[] Compare(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }

    class QuickSort
    {
        public static double quickTime;
        public static long quickMem;
        public static void Sort(int[] ar, int start, int end)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            if (start >= end)
            {
                return;
            }
            int pivot = partition(ar, start, end);
            Sort(ar, start, pivot - 1);
            Sort(ar, pivot + 1, end);
            stp.Stop();
            quickTime = stp.Elapsed.TotalMilliseconds;
            quickMem = GC.GetTotalMemory(false);
        }
        static int partition(int[] array, int start, int end)
        {
            int a;
            int mark = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    a = array[mark];
                    array[mark] = array[i];
                    array[i] = a;
                    mark += 1;
                }
            }

            a = array[mark];
            array[mark] = array[end];
            array[end] = a;
            return mark;
        }

    }

    class HeapSort
    {
        public static double hipTime;
        public static long hipMem;

        public static void Sort(int[] arr, int n)
        {
            Stopwatch stp = new Stopwatch();
            stp.Start();
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
            stp.Stop();
            hipTime = stp.Elapsed.TotalMilliseconds;
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }
    }
}
