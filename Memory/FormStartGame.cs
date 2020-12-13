using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class FormStartGame : Form
    {
        public FormStartGame()
        {
            InitializeComponent();
        }

        public List<string> PlayerNames ()
        {
            List<string> namen = new List<string>();
            for(int i = 0;i<listspieler.Items.Count;i++)
            {
                namen.Add(listspieler.Items[i].ToString());
            }
            return namen;
        }
        public bool Startgame { get; set; } = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(nameInput.Text))
            {
                listspieler.Items.Add(nameInput.Text);
                nameInput.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listspieler.Items.Count == 0)
            {
                return;
            }
            Startgame = true;
            this.Close();
        }
    }
}
