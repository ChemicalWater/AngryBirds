using AngryBirds.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds.GameStates
{
    class PlayingState : GameObjectList
    {
        Cursor cursor;
        Bird aBird;
        GameObjectList BirdLives;

        private int lives;

        public PlayingState()
        {
            this.Add(new SpriteGameObject("spr_background"));

            BirdLives = new GameObjectList();
            for (int iLife = 0; iLife < 2; iLife++)
            {
                BirdLife birdLife = new BirdLife(new Vector2(100 + 30 * iLife, 270));
                BirdLives.Add(birdLife);
            }
            this.Add(BirdLives);

            cursor = new Cursor();
            aBird = new Bird();
            this.Add(new CatapultRight());
            this.Add(aBird);
            this.Add(new CatapultLeft());
            this.Add(cursor);
        }

        public override void Reset()
        {
            lives = 3;
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
        }
    }
}
