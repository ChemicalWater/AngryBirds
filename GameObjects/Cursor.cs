using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameObjects
{
    class Cursor : SpriteGameObject
    {
        public Cursor() : base ("spr_openM")
        {
            Mouse.SetPosition(235, 500);
            origin = Center;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            this.position = inputHelper.MousePosition;
            base.HandleInput(inputHelper);
        }
    }
}
