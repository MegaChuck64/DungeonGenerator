using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DungeonGen
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        List<Room> rooms = new List<Room>();

        List<List<Room>> dungeon = new List<List<Room>>();

        List<Door> doors = new List<Door>();

        SpriteFont font;

        Texture2D roomTexture;
        Texture2D doorTexture;

        Random rand = new Random();


        Camera camera = new Camera();

        GameTime gt;

        int createAttempts = 0;

        bool? passed = null;

        int lastRoomNumber = -1;

        RoomCreator roomCreator = new RoomCreator();
        enum State
        {
            idle, creating
        }

        State currentState = State.idle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
        }


        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            roomTexture = Content.Load<Texture2D>(@"Sprites\room");
            doorTexture = Content.Load<Texture2D>(@"Sprites\door");

            font = Content.Load<SpriteFont>(@"Fonts\consolas16");


            rooms = roomCreator.GetRooms(roomTexture, doorTexture);



            //for (int i = 0; i < rooms.Count; i++)
            //{
            //    int r = 0;

            //    //r = rand.Next(14);
            //    //if (r > 1)
            //    rooms[i].Doors.Add(new Door(rooms[i], 0, rooms[i].Size.Y - rooms[i].Size.Y / 4, Door.Wall.west, doorTexture));

            //    //r = rand.Next(14);
            //    //if (r > 1)
            //        rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X, rooms[i].Size.Y - rooms[i].Size.Y / 4, Door.Wall.east, doorTexture));



            //    ////r = rand.Next(14);
            //    ////if (r > 1)
            //    //    rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X - rooms[i].Size.X / 4, 0, Door.Wall.north, doorTexture));



            //    ////r = rand.Next(14);
            //    ////if (r > 1)
            //    //    rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X - rooms[i].Size.X / 4, rooms[i].Size.Y, Door.Wall.south, doorTexture));




            //    //r = rand.Next(14);
            //    //if (r > 1)
            //        rooms[i].Doors.Add(new Door(rooms[i], 0, rooms[i].Size.Y / 4, Door.Wall.west, doorTexture));


            //    //r = rand.Next(14);
            //    //if (r > 1)
            //        rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X, rooms[i].Size.Y / 4, Door.Wall.east, doorTexture));


            //    ////r = rand.Next(14);
            //    ////if (r > 1)
            //    //    rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X / 4, 0, Door.Wall.north, doorTexture));


            //    ////r = rand.Next(14);
            //    ////if (r > 1)
            //    //    rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X / 4, rooms[i].Size.Y, Door.Wall.south, doorTexture));


            //    if (rooms[i].Doors.Count < 2)
            //    {
            //        rooms[i].Doors.Add(new Door(rooms[i], rooms[i].Size.X, rooms[i].Size.Y - rooms[i].Size.Y / 4, Door.Wall.east, doorTexture));

            //        rooms[i].Doors.Add(new Door(rooms[i], 0, rooms[i].Size.Y / 4, Door.Wall.west, doorTexture));
            //    }
            //}


        }



        public bool CreateDungeon(int pathStepCount, int pathCount)
        {

            dungeon.Clear();
            doors.Clear();

            createAttempts++;

            for (int p = 0; p < pathCount; p++)
            {


                dungeon.Add(new List<Room>());

                if (p == 0)
                {
                    int r = rand.Next(rooms.Count);

                    Room firstRoom = new Room(rooms[r]);
                    firstRoom.roomID = r;
                    dungeon[p].Add(firstRoom);
                }
                else
                {
                    dungeon[p].Add(dungeon[p-1][rand.Next(dungeon[p-1].Count-1)]);
                }
                    for (int d = 0; d < dungeon[p][0].Doors.Count; d++)
                {
                    doors.Add(dungeon[p][0].Doors[d]);
                }

                //for each step
                for (int i = 1; i < pathStepCount; i++)
                {
                    //foreach (var r in rooms)
                    //{
                    //    r.Position = Point.Zero;
                    //}
                    bool canPlace;
                    Room newRoom;
                    int lastDoorNdx = 0;
                    int newDoorNdx = 0;

                    bool tryCountReached = false;

                    int tryCount = 0;
                    //pick a random room
                    do
                    {
                        tryCount++;

                        canPlace = true;
                        lastDoorNdx = 0;
                        newDoorNdx = 0;
                        tryCountReached = false;


                        int r = 0;

                        do
                        {
                            r = rand.Next(rooms.Count);
                        } while (r == lastRoomNumber);
    
                        newRoom = new Room(rooms[r]);
                        newRoom.roomID = r;

                        bool lastDoorUsed;


                        int doorLoopCount = 0;

                        //pick a random unused door from the last room placed

                        for (int b = 0; b < dungeon[p][i - 1].Doors.Count; b++)
                        {
                            if (!dungeon[p][i - 1].Doors[b].isConnected)
                            {
                                lastDoorNdx = b;
                                if (rand.Next(10) < 5) break;
                            }
                        }

                        //do
                        //{
                        //    lastDoorUsed = true;

                        //    lastDoorNdx = rand.Next(dungeon[p][i - 1].Doors.Count);

                        //    if (!dungeon[p][i - 1].Doors[lastDoorNdx].isConnected) lastDoorUsed = false;

                        //    doorLoopCount++;

                        //} while (lastDoorUsed && doorLoopCount < 8);

                        //if (doorLoopCount >= 8) tryCountReached = true;






                        Door.Wall? wallNeeded = null;

                        switch (dungeon[p][i - 1].Doors[lastDoorNdx].wall)
                        {
                            case Door.Wall.east:
                                wallNeeded = Door.Wall.west;
                                break;

                            case Door.Wall.south:
                                wallNeeded = Door.Wall.north;
                                break;

                            case Door.Wall.west:
                                wallNeeded = Door.Wall.east;
                                break;

                            case Door.Wall.north:
                                wallNeeded = Door.Wall.south;
                                break;

                        }

                        canPlace = false;

                        for (int k = 0; k < newRoom.Doors.Count; k++)
                        {
                            if (newRoom.Doors[k].wall == wallNeeded)
                            {
                                newDoorNdx = k;
                                canPlace = true;
                            }
                        }

                        newRoom.Position = dungeon[p][i - 1].Position + dungeon[p][i - 1].Doors[lastDoorNdx].Position - newRoom.Doors[newDoorNdx].Position;


                        //loop through already placed rooms
                        for (int j = 0; j < dungeon.Count; j++)
                        {
                            for (int l = 0; l < dungeon[j].Count; l++)
                            {

                                if (newRoom.Destination.Intersects(dungeon[j][l].Destination))
                                {
                                    canPlace = false;
                                }

                            }
                        }

        

                    } while (!canPlace /*|| tryCountReached) */&& tryCount < 500);


                    if (tryCount >= 500)
                    {
                        dungeon.Clear();
                        doors.Clear();

                        return false;
                    }
                    else
                    {

                        //dungeon[p][i - 1].Doors[lastDoorNdx].isConnected = true;
                        //newRoom.Doors[newDoorNdx].isConnected = true;
                        //newRoom.roomID = i;
                        for (int d = 0; d < newRoom.Doors.Count; d++)
                        {
                            doors.Add(newRoom.Doors[d]);
                        }
                        dungeon[p].Add(newRoom);

                    }
                }
            }



            for (int i = 0; i < doors.Count; i++)
            {
                var dr = doors[i];

                for (int j = 0; j < doors.Count; j++)
                {

                    dr.isConnected = false;
                    doors[j].isConnected = false;

                    if (i != j)
                    {
                        if (dr.Destination == doors[j].Destination)
                        {
                            dr.isConnected = true;
                            doors[j].isConnected = true;
                        }
                    }
                }
            }


            return true;
        }


        protected override void UnloadContent()
        {
        }

        KeyboardState keys;
        KeyboardState lastKeys;

        protected override void Update(GameTime gameTime)
        {

            gt = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            lastKeys = keys;
            keys = Keyboard.GetState();

            switch (currentState)
            {
                case State.idle:
                    if (keys.IsKeyDown(Keys.Space) && lastKeys.IsKeyUp(Keys.Space))
                    {
                        currentState = State.creating;
                        passed = null;
                        Draw(gt);

                        do
                        {
                            passed = CreateDungeon(8, 6);
                        } while (passed == false);

                        currentState = State.idle;
  
                    }
                    break;
                case State.creating:
                    break;
                default:
                    break;
            }


            camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.Transformation, sortMode: SpriteSortMode.FrontToBack);


            string state = "";
            switch (currentState)
            {
                case State.idle:
                    state = "Idle";
                    break;
                case State.creating:
                    state = "Creating";
                    break;
            }


            for (int i = 0; i < dungeon.Count; i++)
            {
                for (int j = 0; j < dungeon[i].Count; j++)
                {
                    dungeon[i][j].Draw(spriteBatch, font);
                }
            }



            spriteBatch.End();

            spriteBatch.Begin();

            string status = "";

            switch (passed)
            {
                case null:
                    status = "null";
                    break;

                case true:
                    status = "passed";
                    break;

                case false:
                    status = "failed";
                    break;
            }

            spriteBatch.DrawString(font, "State :    " + state, new Vector2(64, 64), Color.White);
            spriteBatch.DrawString(font, "Status:    " + status, new Vector2(64, 96), Color.White);

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}