using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeQLDemo
{
    public class BadDisposable : IDisposable
    {
        public static void DoBadDisposeThingsOrLackThereof()
        {
            BadDisposable doNotUseUsing = new BadDisposable();
            if (DateTime.Now < DateTime.MinValue)
            {
                throw new Exception("Bad Error Message");
            }
            doNotUseUsing.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
