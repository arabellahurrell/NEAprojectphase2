using System;
using NEAproject.Models;
using System.Collections.Generic;
namespace NEAproject


{
    public class Helper
    {
        public static List<datapoint> getLineardatapoints(int n)
        {
            List<datapoint> result = new List<datapoint>();
            for (int i = 1; i <= n; i++)
            {
                datapoint temp = new datapoint(i.ToString(),i);
                result.Add(temp);

            }

            return result;
        }

        public static List<datapoint> getNtothe2points(int n)
        {
            List<datapoint> result = new List<datapoint>();
            for (int i = 1; i <= n; i++)
            {
                int isquared = i * i;
                datapoint temp = new datapoint(isquared.ToString(), isquared);
                result.Add(temp);
            }

            return result;
        }

        public static List<datapoint> get2totheNpoints(int n)
        {
            List<datapoint> result = new List<datapoint>();
            for (int i = 1; i <= n; i++)
            {
                var complexity = Math.Pow(2, i);
                //int data = (int) complexity;
                datapoint temp = new datapoint(complexity.ToString(),complexity);
                result.Add(temp);

            }

            return result;
        }

        public static int[] insertionsort(int[] array)
        {
            int value;
            int flag;
            for (int i = 1; i < array.Length; i++)
            {
                value = array[i];
                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1; )
                {
                    if (value < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = value;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
            }

            return array;
        }

        public static int lognfunction(int n)
        {
            int result;
            if (n > 1)
            {
                result = 1 + lognfunction(n / 2);
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public static List<datapoint> getlogn(int n)
        {
            List<datapoint> result = new List<datapoint>();
            for (int i = 1; i <= n; i++)
            {
                var complexity = lognfunction(i) ;
                //int data = (int) complexity;
                datapoint temp = new datapoint(i.ToString(),complexity);
                result.Add(temp);

            }

            return result;
        }
        public static List<datapoint> getnlogn(int n)
        {
            List<datapoint> result = new List<datapoint>();
            for (int i = 1; i <= n; i++)
            {
                var complexity = i*lognfunction(i) ;
                //int data = (int) complexity;
                datapoint temp = new datapoint(i.ToString(),complexity);
                result.Add(temp);

            }

            return result;
        }
        
        //logn
        //nlogn
    }
}

