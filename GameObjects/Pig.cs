using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameObjects
{
    class Pig : SpriteGameObject
    {
        public Pig(String assetName, Vector2 position) : base(assetName)
        {
            this.position = position;
        }
        public override void Reset()
        {
            position.X = -2500;
            base.Reset();
        }
    }
}
