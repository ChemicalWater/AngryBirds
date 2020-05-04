using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameObjects
{
    class CatapultLeft : SpriteGameObject
    {
        public CatapultLeft() : base("spr_catapultLeft")
        {
            position.X = 200;
            position.Y = 205;
        }
    }
}
