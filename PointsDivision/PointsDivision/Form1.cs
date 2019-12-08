using PointsDivision.Classificator;
using PointsDivision.Draw;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PointsDivision
{
    public partial class Form1 : Form
    {
        private Bitmap _currentBitmap = null;
        private Graphics _currentGraphics = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratePoints_Click(object sender, EventArgs e)
        {
            var graphics = mainPictureBox.CreateGraphics();
            var coordinator = new Coordinator(graphics, mainPictureBox, 15, 15);
            graphics = coordinator.Execute();
             var pg = new PointGenerator(graphics, coordinator);
            graphics = pg.Execute(Plane.TopRightTopTriangle, Color.Red, 3);
            graphics = pg.Execute(Plane.TopRightBottomTriangle, Color.Green, 4);
            _currentGraphics = graphics;
            _currentBitmap = new Bitmap(mainPictureBox.Width, mainPictureBox.Height, graphics);
            mainPictureBox.InitialImage = _currentBitmap;

            // Classification
            var points = pg.AllPointsExt;
            var linearClassificator = new LinearClassificator(graphics, coordinator, mainPictureBox, points);
            linearClassificator.SetParams(a: 0.25F, b: 0, offset: 1);
            linearClassificator.Execute();
        }
    }
}