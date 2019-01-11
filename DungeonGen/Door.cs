using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGen
{
    public class Door
    {

        public enum Wall
        {
            north, east, south, west
        }


        public Wall wall;
        public Point Position;
        public Point Size;
        public Texture2D Texture;
        public Room Parent;
        public bool isConnected = false;

        public Door(Room parent, int x, int y, Wall _wall, Texture2D texture)
        {
            Parent = parent;
            Position = new Point(x, y);
            Texture = texture;
            Size = new Point(4, 4);
            wall = _wall;
        }

        public Rectangle Destination
        {
            get
            {
                return new Rectangle(Parent.Position + Position, Size);
            }
        }

        public Door(Door copy)
        {
            Parent = copy.Parent;
            Position = copy.Position;
            Texture = copy.Texture;
            Size = copy.Size;
            wall = copy.wall;
        }

        public void Draw(SpriteBatch sb)
        {


            //if (isConnected)
            //{
                sb.Draw(Texture,
                    destinationRectangle: Destination,
                    color: Color.White,
                    origin: new Vector2((Size.X / 2f), Size.Y / 2f),
                    layerDepth: 1f);
          //  }
        }
    }
}