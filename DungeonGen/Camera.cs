using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGen
{
    public class Camera
    {
        public Vector2 Translation = Vector2.Zero;
        public float Scale = 1f;

        public Matrix Transformation;

        public float ScaleSpeed = 0.1f;
        public float moveSpeed = 224f;

        public void Update(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Translation.Y -= moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Translation.Y += moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Translation.X += moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Translation.X -= moveSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Scale += ScaleSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Scale -= ScaleSpeed * (float)gt.ElapsedGameTime.TotalSeconds;
            }


            Transformation = Matrix.Identity * Matrix.CreateScale(Scale) * Matrix.CreateTranslation(Translation.X, Translation.Y, 0);
        }
    }
}