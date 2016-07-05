using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TMAuto
{
    class HeroManager
    {
        private Action processResult;
        private Hero hero = Hero.Instance;

        public bool DoAdventure { get; set; }

        private CustomTimer adventureTimer;
        public HeroManager(Action processResult)
        {
            this.processResult = processResult;
            DoAdventure = hero.AdventureMode != Mode.NONE;
            adventureTimer = new CustomTimer(60 * 8, 60 * 13);
            adventureTimer.Elapsed += new System.Timers.ElapsedEventHandler((sender, e) => {
                if (hero.AdventureMode != Mode.NONE) { DoAdventure = true; }
            });
            adventureTimer.Start();
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
                var node = r.GetDoc().DocumentNode;

                string health = node.SelectSingleNode("//img[@class='injury']").NextSibling.NextSibling.Attributes["style"].Value;
                health = Regex.Match(health, "width:(.*)%").Groups[1].Value;
                hero.Health = int.Parse(health);
                hero.InVillage = int.Parse(node.SelectSingleNode("//img[contains(@class,'heroStatus')]").Attributes["class"].Value.Substring(10)) == 100;

                //if hero is in village and has enough health at least for normal ones
                if (hero.InVillage && hero.CanNormal)
                {
                    LogManager.log("checking hero adventures");
                    //choosing adventure
                    //if cant hard mode
                    string xpath;
                    string maxTravelTime = TimeSpan.FromHours(hero.MaxTravelTime).ToString("");

                    if (!hero.CanHard)
                    {
                        xpath = "//tr[@id and .//img[not(@class='adventureDifficulty0')]]";
                    } else
                    {
                        if (hero.PreferHard)
                        {
                            xpath = "//tr[@id and .//img[@class='adventureDifficulty0']]";
                        }
                        else
                        {
                            xpath = "//tr[@id]";
                        }
                    }

                    var adventureNodes = node.SelectNodes(xpath).Where(b => true);
                    
                    if (adventureNodes != null)
                    {
                        adventureNodes = adventureNodes.Where(n => n.SelectSingleNode("./td[@class='moveTime']").InnerText.Trim().CompareTo(maxTravelTime) <= 0);
                        int count = adventureNodes.Count();
                        int adventureIndex;
                        //if adventures present
                        switch (hero.AdventureMode)
                        {
                            case Mode.RANDOM:
                                adventureIndex = new Random().Next(0, count);
                                break;
                            case Mode.FURTHEST:
                                int newCount = 0;

                                adventureIndex = adventureNodes
                                .Select(nn => {
                                    var n = nn.SelectSingleNode("./td[@class='moveTime']");
                                    return new { Time = n.InnerText.Trim(), Index = newCount++ };
                                })
                                .OrderByDescending(n => n.Time)
                                .Select(n => n.Index)
                                .First();

                                break;
                            default: //CLOSEST
                                newCount = 0;

                                adventureIndex = adventureNodes
                                .Select(nn => {
                                    var n = nn.SelectSingleNode("./td[@class='moveTime']");
                                    return new { Time = n.InnerText.Trim(), Index = newCount++ };
                                }).OrderBy(n => n.Time)
                                .Select(n => n.Index)
                                .First();

                                break;
                        }

                        task.addOperation((rr) =>
                        {
                            var button = rr.GetDoc().DocumentNode.SelectSingleNode("//form[@class='adventureSendButton']");

                            //cant send. no rally points, cant do yet etc
                            if (button == null)
                            {
                                processResult();
                                return;
                            }

                            var sendNode = button.NextSibling.NextSibling;

                            NameValueCollection content = new NameValueCollection();

                            foreach (var inputNode in sendNode.SelectNodes("input"))
                            {
                                content.Add(inputNode.Attributes["name"].Value, inputNode.Attributes["value"].Value);
                            }
                            var sendButtonNode = sendNode.SelectSingleNode("button");
                            content.Add(sendButtonNode.Attributes["name"].Value, sendButtonNode.Attributes["value"].Value);

                            LogManager.log("Sending hero to adventure");
                            DoAdventure = false;
                            Task.sendPost("start_adventure.php", content);
                        });
                        
                        string url = adventureNodes.ElementAt(adventureIndex).SelectSingleNode("td[@id]/a").Attributes["href"].Value;
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
