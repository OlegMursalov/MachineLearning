using PointsDivision.Draw;
using System;
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
            var pg1 = new PointGenerator(coordinator, 10, Color.Red, Plane.TopLeft);
            bitmap = pg1.Execute(bitmap);
            var pg2 = new PointGenerator(coordinator, 10, Color.Green, Plane.BottomRight);
            bitmap = pg2.Execute(bitmap);
            mainPictureBox.Image = bitmap;
        }
    }
}
