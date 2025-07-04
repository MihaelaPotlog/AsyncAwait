using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait.Slides.wip
{
    internal class Synccontext : SynchronizationContext
    {
        public override void Send(SendOrPostCallback d, object? state)
        {
            base.Send(d, state);
        }
    }
}
