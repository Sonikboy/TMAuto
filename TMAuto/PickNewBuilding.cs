using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMAuto
{
    public partial class PickNewBuilding : Form
    {
        public int newBuildingType;
        public PickNewBuilding(int id, int[] builtTypes)
        {
            InitializeComponent();
            Tribe tribe = Player.Instance.Tribe;

            //place to build wall
            if (id == 40)
            {
                listBox1.Items.Add(Buildings.GetName((int)Player.Instance.Tribe + 30));
                listBox1.SelectedIndex = 0;
                return;
            }
            //rally point only
            if (id == 39)
            {
                listBox1.Items.Add(Buildings.GetName(16));
                listBox1.SelectedIndex = 0;
                return;
            }

            for (int i = 5; i <= 41; i++)
            {
                //nonexisting building, wonder, wall, rally point skip. those have methods above for their place
                //tribe specific buildings
                if ((builtTypes.Contains(i) && i != 10 && i!= 11 && i != 23)|| i == 12 || i == 16 || i == 31 || i == 32 || i == 33 || (i == 35 && tribe != Tribe.Teutons) || (i == 36 && tribe != Tribe.Gauls) || i == 40 || (i == 41 && tribe != Tribe.Romans) )
                {
                    continue;
                }
                listBox1.Items.Add(Buildings.GetName(i));
            }

            listBox1.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            newBuildingType = Buildings.GetBuildingType(listBox1.SelectedItem.ToString());
            Dispose();
        }
    }
}
