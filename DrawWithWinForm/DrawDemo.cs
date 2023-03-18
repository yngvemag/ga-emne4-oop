using DrawWithWinForm.Controls;
using DrawWithWinForm.Shapes;
using System.Windows.Forms;

namespace DrawWithWinForm
{
    public partial class DrawDemo : Form
    {
        private readonly int _maxSpeed = 5;
        private readonly int _minSpeed = -5;
        private int _minShapeCount = 10;
        private int _maxShapeCount = 50;
        private int _minSize = 30;
        private int _maxSize = 100;
        private int _maxArea = 10000;
        private double _maxCircumference = 4 * 100;

        private int _sleepTime = 25;
        private bool _isRunning = false;
        private List<Shape> _myShapes = new List<Shape>();
        private Task? _drawTask = null;

        public DrawDemo()
        {
            InitializeComponent();

            drawPanel.DoubleBuffered = true;

            chkboxRectangle.CheckedChanged += ChkboxRectangle_CheckedChanged;
            chkboxEllipse.CheckedChanged += ChkboxEllipse_CheckedChanged;
            chkboxText.CheckedChanged += ChkboxText_CheckedChanged;
            chkboxTriangle.CheckedChanged += ChkboxTriangle_CheckedChanged;

            hscrollCircumference.Maximum = (int)_maxCircumference;
            hscrollCircumference.Value = (int)_maxCircumference;

            hscrollArea.Maximum = _maxArea;
            hscrollArea.Value = _maxArea;

            chkboxShowCircumference.Text = $"Show Circumference ({hscrollCircumference.Value})";
            chkboxShowArea.Text = $"Show Area ({hscrollArea.Value})";

            hscrollArea.ValueChanged += HscrollArea_ValueChanged;
            hscrollCircumference.ValueChanged += HscrollCircumference_ValueChanged;
            this.SetStyle(ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            StartStop();
        }

        private void HscrollCircumference_ValueChanged(object? sender, EventArgs e)
        {
            chkboxShowCircumference.Text = $"Show Circumference ({hscrollCircumference.Value})";
        }

        private void HscrollArea_ValueChanged(object? sender, EventArgs e)
        {
            chkboxShowArea.Text = $"Show Area ({hscrollArea.Value})";
        }

        #region Checkbox Changed
        private void ChkboxTriangle_CheckedChanged(object? sender, EventArgs e)
        {
            lock (_myShapes)
            {
                if (!chkboxTriangle.Checked)
                    _myShapes.RemoveAll(shape => shape is Shapes.Triangle);
                else AddTriangle(_minShapeCount, _maxShapeCount);
            }
        }

        private void ChkboxText_CheckedChanged(object? sender, EventArgs e)
        {
            lock (_myShapes)
            {
                if (!chkboxText.Checked)
                    _myShapes.RemoveAll(shape => shape is Shapes.TextShape);
            }
        }

        private void ChkboxEllipse_CheckedChanged(object? sender, EventArgs e)
        {
            lock (_myShapes)
            {
                if (!chkboxEllipse.Checked)
                    _myShapes.RemoveAll(shape => shape is Shapes.Circle);
                else AddEllipse(_minShapeCount, _maxShapeCount);
            }
        }

        private void ChkboxRectangle_CheckedChanged(object? sender, EventArgs e)
        {
            lock (_myShapes)
            {
                if (!chkboxRectangle.Checked)
                    _myShapes.RemoveAll(shape => shape is Shapes.Rectangle);
                else AddRectangle(_minShapeCount, _maxShapeCount);
            }
        }
        #endregion


        #region Add Test Shapes
        private void AddRectangle(int min, int max)
        {
            Enumerable.Range(min, max).ToList()
                .ForEach(x => _myShapes.Add(new Shapes.Rectangle()
                {
                    Height = Random.Shared.Next(_minSize, _maxSize),
                    Width = Random.Shared.Next(_minSize, _maxSize),
                    X = Random.Shared.Next(0, (int)(this.Width * .8)),
                    Y = Random.Shared.Next(0, (int)(this.Height * .6)),
                    XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                    YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                    Color = Color.White,
                    FillColor = Color.FromArgb(
                    Random.Shared.Next(0, 255),
                    Random.Shared.Next(0, 255),
                    Random.Shared.Next(0, 255))
                }));

        }
        private void AddTriangle(int min, int max)
        {
            Enumerable.Range(min, max).ToList()
               .ForEach(x => _myShapes.Add(new Shapes.Triangle()
               {
                   Height = Random.Shared.Next(_minSize, (int)(_maxSize * 1.3)),
                   Width = Random.Shared.Next(_minSize, (int)(_maxSize * 1.3)),
                   X = Random.Shared.Next(0, (int)(this.Width * .8)),
                   Y = Random.Shared.Next(0, (int)(this.Height * .6)),
                   XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   Color = Color.White,
                   FillColor = Color.FromArgb(
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255))
               }));
        }
        private void AddEllipse(int min, int max)
        {
            Enumerable.Range(min, max).ToList()
               .ForEach(x => _myShapes.Add(new Shapes.Circle()
               {
                   Height = Random.Shared.Next(_minSize, _maxSize),
                   Width = Random.Shared.Next(_minSize, _maxSize),
                   X = Random.Shared.Next(0, (int)(this.Width * .8)),
                   Y = Random.Shared.Next(0, (int)(this.Height * .6)),
                   XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   Color = Color.White,
                   FillColor = Color.FromArgb(
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255))
               }));
        }

        #endregion
        private void Draw()
        {
            //start an async task
            _drawTask = Task.Factory.StartNew(() =>
            {
                while (_isRunning)
                {
                    try
                    {
                        Bitmap buffer = new Bitmap(this.Width, this.Height);
                        Thread.Sleep(_sleepTime);
                        using (Graphics g = Graphics.FromImage(buffer))
                        {
                            lock (_myShapes)
                            {
                                _myShapes
                                .Where(s => s.GetArea() < hscrollArea.Value && s.GetCircumference() < hscrollCircumference.Value).ToList()
                                .ForEach(shape =>
                                {
                                    shape.Draw(g, drawPanel.Width, drawPanel.Height);
                                    if (chkboxShowArea.Checked)
                                        shape.DrawAreaString(g, drawPanel.Width, drawPanel.Height);
                                    if (chkboxShowCircumference.Checked)
                                        shape.DrawCirmuferenceString(g, drawPanel.Width, drawPanel.Height);

                                });
                            }
                        }

                        //invoke an action against the main thread to draw the buffer to the background image of the main form.
                        this.Invoke(new Action(() =>
                        {
                            drawPanel.BackgroundImage = buffer;
                            //this.BackgroundImage = buffer;
                        }));
                    }
                    catch (Exception ex) { return; }
                }
            });
        }

        private void DrawDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Space))
            {
                StartStop();
            }
        }

        private void StartStop()
        {
            btnStartStop.Text = "Start";
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                _myShapes.Clear();
                btnStartStop.Text = "Stop";
                if (chkboxRectangle.Checked)
                    AddRectangle(_minShapeCount, _maxShapeCount);

                if (chkboxTriangle.Checked)
                    AddTriangle(_minShapeCount, _maxShapeCount);

                if (chkboxEllipse.Checked)
                    AddEllipse(_minShapeCount, _maxShapeCount);

                Draw();
            }
            else
            {
                if (_drawTask != null)
                {
                    try
                    {
                        _drawTask.Dispose();
                    }
                    catch (Exception) { }
                }
            }

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            StartStop();
        }

        private void AddTekst()
        {
            if (txtAdd.Text.Length > 0)
            {

                lock (_myShapes)
                {
                    _myShapes.Add(new Shapes.TextShape()
                    {
                        Height = Random.Shared.Next(16, 64),
                        Width = Random.Shared.Next(30, 100),
                        X = Random.Shared.Next(0, (int)(this.Width * .6)),
                        Y = Random.Shared.Next(0, (int)(this.Height * .6)),
                        XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                        YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                        Color = Color.FromArgb(
                              Random.Shared.Next(100, 255),
                              Random.Shared.Next(100, 255),
                              Random.Shared.Next(100, 255)),
                        Text = txtAdd.Text
                    });
                }
                /*
                txtAdd.Text.Split().ToList()
                    .ForEach(s =>
                    {
                        

                    });
                */
                txtAdd.Text = string.Empty;
            }
        }

        private void txtAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkboxText.Checked)
            {
                AddTekst();
            }
        }
        private void DrawDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isRunning = false;
            Thread.Sleep(100);
        }
    }
}