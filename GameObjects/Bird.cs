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
        public Vector2 startPosition;
        public bool clicked;

        public Bird() : base("spr_alien")
        {
            position.X = 205;
            position.Y = 200;
            startPosition = position;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.MouseLeftButtonDown())
            {
                clicked = true;
                position = inputHelper.MousePosition;
            } else
            {
                clicked = false;
            }
        }
        public override void Reset()
        {
            position.X = 205;
            position.Y = 200;

            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - sprite.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y - sprite.Height);

            base.Update(gameTime);

             if (!clicked && position != startPosition && velocity.X == 0)
            {

            }
        }
    }
}
