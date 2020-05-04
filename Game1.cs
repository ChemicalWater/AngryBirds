using AngryBirds.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AngryBirds
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class Game1 : GameEnvironment
    {

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            screen = new Point(1024, 500);
            ApplyResolutionSettings();

            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.SwitchTo("PlayingState");
        }


    }
}
