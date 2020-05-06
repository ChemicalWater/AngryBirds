using AngryBirds.GameObjects;
using Microsoft.Xna.Framework;

namespace AngryBirds
{
    class WinState : SpriteGameObject
    {
        public WinState() : base("spr_winState")
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
