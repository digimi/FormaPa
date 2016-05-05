using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoPac
{
    internal class Collision
    {
        internal static bool Walls(List<Rectangle> hitBoxes, Pacman pacman)
        {
            foreach (var wall in hitBoxes)
            {
                if (wall.Intersects(pacman.HitBox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}