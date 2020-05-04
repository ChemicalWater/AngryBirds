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
        public float distCursor;
        public Cursor() : base ("spr_openM")
        {
            Mouse.SetPosition(235, 500);
            origin = Center;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            this.position = inputHelper.MousePosition;
            base.HandleInput(inputHelper);
            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - sprite.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y - sprite.Height);
        }
    }
}
