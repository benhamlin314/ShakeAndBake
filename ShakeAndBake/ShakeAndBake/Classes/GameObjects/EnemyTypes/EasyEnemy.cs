﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ShakeAndBake;

namespace GameClasses
{
    public class Easy : Enemy
    {
        //Easy Enemy Constructor
        public Easy() : base()
        {
            this.path = EnemyPaths.DefaultPath(this.position, new Vector2(0, 1));
            sprite = ShakeAndBakeGame.circle;
        }
        
        public override void Update(GameTime gameTime, CollisionBoard cb)
        {
            base.Update(gameTime, cb);
            
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); 
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
