using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWAuto
{
    public partial class PickNewBuilding : Form
    {
        public int newBuildingType;
        public PickNewBuilding()
        {
            InitializeComponent();
            int tribe = Player.Instance.Tribe;

            for (int i = 1; i <= 41; i++)
            {
                //wall for specific tribes or nonexisting building type
                if (i == 12 || (i == 31 && tribe != 1) || (i == 32 && tribe != 2) || (i == 33 && tribe != 3))
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
