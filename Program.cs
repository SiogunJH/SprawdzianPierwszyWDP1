namespace System
{
    public class Program
    {
        static void Main()
        {
            int[] a = new int[] { -2, -1, 0, 1, 4 }; ;
            int[] b = new int[] { -2, -1, 0, 1, 4, 5, 6 };
            Print(a, b);
        }
        public static void Print(int[] a, int[] b)
        {
            bool isUnique;
            bool isEmpty = true;
            int ia = 0;
            int ib = 0;
            while (ia != a.Length || ib != b.Length)
            {
                if (ia != a.Length && (ib == b.Length || a[ia] < b[ib]))
                {
                    if (ia > 0 && a[ia] == a[ia - 1])
                    {
                        ia++;
                        continue;
                    }

                    isUnique = true;
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (a[ia] == b[i]) isUnique = false;
                    }
                    if (isUnique)
                    {
                        isEmpty = false;
                        Console.Write("{0} ", a[ia]);
                    }
                    ia++;
                }
                else
                {
                    if (ib > 0 && b[ib] == b[ib - 1])
                    {
                        ib++;
                        continue;
                    }

                    isUnique = true;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (b[ib] == a[i]) isUnique = false;
                    }
                    if (isUnique)
                    {
                        isEmpty = false;
                        Console.Write("{0} ", b[ib]);
                    }
                    ib++;
                }
            }
            if (isEmpty) Console.Write("empty");
        }
        static void SumToSum()
        {
            try
            {
                checked
                {
                    int[] dataArray = new int[4];
                    for (int i = 0; i < dataArray.Length; i++)
                    {
                        string userInput = Console.ReadLine();
                        if (userInput == "" || userInput == null) throw new ArgumentException();

                        dataArray[i] = int.Parse(userInput);
                    }

                    for (int i = 0; i < dataArray.Length; i++)
                    {
                        for (int j = i; j < dataArray.Length; j++)
                        {
                            if (i == j) continue;
                            for (int k = 0; k < dataArray.Length; k++)
                            {
                                if (k == j || k == i) continue;
                                for (int h = 0; h < dataArray.Length; h++)
                                {
                                    if (h == j || h == i || h == k) continue;
                                    if (dataArray[i] + dataArray[j] == dataArray[k] + dataArray[h])
                                    {
                                        Console.WriteLine("yes");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine("no");
                    return;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("argument exception, exit");
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception, exit");
            }
            catch (OverflowException)
            {
                Console.WriteLine("overflow exception, exit");
            }
            catch (Exception)
            {
                Console.WriteLine("non supported exception, exit");
            }
        }

        /// <summary>
        /// Oblicza obwód trójkąta równoramiennego dla zadanych długości: podstawy oraz wysokości opuszczonej na podstawę, zaokrąglając wynik do podanej liczby cyfr po przecinku
        /// </summary>
        /// <param name="basis">długość podstawy, liczba całkowita nieujemna</param>
        /// <param name="height">długość wysokości opuszczonej na podstawę, liczba całkowita nieujemna</param>
        /// <param name="precision">dokładność obliczeń (zaokrąglenie), liczba cyfr po przecinku (od 2 do 8)</param>
        /// <returns>pole trójkąta obliczone z zadaną dokładnością</returns>
        /// <exception cref="ArgumentOutOfRangeException">z komunikatem "wrong arguments", 
        ///     gdy <c>precision</c> jest poza przedziałem od 2 do 8 lub którakolwiek z długości jest ujemna</exception>    
        /// <exception cref="ArgumentException">z komunikatem "object not exist", gdy trójkąta nie można utworzyć</exception>
        public static double TriangleIsoscelesPerimeter(int basis, int height, int precision = 2)
        {
            //throw new ArgumentException("object not exist");

            if (precision < 2 || precision > 8 || basis < 0 || height < 0)
                throw new ArgumentOutOfRangeException("wrong arguments");

            //determine side
            double side = Math.Sqrt(Math.Pow((double)basis / (double)2, 2) + Math.Pow((double)height, 2));

            return Math.Round((double)basis + (double)side + (double)side, precision);
        }

        public static void Wzorek(int n)
        {
            if (n < 3) return;

            if (n % 2 == 0) n--;

            for (int i = n; i != -1; i = i - 2)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j + 1 >= i) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}