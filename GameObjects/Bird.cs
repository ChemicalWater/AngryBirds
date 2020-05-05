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
        public bool clicked = false;
        public bool launched = false;

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
               if(launched == false)
                    position = inputHelper.MousePosition;
            } else
            {
                if (clicked)
                {
                    if (position.X <= startPosition.X)
                    {
                        launched = true;


                        velocity.X = startPosition.X - position.X;
                        velocity.Y = (startPosition.Y - position.Y);
                

                       
                    }


                }

                clicked = false;
            }
        }
        public override void Reset()
        {
            position.X = 205;
            position.Y = 200;
            velocity = Vector2.Zero;
            launched = false;
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            position.X = MathHelper.Clamp(position.X, 0, GameEnvironment.Screen.X - sprite.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, GameEnvironment.Screen.Y - sprite.Height);

            base.Update(gameTime);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
          
             if (launched)
             {
                // move stuff
                 position.X = position.X + velocity.X * deltaTime;
              
                 position.Y = position.Y + velocity.Y * deltaTime + 0.5f * 9.81f * (deltaTime * deltaTime);
                 velocity.Y = velocity.Y + 9.81f * deltaTime;
             }
        }
    }
}
