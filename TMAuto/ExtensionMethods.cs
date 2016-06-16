using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    static class ExtensionMethods
    {
        public static HtmlAgilityPack.HtmlDocument GetDoc(this string result)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
            return doc;
        }
    }
}
