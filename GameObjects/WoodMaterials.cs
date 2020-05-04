using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameObjects
{
    class WoodMaterials : SpriteGameObject
    {
        public WoodMaterials(String assetName, Vector2 position) : base(assetName)
        {
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        
        public override void Reset()
        {
            position.X = -2000;
        }
    }
}
