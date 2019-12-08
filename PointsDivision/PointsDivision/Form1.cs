using PointsDivision.Classificator;
using PointsDivision.Draw;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PointsDivision
{
    public partial class Form1 : Form
    {
        private Bitmap _currentBitmap = null;
        private Graphics _currentGraphics = null;
        private Coordinator _coordinator = null;
        private List<PointExt> _allPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private void GeneratePoints_Click(object sender, EventArgs e)
        {
            _currentGraphics = mainPictureBox.CreateGraphics();
            _coordinator = new Coordinator(_currentGraphics, mainPictureBox, 15, 15);
            _currentGraphics = _coordinator.Execute();
             var pg = new PointGenerator(_currentGraphics, _coordinator);
            _currentGraphics = pg.Execute(Plane.TopRightTopTriangle, Color.Red, 5);
            _currentGraphics = pg.Execute(Plane.TopRightBottomTriangle, Color.Green, 5);
            _currentBitmap = new Bitmap(mainPictureBox.Width, mainPictureBox.Height, _currentGraphics);
            mainPictureBox.InitialImage = _currentBitmap;
            _allPoints = pg.AllPointsExt;
        }

        private void Classification_Click(object sender, EventArgs e)
        {
            // Classification
            if (_allPoints == null && _allPoints.Count == 0)
            {
                return;
            }
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var linearClassificator = new LinearClassificator(this, lineClassificatorTxb, _currentGraphics, _coordinator, mainPictureBox, _allPoints);
            linearClassificator.SetParams(a: 0.25F, b: 0, offset: 1, L: 0.5F);
            linearClassificator.Execute();
        }
    }
}