using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Documents;

namespace WordleCopy_v1._0.ViewModel
{
    internal class AppViewModel
    {

        public static DataTable ValidWords { get; set; }
        public static List<string>? ValidGuesses { get; set; }
        
        public AppViewModel() 
        {
            string filePath = "FiveLetterWords.txt";
            string[] lines = File.ReadAllLines(filePath);
            ValidWords = new DataTable("Words");
            ValidWords.Columns.Add("Word", typeof(string));
            DataColumn[] primaryKeys = new DataColumn[] { ValidWords.Columns["Word"] };
            ValidWords.PrimaryKey = primaryKeys;
            foreach (string line in lines)
            {
                ValidWords.Rows.Add(line);
            }
            ValidGuesses = new List<string>();

        }

    }
}
