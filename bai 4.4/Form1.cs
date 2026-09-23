using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_4._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class MenuItem
        {
            public string Name { get; }
            public int Price { get; }

            public MenuItem(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name} - {Price}k";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate menu
            lstMenu.Items.Add(new MenuItem("Hamburger", 50));
            lstMenu.Items.Add(new MenuItem("Pizza", 120));
            lstMenu.Items.Add(new MenuItem("Gà Rán", 35));
            lstMenu.Items.Add(new MenuItem("Pepsi", 15));

            // Optional: double-click to add
            lstMenu.DoubleClick += (s, ev) => btnAdd_Click(s, EventArgs.Empty);
            lstSelected.DoubleClick += (s, ev) => btnRemove_Click(s, EventArgs.Empty);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItem is MenuItem mi)
            {
                // add a copy to selected (allow duplicates)
                lstSelected.Items.Add(new MenuItem(mi.Name, mi.Price));
                UpdateTotal();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedIndex >= 0)
            {
                lstSelected.Items.RemoveAt(lstSelected.SelectedIndex);
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            int sum = 0;
            foreach (var item in lstSelected.Items)
            {
                if (item is MenuItem mi)
                    sum += mi.Price;
            }
            lblTotal.Text = $"Total: {sum}k";
        }
    }
}
