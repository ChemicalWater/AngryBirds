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
        Vector2 startPosition;
        public Pig(String assetName, Vector2 position) : base(assetName)
        {
            this.position = position;
            startPosition = position;
        }
        public override void Reset()
        {
            this.position = startPosition;
            base.Reset();
        }
    }
}
