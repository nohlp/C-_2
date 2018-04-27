using System;
using System.Drawing;

namespace Lesson1
{
    class Objectx : BaseObject
    {
        public Objectx(Point pos, Point dir, Size size) : base(pos, dir, size)
        {}

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y,Pos.X, Pos.Y + Size.Height);
            Bitmap objx= new Bitmap("J:\\Courses\\C#_2\\Lesson1\\Lesson1 Task1\\objectx.jpg");
            Game.Buffer.Graphics.DrawImage(objx, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X + Size.Width <= 0) Dir.X = -Dir.X;
            if (Pos.X + Size.Width >= Game.Width) Dir.X = -Dir.X;
            if (Pos.Y + Size.Height <= 0) Dir.Y = -Dir.Y;
            if (Pos.Y + Size.Height >= Game.Height) Dir.Y = -Dir.Y;
        }

    }
}
