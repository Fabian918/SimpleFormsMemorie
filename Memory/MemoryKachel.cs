using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory
{
    class MemoryKachel : PictureBox
    {
        public delegate void ToggleEventHandler(object sender, EventArgs e);

        public event ToggleEventHandler TOGGLE_EVENT;


        protected  virtual void Toggle()
        {
            TOGGLE_EVENT?.Invoke(this, null);
        }

        public string aufgedecktBildUrl { get; set; } = "";
        public string zugedecktBildUrl { get; set; } = "";

        private bool _istAufgedeckt = false;
        public bool isAusSpielgenommen { get; private set; } = false;
        public bool istAufgedeckt
        {
            get
            {
                return isAusSpielgenommen ? false : this._istAufgedeckt;
            }
            set
            {
                if(isAusSpielgenommen)
                {
                    return;
                }
                this._istAufgedeckt = value;
                this.ImageLocation = this._istAufgedeckt ? this.aufgedecktBildUrl : this.zugedecktBildUrl;
                this.Enabled = !this._istAufgedeckt;
                if(this._istAufgedeckt)
                {
                    Toggle();
                }

            }
        }

        public int KachelWeite
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
                this.Height = value;
            }
        }

        public MemoryKachel(string _aufgedecktBildUrl, string _zugedecktBildUrl, int _kachelweite = 50)
        {
            this.aufgedecktBildUrl = _aufgedecktBildUrl;
            this.zugedecktBildUrl = _zugedecktBildUrl;
            this.KachelWeite = _kachelweite;
            this.istAufgedeckt = false;
            this.Cursor = Cursors.Hand;

            this.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Click += (o, e) =>
            {
                this.istAufgedeckt = !this.istAufgedeckt;
                
            };
        }

        public void AusSpielNehmen()
        {
            this.isAusSpielgenommen = true;
            this.Visible = false;
        }
    }
}
