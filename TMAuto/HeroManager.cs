using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TWAuto
{
    class HeroManager
    {
        private Action processResult;

        public HeroManager(Action processResult)
        {
            this.processResult = processResult;
        }

        public Task GetCheckHeroTask()
        {
            Task task = new Task() { Name = "checkingHero" };

            task.addOperation((r) =>
            {
                Task.sendGet("hero_adventure.php");
            });

            task.addOperation((r) =>
            {
                //analyze adventures, send hero if can
                LogManager.log("Checking hero status");
                Hero hero = Hero.Instance;
                var node = r.GetDoc().DocumentNode;

                string health = node.SelectSingleNode("//img[@class='injury']").NextSibling.NextSibling.Attributes["style"].Value;
                health = Regex.Match(health, "width:(.*)%").Groups[1].Value;
                hero.Health = int.Parse(health);
                hero.InVillage = int.Parse(node.SelectSingleNode("//img[contains(@class,'heroStatus')]").Attributes["class"].Value.Substring(10)) == 100;

                //if hero should do adventures
                if (hero.AdventureMode != Mode.NONE && hero.InVillage)
                {
                    LogManager.log("checking hero adventures");
                    //choosing adventure
                    var adventureNodes = node.SelectNodes("//tr[@id]");
                    int count = adventureNodes.Count;

                    if (count > 0)
                    {
                        int adventureIndex;
                        //if adventures present
                        switch (hero.AdventureMode)
                        {
                            case Mode.RANDOM:
                                adventureIndex = new Random().Next(0, count - 1);
                                break;
                            case Mode.FURTHEST:
                                int newCount = 0;

                                adventureIndex = r.GetDoc().DocumentNode.SelectNodes("//td[contains(@id,'walktime')]")
                                .Select(n => { return new { Time = n.InnerText.Trim(), Index = newCount++ }; })
                                .OrderByDescending(n => n.Time)
                                .Select(n => n.Index)
                                .First();

                                break;
                            default: //CLOSEST
                                newCount = -1;

                                adventureIndex = r.GetDoc().DocumentNode.SelectNodes("//td[contains(@id,'walktime')]")
                                .Select(n => { return new { Time = n.InnerText.Trim(), Index = newCount++ }; })
                                .OrderBy(n => n.Time)
                                .Select(n => n.Index)
                                .First();

                                break;
                        }

                        task.addOperation((rr) =>
                        {
                            var sendNode = rr.GetDoc().DocumentNode.SelectSingleNode("//form[@class='adventureSendButton']").NextSibling.NextSibling;

                            NameValueCollection content = new NameValueCollection();

                            foreach (var inputNode in sendNode.SelectNodes("input"))
                            {
                                content.Add(inputNode.Attributes["name"].Value, inputNode.Attributes["value"].Value);
                            }
                            var sendButtonNode = sendNode.SelectSingleNode("button");
                            content.Add(sendButtonNode.Attributes["name"].Value, sendButtonNode.Attributes["value"].Value);

                            Task.sendPost("start_adventure.php", content);
                        });

                        string url = adventureNodes[adventureIndex].SelectSingleNode("td[@id]/a").Attributes["href"].Value;
                        LogManager.log("Sending hero to adventure");
                        Task.sendGet(url);
                    }
                    else
                    {
                        processResult();
                    }
                }
                else
                {
                    processResult();
                }
            });

            return task;
        }
    }
}
