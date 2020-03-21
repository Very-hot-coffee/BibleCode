using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bible_code
{
    public class BibleCodeReader
    {
        public BibleCodeReader(string arg , string exitWay , params int [] array){
            path = arg;
            chars.AddRange(array);
            exitPath = exitWay;

            Console.WriteLine($"Created BibleCodeReader {arg} to {exitPath} ");

            file = File.ReadAllText(arg, System.Text.Encoding.Default);
        }
        public string path { get; }
        public List<int> chars { get; } = new List<int>();

        private string file;
        private string exitPath;

        public void Read() {
            Task[] tasks = new Task[chars.Count];

            for(int i = 0; i < tasks.Length; i++) {
                tasks[i] = ReadFile(chars[i]);
                //tasks[i].Start();
            }
            Task.WaitAll();
        }

        private async Task ReadFile(int index) {
            await Task.Run(()=> {
                if (index > 1)
                {

                    Console.WriteLine($"\nStart read from index = {index} ...");

                    var result = "";
                    var count = index;
                    var exitFilePath = exitPath +
                        path.Split("\\".ToCharArray()[0]).Last().Split('.')[0] + // Вычленяем название файла
                        "_resultate_to_index_" + index + ".txt";

                    while (count < file.Length)
                    {
                        result += file[count];
                        count += index;
                    }
                    Console.WriteLine($"Save {exitFilePath}");
                    File.WriteAllText(exitFilePath, result, System.Text.Encoding.Default);
                    Console.Beep();
                    Console.WriteLine($"Finished susseful");
                }
            });
            
        }
    }
}
