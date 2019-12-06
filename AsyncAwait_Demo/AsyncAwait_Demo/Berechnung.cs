using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace AsyncAwait_Demo
{
    class Berechnung
    {
        public Task MachEineBerechnungAsync(Action<int> refreshUI,CancellationTokenSource cts)
        {
            return Task.Run(() => // Anonyme Methode
            {
                for (int i = 0; i <= 100; i++)
                {
                    // Führt diese Zeile Code im UI-Thread aus
                    refreshUI(i);
                    Thread.Sleep(80);

                    if (cts.IsCancellationRequested)
                        break;
                }
            });
        }
    }
}
