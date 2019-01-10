using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGen
{
    public class Room
    {
        public Point Position;
        public Point Size;
        public List<Door> Doors;
        public Texture2D Texture;

        public int roomID = 0;


        public enum RoomType
        {
            cave, forrest
        }

        public RoomType roomType = RoomType.forrest;

        public Rectangle Destination
        {
            get
            {
                return new Rectangle(Position, Size);
            }
        }

        public Room(int x, int y, int width, int height, Texture2D texture)
        {
            Position = new Point(x, y);
            Size = new Point(width, height);
            Texture = texture;
            Doors = new List<Door>();
        }
        public Room(Room copy)
        {
            Position = copy.Position;
            Size = copy.Size;
            Texture = copy.Texture;

            Doors = new List<Door>();

            for (int i = 0; i < copy.Doors.Count; i++)
            {
                var dr = new Door(copy.Doors[i]);
                dr.Parent = this;
                Doors.Add(dr);
            }
        }

        public void Draw(SpriteBatch sb, SpriteFont font)
        {
            sb.Draw(Texture,
                destinationRectangle: Destination,
                color: Color.White,
                layerDepth: 0f);

            for (int i = 0; i < Doors.Count; i++)
            {
                Doors[i].Draw(sb);
            }

            sb.DrawString(font, roomID.ToString(), Destination.Location.ToVector2(), Color.Black);
        }
    }
}