using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.test_tavern.Scripts.Types
{
    [System.FlagsAttribute]
    public enum Hands : byte
    {
        None = 1 << 0,
        Left = 1 << 1,
        Right = 1 << 2
    }

    [System.FlagsAttribute]
    public enum ItemSlotAtr : byte
    {
        None = 1 << 0,
        In = 1 << 1,
        Out = 1 << 2,
        Lock = 1 << 3,
        Infinite = 1 << 4
    }


    public enum ItemMainSlotType : byte
    {
        Static = 0,
        Free = 1,
        StaticOrFree = 2
    }

}
