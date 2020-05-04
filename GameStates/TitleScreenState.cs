using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds
{
    class TitleScreenState : SpriteGameObject
    {
        public TitleScreenState() : base("spr_startScreen")
        {

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed || inputHelper.MouseLeftButtonPressed() )
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
        }
    }
}
