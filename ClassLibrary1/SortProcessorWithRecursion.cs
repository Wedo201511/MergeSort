using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class SortProcessorWithRecursion
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
        public async Task SortWithRecursion()
        {
            Stopwatch ts = new Stopwatch();
            ts.Start();
            await Sort(originalArray, 0, originalArray.Length - 1);
            ts.Stop();
            Console.WriteLine(ts.ElapsedMilliseconds);
            Debug.WriteLine("timer is: " + ts.ElapsedMilliseconds);
        }
        public async Task Sort(int[] sourceArr, int startIndex, int endIndex)
        {
            if (endIndex - startIndex == 1)
            {
                if (sourceArr[startIndex] > sourceArr[endIndex])
                {
                    var temp = sourceArr[startIndex];
                    sourceArr[startIndex] = sourceArr[endIndex];
                    sourceArr[endIndex] = temp;
                }
            }
            if (startIndex < endIndex - 1)
            {
                int mid = (startIndex + endIndex) / 2;
                var t1 = Task.Run(() => Sort(sourceArr, startIndex, mid));
                var t2 = Task.Run(() => Sort(sourceArr, mid + 1, endIndex));
                await t1;
                await t2;
                MergeTwoNeighbour(sourceArr, startIndex, mid, endIndex);
            }
            return;
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
