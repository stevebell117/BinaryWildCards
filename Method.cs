using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class BinaryWildCards
{
    private static void ParseWildCards(string temp, Queue<string> queue, int currentIndex)
    {
        if(currentIndex < temp.Length)
        {
            char character = temp[currentIndex];

            if (character == '?')
            {
                string endString = temp.Substring(currentIndex);
                string beginningString = temp.Substring(0, currentIndex);

                string allValue = beginningString.Replace('?', '1') + endString.Replace('?', '0');
                queue.Enqueue(allValue);

                allValue = beginningString.Replace('?', '0') + endString.Replace('?', '1');
                queue.Enqueue(allValue);

                ParseWildCards(beginningString + '1' + endString.Remove(0, 1), queue, currentIndex + 1);
                ParseWildCards(beginningString + '0' + endString.Remove(0, 1), queue, currentIndex + 1);
            }
            else
            {
                ParseWildCards(temp, queue, currentIndex += 1);
            }
        }
    }

    static void Main()
    {
        string temp = "??0011";

        Queue<string> queue = new Queue<string>();

        ParseWildCards(temp, queue, 0);

        int count = 0;
        if (queue.Count > 0)
        {
            foreach (var item in queue.Distinct())
            {
                Console.WriteLine(count++ + ": " + item);
            }
        }
        else
        {
            Console.WriteLine(temp);
        }

        Console.ReadKey();
    }
}
