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
            { 1,1,},
            });


            rooms.Add(new byte[,]
           {
            { 0,1,},
            { 1,0,},
           });

      //      rooms.Add(new byte[,]
      //{
      //      { 1,0,},
      //      { 0,0,},
      //});

      //      rooms.Add(new byte[,]
      //{
      //      { 0,0,},
      //      { 0,1,},
      //});

//            rooms.Add(new byte[,]
//      {
//            { 0,1,},
//            { 0,0,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 0,0,},
//            { 1,1,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 1,1,},
//            { 0,0,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 1,0,},
//            { 1,0,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 0,1,},
//            { 0,1,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 0,1,},
//            { 1,0,},
//      });

//            rooms.Add(new byte[,]
//      {
//            { 1,0,},
//            { 0,1,},
//      });



//            //2x1
//            rooms.Add(new byte[,]
//      {
//            { 1,0,0,1},
//            { 1,0,0,1},
//      });

//            rooms.Add(new byte[,]
//{
//            { 1,0,0,0},
//            { 0,0,0,0},
//});

//            rooms.Add(new byte[,]
//{
//            { 0,0,0,1},
//            { 0,0,0,0},
//});
//            rooms.Add(new byte[,]
//{
//            { 0,0,0,0},
//            { 1,0,0,0},
//});
//            rooms.Add(new byte[,]
//{
//            { 0,0,0,0},
//            { 0,0,0,1},
//});

//            rooms.Add(new byte[,]
//{
//            { 1,0,0,0},
//            { 1,0,0,0},
//});

//            rooms.Add(new byte[,]
//{
//            { 0,0,0,1},
//            { 0,0,0,1},
//});


//            rooms.Add(new byte[,]
//{
//            { 1,0,0,1},
//            { 0,0,0,0},
//});

//            rooms.Add(new byte[,]
//{
//            { 0,0,0,0},
//            { 1,0,0,1},
//});


//         //   1x2

//            rooms.Add(new byte[,]
//{
//            { 1,1},
//            { 0,0},
//            { 0,0},
//            { 1,1},
//});

//            rooms.Add(new byte[,]
//{
//            { 1,0},
//            { 0,0},
//            { 0,0},
//            { 0,0},
//});

//            rooms.Add(new byte[,]
//{
//            { 0,1},
//            { 0,0},
//            { 0,0},
//            { 0,0},
//});

//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 1,0},
//            { 0,0},
//            { 0,0},
//});


//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 0,1},
//            { 0,0},
//            { 0,0},
//});


//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 0,0},
//            { 1,0},
//            { 0,0},
//});


//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 0,0},
//            { 0,1},
//            { 0,0},
//});



//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 0,0},
//            { 0,0},
//            { 1,0},
//});



//            rooms.Add(new byte[,]
//{
//            { 0,0},
//            { 0,0},
//            { 0,0},
//            { 0,1},
//});





//            rooms.Add(new byte[,]
//{
//            { 0,1},
//            { 0,0},
//            { 0,0},
//            { 1,1},
//});



//            rooms.Add(new byte[,]
//{
//            { 1,0},
//            { 0,0},
//            { 0,0},
//            { 1,0},
//});


//            rooms.Add(new byte[,]
//{
//            { 0,1},
//            { 0,0},
//            { 0,0},
//            { 0,1},
//});


//            rooms.Add(new byte[,]
//{
//            { 0,1},
//            { 0,0},
//            { 0,1},
//            { 1,0},
//});

        }


        ////2x1

        //rooms.Add(new byte[,]
        //{
        //{ 1,0,0,1},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 1,0,0,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,0,0,1},
        //});


        ////2x2

        //rooms.Add(new byte[,]
        //{
        //{ 1,1},
        //{ 1,1},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 1,1},
        //{ 0,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,0},
        //{ 1,1},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 1,0},
        //{ 0,1},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,1},
        //{ 1,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 1,0},
        //{ 1,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,1},
        //{ 0,1},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,1},
        //{ 0,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 1,0},
        //{ 0,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,0},
        //{ 1,0},
        //});

        //rooms.Add(new byte[,]
        //{
        //{ 0,0},
        //{ 0,1},
        //});
















        public List<Room> GetRooms(Texture2D wallTexture, Texture2D doorTexture)
        {
            List<Room> rms = new List<Room>();

            for (int i = 0; i < rooms.Count; i++)
            {
                int yL = (64 * rooms[i].GetLength(1));

                rms.Add(new Room(0, 0, 18 * rooms[i].GetLength(0), 9 * rooms[i].GetLength(1), wallTexture));
                for (int x = 0; x < rooms[i].GetLength(0); x++)
                {
                    for (int y = 0; y < rooms[i].GetLength(1); y++)
                    {

                        //if the room is one unit tall (2 doors on each side)
                        //if (rooms[i].GetLength(1) == 2)
                        //{


                        int xPos = 0;
                        int yPos = 0;

                        if (rooms[i][x, y] == 1)
                        {
                            if (y == 0) yPos = 4;
                            else if (y == 1) yPos = 13;
                            else if (y == 2) yPos = 22;
                            else if (y == 3) yPos = 31;


                            if (x > 0) xPos = rms[i].Size.X;

                        }
                        // }


                        //if (rooms[i][x, y] == 1)
                        //{



                        //    if (x == 0 && y == 0)
                        //    {
                        //        yPos = 5;
                        //    }
                        //    else if (x == 0 && y != 0)
                        //    {
                        //        yPos = (rms[i].Size.Y-2) - ((rms[i].Size.Y-2) / 4) + 1;
                        //        //
                        //    }
                        //    else if (x != 0 && y == 0)
                        //    {

                        //        xPos = rms[i].Size.X ;
                        //        yPos = (rms[i].Size.Y -2)/ 4 + 1;

                        //    }
                        //    else if (x != 0 && y != 0)
                        //    {
                        //        xPos = rms[i].Size.X;
                        //        yPos = (rms[i].Size.Y-2) - ((rms[i].Size.Y - 2)/ 4) + 1;
                        //    }






                        Door dr = new Door(rms[i], xPos, yPos, (x == 0) ? Door.Wall.west : Door.Wall.east, doorTexture);

                        rms[i].Doors.Add(dr);
                    }
                }
            }
        

            return rms;
        }



}
}
