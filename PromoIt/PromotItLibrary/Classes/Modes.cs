using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotItLibrary.Classes
{
    public class Modes
    {
        public static Modes MySQL { get; } = new Modes();
        public static Modes CosmosDB { get; } = new Modes();
        public static Modes Functions { get; } = new Modes();
        public static Modes Queue { get; } = new Modes();

        public static Modes NotLocal_ProtectedKey { get; } = new Modes();
        public static Modes Local { get; } = new Modes();

        public static Modes Null { get; } = null;

    }


}
