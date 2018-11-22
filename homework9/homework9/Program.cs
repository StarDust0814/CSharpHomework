using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;


namespace homework9
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.baidu.com";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);

            Thread thread1 = new Thread(myCrawler.Crawl);
            thread1.Start();
            Thread thread2 = new Thread(myCrawler.Crawl);
            thread2.Start();

            Console.Write("Done!");
        }
        private void Crawl()
        {
            Console.WriteLine("Start to crawl!");
            while (true)
            {
                string current = null;
                foreach(string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("Crawl" + current + "page.");
                string html = Download(current);
                urls[current] = true;
                count++;
                Parse(html);

            }

            Console.Write("Crawl end.");
        }
        public string Download(string url)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.Encoding = Encoding.UTF8;
                string html = webclient.DownloadString(url);
                string filename = count.ToString();
                File.WriteAllText(filename, html, Encoding.UTF8);
                return html;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[] * = [] * [""'][^""'#>] + [""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }

    }
}
