using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VB62DotNetLoader.com.vb62dnl.Classes
{
    public sealed class CrossThread
    {
        public static void Invoke(System.Windows.Forms.Control control, Action callback) 
        {
            if (control == null)
            {
                callback();
                return;
            }
            if (callback == null) throw new NullReferenceException();

            if (control.InvokeRequired)
            {
                control.Invoke(callback);
                System.Windows.Forms.Application.DoEvents();
            }
            else
                callback();
        }
    }
}
