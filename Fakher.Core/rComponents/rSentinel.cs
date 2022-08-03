using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace rComponents
{
    internal class rSentinel
    {
        internal static void Check()
        {
            Assembly me = Assembly.GetExecutingAssembly();
            Assembly c = null;

            StackTrace stackTrace = new StackTrace(false);
            foreach (StackFrame frame in stackTrace.GetFrames())
            {
                MethodBase m = frame.GetMethod();
                if (m != null && m.DeclaringType != null && m.DeclaringType.Assembly != me)
                {
                    c = m.DeclaringType.Assembly;
                    break;
                }
            }

            string guid;
            object[] objects = c.GetCustomAttributes(typeof(GuidAttribute), false);
            
            if (objects.Length > 0)
                guid = ((GuidAttribute) objects[0]).Value;
            else
                throw new InvalidOperationException();

            IsAllowed(guid);
        }

        internal static void IsAllowed(string guid)
        {
            return;
            List<string> allowedGuids = new List<string>
                                    { "0a7e2aa2-b74f-431e-a61a-fdc8cf714802" };
            if (!allowedGuids.Contains(guid))
                Environment.Exit(1);
        }
    }
}
