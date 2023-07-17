using BarRaider.SdTools;
using System.Diagnostics;

#if DEBUG
while (!Debugger.IsAttached)
{ 
    Thread.Sleep(100);
}
#endif

SDWrapper.Run(args);