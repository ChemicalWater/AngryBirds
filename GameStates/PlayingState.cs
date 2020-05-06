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
        GameObjectList guide;

        private int lives = 2;
        private int NumberScore = 0;
        private bool gameOver;

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
            guide = new GameObjectList();

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

            for (int i = 0; i < 10; i++)
            {
                guideSquare sQuare = new guideSquare(new Vector2(-10,0));
                guide.Add(sQuare);
            }

            this.Add(guide);
            score = new TextGameObject("GameFont");
            score.Text = "0";
            score.Position = new Vector2(900, 20);
            this.Add(score);

            this.Add(new CatapultRight());
            this.Add(aBird);
            this.Add(new CatapultLeft());
            this.Add(cursor);
        }

        public override void Reset()
        {
            base.Reset();
            NumberScore = 0;
            lives = 2;
            score.Text = NumberScore.ToString();
            gameOver = false;
        }

        public override void Update(GameTime gameTime)
        {
            // check if bird launched, if not NO dots
            if(aBird.launched == false)
            {
                // Setting up velocity + position
                Vector2 velocity;
                velocity.X = (aBird.startPosition.X ) - aBird.Position.X;
                velocity.Y = ((aBird.startPosition.Y) - aBird.Position.Y);
                Vector2 pos = aBird.Position;
                pos.X += aBird.Sprite.Width * 0.5f;
                pos.Y += aBird.Sprite.Height * 0.5f;


                // Simulate bird flight till after bird location
                while (pos.X < aBird.startPosition.X)
                {
                 
                    pos.X = pos.X + velocity.X * 0.016f;

                    pos.Y = pos.Y + velocity.Y * 0.016f + 0.5f * 9.81f * (0.016f * 0.016f);
                    velocity.Y = velocity.Y + 9.81f * 0.016f;
                }

                // Redo above, simulate on 100(10 dots) frames now
                for (int frame = 0; frame < 100; frame++)
                {

                    // Update position X, adding velocity * the time that has elapsed(seconds)
                    pos.X = pos.X + velocity.X * 0.016f;
                    // Update position Y, adding velocity * the elapsed time + an half + gravity * squared time(seconds)
                    pos.Y = pos.Y + velocity.Y * 0.016f + 0.5f * 9.81f * (0.016f * 0.016f);
                    // Update the velocity with gravity and time that has elapsed(seconds)
                    velocity.Y = velocity.Y + 9.81f * 0.016f;

                    // check every 10 frames
                    if (frame % 10 == 0)
                    { 
                        guide.Children[frame / 10].Position = pos;
                    }

                }

            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Vector2 outaMap;
                    outaMap.X = -200;
                    outaMap.Y = -100;
                    guide.Children[i].Position = outaMap;
                }
            }
           

            if (aBird.Position.Y >= GameEnvironment.Screen.Y - aBird.Sprite.Height 
                || aBird.Position.X >= GameEnvironment.Screen.X - aBird.Width )
            {
                aBird.Reset();
                lives--;
                if (lives < 0)
                    gameOver = true;

                if (lives < 0 && NumberScore <= 0)
                {
                    GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                    Reset();
                    return;
                }
                else if (lives > 0 && NumberScore > 0 && gameOver || lives < 0 && NumberScore > 0 && gameOver)
                {
                    NumberScore += (lives * 50);
                    GameEnvironment.GameStateManager.SwitchTo("WinState");
                    Reset();
                    return;
                }
                BirdLives.Children[lives].Position = new Vector2(-2000, 0);
                return;
            }

            foreach (Pig pig in Pigs.Children)
            {
                if (pig.CollidesWith(aBird))
                {
                    NumberScore += 50;
                    pig.Position = new Vector2(-2000, 0);
                    aBird.Reset();
                    score.Text = NumberScore.ToString();
                    lives--;
                    if (lives < 0)
                        gameOver = true;

                    if (lives < 0 && NumberScore <= 0)
                    {
                        GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                        Reset();
                        return;
                    }
                    else if (lives > 0 && NumberScore > 0 && gameOver|| lives < 0 && NumberScore > 0 && gameOver)
                    {
                        NumberScore += (lives * 50);
                        GameEnvironment.GameStateManager.SwitchTo("WinState");
                        Reset();
                        return;
                    }
                    BirdLives.Children[lives].Position = new Vector2(-2000, 0);
                }
            }
            foreach (WoodMaterials woodM in WoodMat.Children)
            {
                if (woodM.CollidesWith(aBird))
                {
                    woodM.Reset();
                    aBird.Reset();
                    lives--;
                    woodM.Position = new Vector2(-2000, 0);

                    if (lives < 0)
                        gameOver = true;

                    if (lives < 0 && NumberScore <= 0)
                    {
                        GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                        Reset();
                        return;
                    }
                    else if (lives > 0 && NumberScore > 0 && gameOver|| lives < 0 && NumberScore > 0 && gameOver)
                    {
                        NumberScore += (lives * 50);
                        GameEnvironment.GameStateManager.SwitchTo("WinState");
                        Reset();
                        return;
                    }
                    BirdLives.Children[lives].Position = new Vector2(-2000, 0);
                   
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
