using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoPac
{
    internal class Collision
    {
        internal static bool Hit(Rectangle first, Rectangle second)
        {
            return first.Intersects(second);
        }
    }
}