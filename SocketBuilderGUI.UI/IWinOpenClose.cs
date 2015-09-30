using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EthanYuWPFKit.UI
{
    public interface IWinOpenClose
    {
        bool win_opened { get; set; }
        void WinInit();
        void WinClose();
    }
}
