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

        public MsgObserver(Label toshow)
        {
            this.txtToShow = toshow;
        }

        public void LookMsgs()
        {
            while (true)
            {
                if (!Sesion.GettingData)
                {
                    List<Message> list = Sesion.DBConnection.GetAllReceivedMessages(Sesion.Account);
                    int count = 0;
                    foreach (Message tmp in list)
                        if (!tmp.IsReaded())
                            count++;

                    if(count > 0)
                    {
                        txtToShow.Text = "" + count;
                        txtToShow.Visible = true;
                    }
                    else
                        txtToShow.Visible = false;

                }

                Thread.Sleep(sleep);
            }
        }
    }
}
