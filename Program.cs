namespace FileManagement
{
    internal class Program
    {
        /// <summary>
        /// Provides a file management solution using a doubly linked list. 
        /// It allows you to read characters from a file, count their occurrences, 
        /// and perform various operations such as traversals and sorting based 
        /// on character value or frequency.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // -------[ Double Linked List Demonstration ]-------
            DLList<char> FileList = new();
            int TotalCharCount = 0;
            char ch;
            string file = @"C:\tmp\file.txt";
            GenericNode<char> node;

            try
            {
                using (var reader = new StreamReader(file)) { //using auto closing

                    while (reader.Peek() >= 0)
                    {
                        ch = (char)reader.Read();
                        if ((Convert.ToInt32(ch) == 13) || (Convert.ToInt32(ch) == 10)) // CR / LN
                        {
                            reader.Read();
                            continue;
                        }

                        node = FileList.GetNodePosition(ch);
                        if (node != null)
                        {
                            FileList.IncreaseCount(node);
                        }
                        else
                        {
                            FileList.InsertLast(ch);
                        }

                        TotalCharCount++;
                    }
                }

                Console.WriteLine("Traverse...");
                Console.WriteLine($"TotalChars: {TotalCharCount}");
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse ... By Char Asc");
                FileList.SortByValAsc();
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse ... By Char Frequency");
                FileList.SortByFrequencyDesc();
                FileList.Traverse(TotalCharCount);


            } catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            } catch (IOException e2)
            {
                Console.WriteLine(e2.Message);
            }
        }
    }
}