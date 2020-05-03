using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpriteGameObject : GameObject
{
    public SpriteGameObject(String assetName) : base(assetName)
    {
        texture = GameEnvironment.ContentManager.Load<Texture2D>(assetName);
    }
}
