using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class UnitManager
    {
        private Action processResult;
        public UnitManager(Action processResult)
        {
            this.processResult = processResult;
        }

        public Task GetBuildUnitsTask(Village village, Unit unit)
        {
            Task task = new Task();

            task.addOperation((r) =>
            {
                Task.SelectBuilding(village.ArmyBuilding(unit.MadeFrom).IngameId);
            });
            
            task.addOperation((r) => {
                LogManager.log("Building " + unit.Amount);

                var docNode = r.GetDoc().DocumentNode;
                NameValueCollection content = new NameValueCollection();

                foreach(var node in docNode.SelectNodes("//input"))
                {
                    var name = node.Attributes["name"].Value;
                    var value = node.Attributes["type"].Value == "hidden" ?  node.Attributes["value"].Value : (unit.Amount + "");

                    content.Add(name, value);
                }

                content.Add("s1"," ok");

                Task.sendPost("build.php", content);
            });

            return task;
        }
    }
}
