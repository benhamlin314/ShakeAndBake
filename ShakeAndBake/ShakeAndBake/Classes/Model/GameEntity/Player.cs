﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShakeAndBake.Model.GameEntity
{
    public class Player : Character
    {
        public Player() : base()
        {
            this.Velocity = 3;
            this.Acceleration = 2;
            this.FireRate = 60;
            this.sprite = ShakeAndBakeGame.player;;
        }

        public void Move(float newX, float newY)
        {
            float oldX = this.position.X, oldY = this.position.Y;
            //Move Player
            this.position.X = newX;
            this.position.Y = newY;
            //If newest user position updates moves the user out of the window 
            if (!this.isInWindow())
            {
                if (!this.IsInWindowWidth())
                {
                    this.position.X = oldX;
                }
                if (!this.IsInWindowHeight())
                {
                    this.position.Y = oldY;
                }
            }
        }
        public override void Update(GameTime gameTime, CollisionBoard cb)
        {
            //Remove player's collision bucket before update
            cb.RemoveFromBucketIfExists(this);

            base.Update(gameTime, cb);

            //Update collision board
            cb.FillBucket(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(ShakeAndBakeGame.player, position, Color.White);
            //spriteBatch.DrawString(null, "" + this.health, position, Color.White);
        }

        public override void FireProjectile()
        {
            if (!this.CanFire()) return;
            Vector2 pos = Vector2.Add(position, new Vector2((ShakeAndBakeGame.player.Width - ShakeAndBakeGame.playerBullet.Width) / 2,
             -ShakeAndBakeGame.playerBullet.Height));
            Projectile projectile = new PlayerBullet(new StraightPath(pos, new Vector2(0, -1), 3));

            //The projectiles position is set to the current character's position
            projectile.Position = pos;
            this.projectiles.Add(projectile);
        }
    }
}