using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMAuto
{
    public static class Parser
    {
        public static object ParseArmy(string input, string unitTag)
        {
            Match match = Regex.Match(input,
            unitTag + "\":{.*?\"available\":\"(.*?)\",\"all_count\":\"(.*?)\"");
            //if archer/marcher.. dont exist
            int available = match.Groups[1].Value != "" ? int.Parse(match.Groups[1].Value) : 0;
            int total = match.Groups[1].Value != "" ? int.Parse(match.Groups[2].Value) : 0;

            return new { Available = available,
                         Total = total };
        }
    }
}
