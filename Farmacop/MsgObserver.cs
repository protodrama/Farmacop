using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Farmacop
{
    public class MsgObserver
    {
        Label txtToShow;
        int sleep = 60000;
        public int msgs = 0;

        public MsgObserver(Label toshow)
        {
            this.txtToShow = toshow;
        }

       

    }
}
