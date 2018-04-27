using System;
using System.Windows.Forms;
using System.Drawing;
namespace Lesson1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] objects;
        public static BaseObject[] objects_x;


        static Game() { }

        public static void Init(Form form) {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            Timer timer = new Timer { Interval=100};
            timer.Start();


            timer.Tick += Timer_Tick;

            g = form.CreateGraphics();
            Width = form.Width;
            Height=form.Height;


            Load();

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }

        public static void Timer_Tick(object sender, EventArgs ev)
        {
            Draw();
            Update();
        }

        public static void Draw() {
            #region first test graphic

            /*
                        Buffer.Graphics.Clear(Color.Black);
                        Buffer.Graphics.DrawRectangle(Pens.Wheat, new Rectangle(100, 100, 200, 200));
                        Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
                        Buffer.Render();
            */
            #endregion

            Buffer.Graphics.Clear(Color.Black);
            foreach(BaseObject obj in objects)
            {
                obj.Draw();
            }
            /*
            foreach (BaseObject obj_x in objects_x)
            {
                obj_x.Draw();
            }
            */
            Buffer.Render();
        }

        public static void Load()
        {
            objects = new BaseObject[30];
            objects_x = new BaseObject[10];
            Random rndPositionWidth = new Random();
            Random rndPositionHeight = new Random();
            Random rndStarSize = new Random();
            Random rndBOSize = new Random();
            
            for (int i = 0; i < objects.Length/2; i++)
            {
                int asteroidSize = rndBOSize.Next(30, 100);
                objects[i] = new BaseObject(new Point(rndPositionWidth.Next(10, Game.Width),rndPositionHeight.Next(10,Game.Height)),new Point(10 - i, 15 - i), new Size(asteroidSize, asteroidSize));
                Console.WriteLine($"Base Point{i}:600,{i*20} | {10-i},{15-i} | Size: {i},{i}");
            }
            for (int i = objects.Length / 2; i < objects.Length; i++)
            {
                objects[i] = new Star(new Point(Game.Width, i * 20), new Point(-i, 0), new Size(rndStarSize.Next(3, 8), rndStarSize.Next(3,8)));
                Console.WriteLine($"Star Point{i}:600,{i * 20} | {- i},{15 - i} | Size: {5},{5}");
            }
            
            for (int i = 0; i < objects_x.Length; i++)
            {
                objects_x[i] = new Objectx(new Point(600, i * 20), new Point(i*10, i*10), new Size(i,i));
                Console.WriteLine($"Objx Point{i}:600,{i * 20} | {-i},{15 - i} | Size: {5},{5}");
            }
            
        }

        public static void Update()
        {
            foreach(BaseObject obj in objects)
            {
                obj.Update();
            }
            foreach (BaseObject obj_x in objects_x)
            {
                obj_x.Update();
            }
        }



    }
}
