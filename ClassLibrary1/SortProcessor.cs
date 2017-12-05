using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SortProcessor
    {
        static List<int[]> arrayList = new List<int[]>();
        static int[] originalArray;
        public void GenerateOriginalArray(int arrayLength)
        {
            originalArray = new int[arrayLength];
            var r = new Random();
            for (int i = 0; i < arrayLength; i++)
            {
                originalArray[i] = (int)(r.NextDouble() * 100);
            }
        }
        public bool VerifyIsAscending()
        {
            bool flag = true;
            for (int i = 0; i < originalArray.Length - 1; i++)
            {
                if (originalArray[i] > originalArray[i + 1])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public void SortWithMultyThreads(int threadCount)
        {
            Stopwatch ts = new Stopwatch();
            ts.Start();
            #region
    
            //Divide the array to threadCount parts，
            int point = originalArray.Length / threadCount;
            int k = 0;
            for (int i = 0; i < threadCount; i++)
            {
                int[] a = new int[0];   //store sub array
                //put all the remaining items in the last fraction group when 
                if (i != threadCount - 1) a = new int[point];
                if (i == threadCount - 1) a = new int[originalArray.Length - k];
                //copy array[k, k + a.length -1]  to [0, a.length]
                Array.Copy(originalArray, k, a, 0, a.Length);
                arrayList.Add(a); //put the sub array to arrayList
                k += point;  
            }
            //one group one thread
            TaskFactory tf = new TaskFactory();
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < threadCount; i++)
            {
                int j = i;
                int high = arrayList[j].Length;
                taskList.Add(tf.StartNew(() => Sort(arrayList[j])));
            }
            Task.WaitAll(taskList.ToArray());
            //Mergesort for the sub arrays,now each sub array is ascending
            MergeSortForResultOfThreads();
            #endregion
            ts.Stop();
            Console.WriteLine(ts.ElapsedMilliseconds);
            Debug.WriteLine("timer is: "+ts.ElapsedMilliseconds);
        }
        private void MergeSortForResultOfThreads()
        {           
            int k = 0;
            foreach (var item in arrayList)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    originalArray[k++] = item[i];
                }
            }
            //to do merge for the threads' results
            int gapLength = arrayList[0].Length;
            for (int gap = gapLength; gap < originalArray.Length; gap = 2 * gap)
            {
                MergePass(originalArray, gap, originalArray.Length);
            }
   
        }
        private int[] Sort(int[] list)
        {
            for (int gap = 1; gap < list.Length; gap = 2 * gap)
            {
                MergePass(list, gap, list.Length);
            }
            return list;
        }
        private void MergePass(int[] array, int gap, int length)
        {
            int i = 0;
            // merge two neighbour of gap length
            for (i = 0; i + 2 * gap - 1 < length; i = i + 2 * gap)
            {
                MergeTwoNeighbour(array, i, i + gap - 1, i + 2 * gap - 1);
            }

            // remaining 2 subArray and the length of 2nd one is less than gap
            if (i + gap - 1 < length)
            {
                MergeTwoNeighbour(array, i, i + gap - 1, length - 1);
            }
        }
        private void MergeTwoNeighbour(int[] sourceArr, int front, int mid, int end)
        {
            //Merge two neighbour
            int[] tempList = new int[end - front + 1];
            int s = front, m = mid + 1, index = 0;
            while (m <= end && s <= mid)
            {
                if (sourceArr[s] > sourceArr[m])
                {
                    tempList[index++] = sourceArr[m++];
                }
                else
                {
                    tempList[index++] = sourceArr[s++];
                }
            }
            while (m <= end)
            {
                tempList[index++] = sourceArr[m++];
            }
            while (s <= mid)
            {
                tempList[index++] = sourceArr[s++];
            }
            for (index = 0, s = front; s <= end; index++, s++)
            {
                sourceArr[s] = tempList[index];
            }
        }
    }
}
