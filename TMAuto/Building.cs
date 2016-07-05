using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMAuto
{
    class Building : INotifyPropertyChanged
    {
        public int IngameId { get; set; }
        public string Name { get { return Buildings.GetName(Type); } }
        private int type;
        public int Type {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    notifyPropertyChanged();
                }
            }
        }
        private int level;
        public int Level {
            get
            {
                return level;
            }
            set
            {
                if (level != value)
                {
                    level = value;

                    if (Total == 0)
                    {
                        Type = 0;
                    }
                    else
                    {
                        notifyPropertyChanged();
                    }
                }
            }
        }
        private int onGoing;
        public int OnGoing {
            get
            {
                return onGoing;
            }
            set
            {
                if (onGoing != value)
                {
                    onGoing = value;

                    if (Total == 0)
                    {
                        Type = 0;
                    }
                    else
                    {
                        notifyPropertyChanged();
                    }
                }
            }
        }
        private int offset;
        public int Offset
        {
            get { return offset; }
            set
            {
                if (offset != value)
                {
                    offset = value;

                    if (Total == 0)
                    {
                        Type = 0;
                    } else
                    {
                        notifyPropertyChanged();
                    }    
                }
            }
        }
        public int Total { get { return level + offset + onGoing; } }
        public string ButtonText
        {
            get
            {
                if (Total > 0)
                {
                    return level + (Total > level ? "|" + Total : "");
                } else
                {
                    return IngameId + "";
                }
            }
        }
        public int MaxLevel { get { return Buildings.getMaxLevel(Type); } }

        //cost of next level
        public Resources NextLevelCost { get { return Buildings.getNextLevelCost(Type, Level); } }
        public TimeSpan NextLevelBuildingTime { get { return Buildings.NextLevelBuildingTime(Type, Level, 1); } }

        public Image BuildingImage { get { return Buildings.GetImage(Type); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void ButtonTextUpdateHandler(Action action);
        public static event ButtonTextUpdateHandler ButtonTextUpdated;

        private void notifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                var action = new Action(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
                ButtonTextUpdated(action);
            }
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Level: {1}, MaxLevel: {2}, Cost: {3}, BuildingTime: {4}", Type, Level, MaxLevel, NextLevelCost, NextLevelBuildingTime);
        }
    }
}
