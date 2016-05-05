using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoPac
{
	public interface ISprite
	{
		void Draw(SpriteBatch sb);
        Rectangle SourceRectangle { get; set; }
	}
}

