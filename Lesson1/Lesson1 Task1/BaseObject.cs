using System;
using System.Drawing;

namespace Lesson1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.DarkKhaki, Pos.X, Pos.Y, Size.Width, Size.Height);
            Bitmap asteroid = new Bitmap("J:\\Courses\\C#_2\\Lesson1\\Lesson1 Task1\\asteroid.jpg");
            Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public virtual void Update()
        {
            /*
            foreach(BaseObject objAst in Game.objects)
            {
                if ((Pos.X+Size.Width/2 == objAst.Pos.X+objAst.Size.Width/2) && 
                    (Pos.Y+Size.Height/2 == objAst.Pos.Y+objAst.Size.Height/))
                {
                    Dir.X = -Dir.X;
                    Dir.Y = -Dir.Y;
                }

            }
            */
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;

            if (Pos.X + Size.Width/2 <= Size.Width/2) Dir.X = -Dir.X;
            if (Pos.X + Size.Width/2 >= Game.Width- Size.Width/2) Dir.X = -Dir.X;

            if (Pos.Y + Size.Height/2 <= Size.Height/2) Dir.Y = -Dir.Y;
            if (Pos.Y + Size.Height/2 >= Game.Height-Size.Height/2) Dir.Y = -Dir.Y;
        }

    }
}
