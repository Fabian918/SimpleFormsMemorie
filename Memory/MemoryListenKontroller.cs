using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
   
    class MemoryListenKontroller
    {
        public class ToggleEventArgs
        {
            public bool Punkt { get; set; } = false;
            public MemoryKachel Kachel = null;
        }
        Control panel { get; set; }

        int KachelWeite { get; set; }

        List<string> BildUrls { get; set; }
        string ZugedecktUrl { get; set; }

        List<MemoryKachel> Kacheln = new List<MemoryKachel>();

        int ColumnWidth { get; set; }

        public delegate void SpieleFertigHandler(object sender, ToggleEventArgs e);

        public event SpieleFertigHandler SPIELER_FERTIG_EVENT;


        protected virtual void SpielerFertig(ToggleEventArgs eventargs = null)
        {
            SPIELER_FERTIG_EVENT?.Invoke(this, eventargs ?? new ToggleEventArgs());
        }

        public List<MemoryKachel> AufgedeckteKacheln
        {
            get
            {
                return this.Kacheln.Where(k => k.istAufgedeckt).ToList();
            }
        }
        public List<MemoryKachel> ZugedeckteKacheln
        {
            get
            {
                return this.Kacheln.Where(k => !k.istAufgedeckt).ToList();
            }
        }
        public MemoryListenKontroller(Control panel, List<string> bildUrls, string ZugedecktUrl, int kachelWeite, int columnWidth)
        {
            this.panel = panel;
            this.BildUrls = bildUrls;
            this.ZugedecktUrl = ZugedecktUrl;
            this.KachelWeite = kachelWeite;
            this.ColumnWidth = columnWidth;

            KachelnErstellen();
            Shuffle(this.Kacheln);
            this.KachelnAnzeigen();
        }

        private void KachelnErstellen()
        {
            this.BildUrls.ForEach(k =>
            {
                this.Kacheln.Add(new MemoryKachel(k, this.ZugedecktUrl, this.KachelWeite));
                this.Kacheln.Add(new MemoryKachel(k, this.ZugedecktUrl, this.KachelWeite));
            });

        }
        public void Shuffle(List<MemoryKachel> kacheln)
        {
            Random rand = new Random();
            int randomMizer = rand.Next(1000, 10 * 1000);

            for (int i = 0; i < randomMizer; i++)
            {
                var kachelIndex1 = rand.Next(0, kacheln.Count - 1);
                var kachelIndex2 = rand.Next(0, kacheln.Count - 2);

                var tempKachel = kacheln[kachelIndex1];
                kacheln[kachelIndex1] = kacheln[kachelIndex2];
                kacheln[kachelIndex2] = tempKachel;
            }
        }
        public void KachelnSperren()
        {
            this.Kacheln.ForEach(k => k.Enabled = false);
        }

        public void KachelnEntSperren()
        {
            this.Kacheln.ForEach(k => k.Enabled = true);
        }

        public void KachelnAnzeigen()
        {
            int indexer = 0;
            int rows = 0;
            this.panel.Controls.Clear();

            this.Kacheln.ForEach(kachel =>
            {
                if (indexer % this.ColumnWidth == 0 && indexer != 0)
                {
                    rows++;
                }

                kachel.Location = new System.Drawing.Point((indexer % this.ColumnWidth) * (KachelWeite + 20), 20 + ((rows * KachelWeite) + 20));
                kachel.TOGGLE_EVENT += async(o,e) => await Kachelnpruefen(o,e);
                this.panel.Controls.Add(kachel);
                indexer++;
            });
        }


        public async Task Kachelnpruefen(object sender, EventArgs e)
        {
            if(AufgedeckteKacheln.Count >= 2)
            {
                KachelnSperren();
                Console.WriteLine("wait");
                await Task.Delay(500);
                if(AufgedeckteKacheln[0].aufgedecktBildUrl == AufgedeckteKacheln[1].aufgedecktBildUrl)
                {
                     ToggleEventArgs args = new ToggleEventArgs() { Punkt = true, Kachel = AufgedeckteKacheln[0]};
                    AufgedeckteKacheln.ForEach(k => k.AusSpielNehmen());
                    KachelnEntSperren();
                    SpielerFertig(args);
                }
                else
                {
                    AufgedeckteKacheln.ForEach(k => k.istAufgedeckt = false);
                    KachelnEntSperren();
                    SpielerFertig();
                }
              

              
                
            }
        }
    }

}
