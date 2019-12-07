using PointsDivision.Draw;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PointsDivision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratePoints_Click(object sender, EventArgs e)
        {
            var coordinator = new Coordinator(mainPictureBox, 15, 15);
            var bitmap = coordinator.Execute();
             var pg = new PointGenerator(coordinator);
            bitmap = pg.Execute(bitmap, Plane.TopLeft, Color.Red, 10);
            bitmap = pg.Execute(bitmap, Plane.BottomRight, Color.Green, 10);
            BitmapConfig.Set(bitmap);
            mainPictureBox.Image = bitmap;
        }
    }
}
