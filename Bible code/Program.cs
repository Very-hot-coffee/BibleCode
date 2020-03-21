using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible_code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Библейский код, также известный, " +
                "как код Торы — представление о тексте Торы как о коде," +
                " содержащем скрытые смыслы (более глубокое понимание " +
                "прямого текста) и предсказания[1]. Точка зрения," +
                " согласно которой библейский код содержит пророческую " +
                "информацию, рассматривается в каббале. \n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Важное сообщение: данная программа не предсказывает ничего, никакого смысла в полученном тексте нет( автором не задумывалось)," +
                "это всего лишь теория больших чисел - вероятность осмысленных сочетаний букв достигается из-за большого объёма текста. \n");

            Console.ResetColor();

            if (args.Length > 0)
            {
                new BibleCodeReader(args[0], "D:\\", 5).Read();
            }
            else {
                Console.WriteLine("Input file path : ");
                var path = Console.ReadLine();
                Console.WriteLine("Input exit file path : ");
                var exitPath = Console.ReadLine();
                Console.WriteLine("Input char numers to parce : ");
                var n = Console.ReadLine().Split(' ');
                int[] nums = new int[n.Length];
                for (int i = 0; i < nums.Length; i++) {
                    int.TryParse(n[i], out nums[i]);
                }

                new BibleCodeReader(path , exitPath , nums).Read();
            }
            Console.Read();
        }
    }
}
