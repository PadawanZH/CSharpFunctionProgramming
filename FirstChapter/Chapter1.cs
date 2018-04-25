using System;
using System.Text;

namespace FirstChapter
{
    public class Chapter
    {
        
        /*
         * Delegate
         */
        
        public delegate bool IsGreaterThanDelegate(object a, object b);

        public bool IsGreaterThan_Int(object a, object b)
        {
            return (int) a > (int) b;
        }

        public bool IsGreateThan_Double(object a, object b)
        {
            return (double) a > (double) b;
        }

        public void BubbleSort(object[] array, IsGreaterThanDelegate isGreateThan)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (isGreateThan(array[i], array[i + 1]))
                    {
                        object temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        public void PrintArray(Object[] array)
        {
            foreach (var obj in array)
            {
                Console.Write("{0} ", obj);
            }
            Console.WriteLine();
        }

        public void Run()
        {
            object[] doubleArray = {3.1, 2.2, 1.4, 4.2, 5.2, 0.3};
            object[] intArray = {1, 2, 4, 2, 5, 1, 3, 6};
            
            BubbleSort(doubleArray, IsGreateThan_Double);
            BubbleSort(intArray, IsGreaterThan_Int);
            
            PrintArray(doubleArray);
            PrintArray(intArray);
            
            object[] intArray_1 = {1, 2, 4, 2, 5, 1, 3, 6};
            LambdaBubbleSort(intArray_1);
        }
        
        /*
         * Lambda Function
         */

        public void LambdaBubbleSort(object[] intArray)
        {
            IsGreaterThanDelegate isGreateThan_Int_1 = (a, b) => { return (int) a > (int) b; };
            //you can do this when the function is just a return
            IsGreaterThanDelegate isGreateThan_Int_2 = (a, b) => (int) a > (int) b;
            
            BubbleSort(intArray, isGreateThan_Int_2);
            PrintArray(intArray);
        }

        public void DifferentLambdaExpression()
        {
            //The keywork Func, take last type-info as return type, the rest is the argument
            Func<int, int, int> Add_int = (a, b) => a + b;
            
        }
      
    }

    namespace ExtensionNamespace
    {
        public static class ExtensionHelper
        {
            public static string Concat(this string[] stringArray, string seperator)
            {
                bool first = true;
                var builder = new StringBuilder();
                foreach (var item in stringArray)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        builder.Append(seperator);
                    }

                    builder.Append(item);
                }

                return builder.ToString();
            }
        }
    } 
}

namespace UseExtension
{
    using FirstChapter.ExtensionNamespace;

    public class ExtensionHelperTesting
    {
        public void useStringExtensionMethod()
        {
            string[] strings = {"123", "abc", "xyz"};
            //call the extended method from string[] variable
            Console.WriteLine(strings.Concat(" # "));
        }
    }  
}