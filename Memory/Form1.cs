using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    public partial class Form1 : Form
    {

        FormStartGame startSpielForm;
        MemoryListenKontroller MemorieKontroller;
        GameKontroller spielKontroller;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startSpielForm = new FormStartGame();
            startSpielForm.StartPosition = FormStartPosition.CenterParent;
            startSpielForm.ShowDialog();

            List<Player> player = new List<Player>();

            startSpielForm.PlayerNames().ForEach(k => player.Add(new Player(k)));
            spielKontroller = new GameKontroller(player);
            this.comboBox1.Items.AddRange(spielKontroller.Player.ToArray());
            this.comboBox1.SelectedItem = spielKontroller.ActivePlayer;
            DirectoryInfo d = new DirectoryInfo("./Bilder/");

            List<string> urls = new List<string>();

            foreach (var file in d.GetFiles("*.jpg"))
            {
                urls.Add(file.FullName);
            }

            MemorieKontroller = new MemoryListenKontroller(memoriePanel, urls.Skip(1).ToList(), urls[0], 100, 5);
            MemorieKontroller.SPIELER_FERTIG_EVENT += (o, ee) =>
            {
                if(ee.Punkt)
                {
                    spielKontroller.ActivePlayer.Kacheln.Add(ee.Kachel);

                }
                else
                {
                    spielKontroller.NaechsterSpieler();
                    this.comboBox1.SelectedItem = spielKontroller.ActivePlayer;
                }
                this.lblPunkteStandanzeigen.Text = $"Spieler {spielKontroller.ActivePlayer.name} hat {spielKontroller.ActivePlayer.Kacheln.Count} Punkte";


            };
        }
    }
}
