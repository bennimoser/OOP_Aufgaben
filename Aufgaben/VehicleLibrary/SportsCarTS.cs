using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VehicleLibrary
{
    [Synchronization]
    public class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("Object {0} is in context {1}", this, ctx.ContextID);
        }
    }

    public class SportsCar
    {
        public SportsCar()
        {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("Object {0} is in context {1}", this, ctx.ContextID);
        }
    }
}
