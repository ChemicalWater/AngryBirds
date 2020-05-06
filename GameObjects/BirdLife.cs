using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryBirds
{
    class BirdLife : SpriteGameObject
    {
        private Vector2 startPosition;
        float wobblePhase;
        const float WOBBLE_FREQUENCY = 5.0f;
        const float WOBBLE_AMPLITUDE = 0.05f;

        public BirdLife(Vector2 Position) : base("spr_alien")
        {
            this.position = Position;
            startPosition = Position;
            wobblePhase = (float)(GameEnvironment.Random.NextDouble() * Math.PI * 2);
        }

        public override void Reset()
        {
            base.Reset();
            position = startPosition;
            velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Make life-symbol wobbly using trigonometry
            float t = (float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f;
            position += new Vector2((float)Math.Sin(t * WOBBLE_FREQUENCY + wobblePhase),
                                    (float)Math.Cos(t * WOBBLE_FREQUENCY + wobblePhase)) * WOBBLE_AMPLITUDE;
        }
    }
}
