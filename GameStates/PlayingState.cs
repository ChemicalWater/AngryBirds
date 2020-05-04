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
        GameObjectList Pigs;
        GameObjectList WoodMat;
        TextGameObject score;

        private int lives = 2;

        public PlayingState()
        {
            this.Add(new SpriteGameObject("spr_background"));

            BirdLives = new GameObjectList();
            for (int iLife = 0; iLife < 2; iLife++)
            {
                BirdLife birdLife = new BirdLife(new Vector2(100 + 30 * iLife, 270));
                BirdLives.Add(birdLife);
            }
            Pigs = new GameObjectList();
            WoodMat = new GameObjectList();

            this.Add(BirdLives);
            cursor = new Cursor();
            aBird = new Bird();

            WoodMat.Add(new WoodMaterials("spr_bottomPlank", new Vector2(800, 300)));
            WoodMat.Add(new WoodMaterials("spr_innerwallPlank", new Vector2(800,220)));
            WoodMat.Add(new WoodMaterials("spr_innerwallPlank", new Vector2(865, 220)));
            WoodMat.Add(new WoodMaterials("spr_topPlank", new Vector2(805, 202)));
            WoodMat.Add(new WoodMaterials("spr_triangleWood", new Vector2(805, 178)));
            WoodMat.Add(new WoodMaterials("spr_outerwallPlank", new Vector2(700, 260)));
            Pigs.Add(new Pig("spr_yellowsuit", new Vector2(745, 290)));
            Pigs.Add(new Pig("spr_bluesuit", new Vector2(840, 163)));
            this.Add(Pigs);
            this.Add(WoodMat);

            score = new TextGameObject("GameFont");
            score.Text = "0";
            score.Position = new Vector2(950, 20);
            this.Add(score);

            this.Add(new CatapultRight());
            this.Add(aBird);
            this.Add(new CatapultLeft());
            this.Add(cursor);
        }

        public override void Reset()
        {
            lives = 2;
            base.Reset();
        }

        public override void Update(GameTime gameTime)
        {

            foreach (Pig pig in Pigs.Children)
            {
                if (pig.CollidesWith(aBird))
                {
                    pig.Reset();
                    aBird.Reset();
                    lives--;
                    BirdLives.Children[lives].Position = new Vector2(-2000, 0);
                    if (lives <= 0)
                    {
                        GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                        Reset();
                    }
                }
            }
            foreach (WoodMaterials woodM in WoodMat.Children)
            {
                if (woodM.CollidesWith(aBird))
                {

                }
            }

            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
                
        }
    }
}
