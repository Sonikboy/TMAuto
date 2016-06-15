using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWAuto
{
    class VillageManager
    {
        private Action processResult;

        public VillageManager(Action processResult)
        {
            this.processResult = processResult;
        }
        public Task GetInitializeVillagesTask()
        {
            Task task = new Task { Name = "Initializing villages info." };
            Player player = Player.Instance;

            task.addOperation((r) =>
            {
                player.Tribe = int.Parse(Regex.Match(r, "nation nation(.)").Groups[1].Value);
                var nodes = r.GetDoc().DocumentNode.SelectNodes("//a[contains(@href, 'newdid')]");

                player.Villages = nodes.Select(n =>
                {
                    string id = Regex.Match(n.Attributes["href"].Value, "(\\d+)").Groups[1].Value;
                    string name = n.ChildNodes["div"].InnerText;

                    string coords = n.ChildNodes["span"].InnerHtml;
                    Match coordsMatch = Regex.Match(coords, "(\\d+)[^\\d]+(\\d+)");

                    return new Village() { Id = id, Name = name, X = int.Parse(coordsMatch.Groups[1].Value), Y = int.Parse(coordsMatch.Groups[2].Value) };
                }).ToList();

                processResult();
            });

            return task;
        }
    }
}
