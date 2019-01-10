using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGen
{
    class RoomCreator
    {


        List<byte[,]> rooms = new List<byte[,]>();

        public RoomCreator()
        {
            AddRooms();
        }


        void AddRooms()
        {


            //1x1

            rooms.Add(new byte[,]
            {
            { 1,1,},
            });


            rooms.Add(new byte[,]
            {
            { 0,1,},
            });

            rooms.Add(new byte[,]
            {
            { 1,0,},
            });





            //2x1

            rooms.Add(new byte[,]
            {
            { 1,0,0,1},
            });

            rooms.Add(new byte[,]
            {
            { 1,0,0,0},
            });

            rooms.Add(new byte[,]
            {
            { 0,0,0,1},
            });


            //2x2

            rooms.Add(new byte[,]
            {
            { 1,1},
            { 1,1},
            });

            rooms.Add(new byte[,]
            {
            { 1,1},
            { 0,0},
            });

            rooms.Add(new byte[,]
            {
            { 0,0},
            { 1,1},
            });

            rooms.Add(new byte[,]
            {
            { 1,0},
            { 0,1},
            });

            rooms.Add(new byte[,]
            {
            { 0,1},
            { 1,0},
            });

            rooms.Add(new byte[,]
            {
            { 1,0},
            { 1,0},
            });

            rooms.Add(new byte[,]
            {
            { 0,1},
            { 0,1},
            });

            rooms.Add(new byte[,]
            {
            { 0,1},
            { 0,0},
            });

            rooms.Add(new byte[,]
            {
            { 1,0},
            { 0,0},
            });

            rooms.Add(new byte[,]
            {
            { 0,0},
            { 1,0},
            });

            rooms.Add(new byte[,]
            {
            { 0,0},
            { 0,1},
            });


        }













        public List<Room> GetRooms(Texture2D wallTexture, Texture2D doorTexture)
        {
            List<Room> rms = new List<Room>();

            for (int i = 0; i < rooms.Count; i++)
            {
                int yL = (64 * rooms[i].GetLength(1));

                rms.Add(new Room(0, 0, 128 * rooms[i].GetLength(0), 64 * rooms[i].GetLength(1), wallTexture));
                for (int x = 0; x < rooms[i].GetLength(0); x++)
                {
                    for (int y = 0; y < rooms[i].GetLength(1); y++)
                    {
                        if (rooms[i][x, y] == 1)
                        {

                            int xPos = 0;
                            int yPos = 0;

                            if (x == 0 && y == 0)
                            {
                                yPos = rms[i].Size.Y / 4;
                            }
                            else if (x == 0 && y != 0)
                            {
                                yPos = rms[i].Size.Y - (rms[i].Size.Y / 4);
                                //
                            }
                            else if (x != 0 && y == 0)
                            {

                                xPos = rms[i].Size.X ;
                                yPos = rms[i].Size.Y / 4;

                            }
                            else if (x != 0 && y != 0)
                            {
                                xPos = rms[i].Size.X;
                                yPos = rms[i].Size.Y - (rms[i].Size.Y / 4);
                            }

                       
    


                            
                            Door dr = new Door(rms[i], xPos, yPos, (x == 0) ? Door.Wall.west : Door.Wall.east, doorTexture);

                            rms[i].Doors.Add(dr);
                        }
                    }
                }
            }

            return rms;
        }



    }
}
