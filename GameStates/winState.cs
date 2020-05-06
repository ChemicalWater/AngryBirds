using AngryBirds.GameObjects;
using Microsoft.Xna.Framework;

namespace AngryBirds
{
    class WinState : SpriteGameObject
    {
        TextGameObject score;
        public WinState() : base("spr_winState")
        {
            score = new TextGameObject("GameFont");
            score.Text = AngryBirds.GameStates.PlayingState.NumberScore.ToString();
            score.Position = new Vector2(200, 30);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed || inputHelper.MouseLeftButtonPressed())
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
