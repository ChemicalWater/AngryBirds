using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameObjects
{
    class CatapultRight : SpriteGameObject
    {
        public CatapultRight() : base("spr_catapultRight")
        {
            position.X = 200;
            position.Y = 205;
        }
    }
}
