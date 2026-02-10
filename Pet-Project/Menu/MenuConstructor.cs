using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menus
{
    internal class MenuConstructor
    {
        private string _startText;
        private string _endText;

        public void SetStartText(string newStartText) => _startText = newStartText;

        public void SetEndText(string newEndText) => _endText = newEndText;


        public void SetMenuLine(int numberLine, string textLine, Action action)
        {
            dict1[numberLine] = textLine;
            dict2[numberLine] = action;
        }

        public void View()
        {
            Console.WriteLine(_startText);
            foreach (var line in dict1)
            {
                Console.WriteLine(line.Key + ". " + line.Value);
            }
            Console.WriteLine(_endText);
        }

        public void RunByLine(int inputLine)
        {
            dict2[inputLine].Invoke();
        }



        SortedDictionary<int, string> dict1 = new SortedDictionary<int, string>();

        SortedDictionary<int, Action> dict2 = new SortedDictionary<int, Action>();

        SortedDictionary<int, Dictionary<string, Delegate>> Dict = new SortedDictionary<int, Dictionary<string, Delegate>>();
    }
}
