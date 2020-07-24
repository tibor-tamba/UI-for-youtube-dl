using System;
using System.Collections.Generic;
using System.Xml;

namespace libyoutube_dl
{
    /// <summary>Recognizes the external downloader's output messages based on the pattern definitions provided by <see cref="PatternFile"/> class</summary>
    internal class ParseOutput
    {
        private int RowIndex;
        private string Datarow;
        // Patterns to recognize the message.
        private List<List<string>> Patterns = new List<List<string>>();

        //Titles of the messages.
        private List<string> MessageID = new List<string>();

        /// <summary>
        /// The extracted data from the input row.
        /// </summary>
        public List<string> MessageValues = new List<string>();

        /// <summary>
        /// Gets the string between two given string.
        /// </summary>
        /// <returns></returns>
        private string GetStringBetween(string mainstr, string str1, string str2)
        {
            int s;
            int c;
            s = mainstr.IndexOf(str1) + str1.Length;
            if (str2 == "*end*")
                c = mainstr.Length - mainstr.IndexOf(str1) - str1.Length;
            else
                c = mainstr.IndexOf(str2, mainstr.IndexOf(str1) + str1.Length) - mainstr.IndexOf(str1) - str1.Length;
            return mainstr.Substring(s, c);
        }

        /// <summary>
        /// Extract data from the input row and put into the MessageData array.
        /// </summary>
        private void ExtractData(int Index, string Str)
        {
            int pn = Patterns[Index].Count;
            for (int i = 0; i < pn; i++)
            {                
                string s1 = Patterns[Index][i];
                string s2;
                if (i < pn - 1)
                    s2 = Patterns[Index][i + 1];
                else 
                    s2 = "*end*";
                MessageValues.Add(GetStringBetween(Str, s1, s2));
                MessageValues[i] = MessageValues[i].Trim();
            }
        }

        /// <summary>Parses the input row.</summary>
        private void ParseRow()
        {
            // Determining the index which pattern fit to the input row.
            for (int i = 0; i < Patterns.Count; i++)
            {
                int a = 0;
                int pn = Patterns[i].Count;
                for (int j = 0; j < pn; j++)
                    if (Datarow.Contains(Patterns[i][j])) a++;
                if (a == pn)
                {
                    RowIndex = i;
                    break;
                }
            }
            //Extracting specific data from the input row.
            if (RowIndex>-1) ExtractData(RowIndex, Datarow);
        }

        /// <summary>
        /// Returns the generated ID from the input text.
        /// </summary>
        /// <returns></returns>
        public string GetMessageID { get { if (RowIndex > -1) return MessageID[RowIndex]; else return ""; } }

        /// <summary>
        /// Sets the input data row.
        /// </summary>
        public string InputRow { set { Datarow = value; RowIndex = -1; MessageValues.Clear(); ParseRow(); } }
        public ParseOutput()
        {
            Datarow = "";
            RowIndex = -1;
            // Loading definitions from patternfile.
            foreach (PatternFile.PD i in PatternFile.Definitions)
            {
                MessageID.Add(i.Name);
                Patterns.Add(i.PatternDef);
            }
        }
    }

    /// <summary>Loads and stores the patterns that the <see cref="ParseOutput"/> class able to recognize the external downloader's output messages.</summary>
    public static class PatternFile
    {
        private static int pcounter = 0;
        //private static int defcounter = 0;
        /// <summary>The list of Pattern Definitions.</summary>
        public static List<PD> Definitions = new List<PD>();
        /// <summary>A pattern definition that contains the name and the strings that clearly identify the external program's message.</summary>
        public class PD
        {
            /// <summary>The identifier of the pattern.</summary>
            public string Name { get; set; }
            /// <summary>The pattern strings.</summary>
            public List<string> PatternDef = new List<string>();
        }
        /// <summary>Determines whether the definition file loaded.</summary>
        public static bool Initialized { get; private set; } = false;
        /// <summary>Loads the definition file and initializes the class.</summary>
        /// <param name="FileName">The definition file to load.</param>
        /// <returns>True if the loading was successful.</returns>
        public static bool LoadDefinitions(string FileName)
        {
            Definitions.Clear();
            pcounter = 0;
            try
            {
                XmlReader doc = XmlReader.Create(FileName);
                while (doc.Read())
                {
                    switch (doc.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (doc.Name)
                            {
                                case "Pattern": Definitions.Add(new PD());break;
                                case "Name": doc.Read(); Definitions[pcounter].Name = doc.Value; break;
                                case "Def": doc.Read(); Definitions[pcounter].PatternDef.Add(doc.Value); break;
                            }
                            break;
                        case XmlNodeType.EndElement:
                            if (doc.Name == "Pattern") {pcounter++; }
                            break;
                    }
                }
                doc.Close();
                Initialized = true;
                return true;
            }
            catch { return false; }
        }
    }
}
