using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AngryBirds
{
    class GameOverState : SpriteGameObject
    {
        public GameOverState() : base("spr_GameOver")
        {

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed || inputHelper.MouseLeftButtonPressed())
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
