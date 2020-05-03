//using AngryBirds.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds
{
    class PlayingState : GameState
    {

        public PlayingState()
        {
            gameObjectList.Add(new GameObject("spr_background"));
        }
    }
}
