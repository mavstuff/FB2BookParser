/* This code is written by Artem Moroz (c) 2021 */
// The purpose of the code is to demonstrate the parsing of FB2 format files in C# 
// see more info here: https://iq.direct/blog/334-code-snippet-parse-fb2-format-book-in-c.html
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BookParser
{

    public class Program
    {
        static XNamespace fbSpace = "http://www.gribuser.ru/xml/fictionbook/2.0";

        public static void Main(string[] args)
        {

            XDocument doc = XDocument.Load("https://azbyka.ru/biblia/downloads/bibliya.fb2");
            var body = doc.Root.Element( fbSpace + "body");
            ParseSection(body, 0, -1);
        }

        static void ParseSection(XElement body, int level, int bookid)
        {
            var sections = body.Elements(fbSpace + "section");
            if (sections != null)
            {
                foreach (var section in sections)
                {
                    var title = section.Element(fbSpace + "title");
                    var padding = new String(' ', level);
                    Console.WriteLine("{0} title: {1}", padding, title.Value);

                    ParseSection(section, level+1, bookid);

                }
            }
        }

    }
}

