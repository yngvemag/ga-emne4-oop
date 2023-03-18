using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawWithWinForm.Controls
{
    internal class DrawPanel : Panel
    {
        [DefaultValue(true)]
        public new bool DoubleBuffered
        {
            get => base.DoubleBuffered;
            set => base.DoubleBuffered = value;
        }
    }
}
