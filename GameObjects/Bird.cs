using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AngryBirds.GameObjects
{
    class Bird : SpriteGameObject
    {

        public Bird() : base("spr_alien")
        {
            position.X = 205;
            position.Y = 200;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); 
        }
    }
}
