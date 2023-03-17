using DrawWithWinForm.Shapes;
using System.Windows.Forms;

namespace DrawWithWinForm
{
    public partial class DrawDemo : Form
    {
        private readonly int _maxSpeed = 5;
        private readonly int _minSpeed = -3;
        private int _minShapeCount = 3;
        private int _maxShapeCount = 20;
        private int _sleepTime = 20;
        private bool _isRunning = false;
        private List<Shape> _myShapes = new List<Shape>();

        private Task? _drawTask = null;

        public DrawDemo()
        {
            InitializeComponent();

            chkboxShapes.Items.Clear();
            chkboxShapes.Items.Add("Rectangle", CheckState.Checked);
            chkboxShapes.Items.Add("Triangle", CheckState.Checked);
            chkboxShapes.Items.Add("Ellipse", CheckState.Checked);
            chkboxShapes.Items.Add("Text", CheckState.Checked);
            chkboxShapes.ItemCheck += ChkboxShapes_ItemCheck;

            this.SetStyle(ControlStyles.UserPaint 
                | ControlStyles.OptimizedDoubleBuffer 
                | ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.SupportsTransparentBackColor, true);
        }

        private void ChkboxShapes_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            lock (_myShapes)
            {
                var itm = chkboxShapes.GetItemCheckState(e.Index);
                if (itm == CheckState.Checked && e.Index == 0)
                    _myShapes.RemoveAll(shape => shape is Shapes.Rectangle);
                else if (itm == CheckState.Unchecked && e.Index == 0)
                    AddRectangle(_minShapeCount, _maxShapeCount);
                else if (itm == CheckState.Checked && e.Index == 1)
                    _myShapes.RemoveAll(shape => shape is Shapes.Triangle);
                else if (itm == CheckState.Unchecked && e.Index == 1)
                    AddTriangle(_minShapeCount, _maxShapeCount);
                else if (itm == CheckState.Checked && e.Index == 2)
                    _myShapes.RemoveAll(shape => shape is Shapes.Ellipse);
                else if (itm == CheckState.Unchecked && e.Index == 2)
                    AddEllipse(_minShapeCount, _maxShapeCount);
                else if (itm == CheckState.Checked && e.Index == 3)
                    _myShapes.RemoveAll(shape => shape is Shapes.TextShape);
            }
        }

        #region Add Test Shapes
        private void AddRectangle(int min, int max)
        {
            Enumerable.Range(min, max).ToList()
                .ForEach(x => _myShapes.Add(new Shapes.Rectangle()
                {
                    Height = Random.Shared.Next(30, 100),
                    Width = Random.Shared.Next(30, 100),
                    X = Random.Shared.Next(0, this.Width),
                    Y = Random.Shared.Next(0, this.Height),
                    XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                    YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                    Color = Color.FromArgb(
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
                   Height = Random.Shared.Next(30, 100),
                   Width = Random.Shared.Next(30, 100),
                   X = Random.Shared.Next(0, this.Width),
                   Y = Random.Shared.Next(0, this.Height),
                   XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   Color = Color.FromArgb(
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255))
               }));
        }
        private void AddEllipse(int min, int max)
        {
            Enumerable.Range(min, max).ToList()
               .ForEach(x => _myShapes.Add(new Shapes.Ellipse()
               {
                   Height = Random.Shared.Next(30, 100),
                   Width = Random.Shared.Next(30, 100),
                   X = Random.Shared.Next(0, this.Width),
                   Y = Random.Shared.Next(0, this.Height),
                   XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                   Color = Color.FromArgb(
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255),
                   Random.Shared.Next(0, 255))
               }));
        }

        #endregion
        private void Draw()
        {
            Brush myDrawingBrush = new SolidBrush(Color.Cyan);
            Pen pen = new Pen(myDrawingBrush);

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
                                _myShapes.ForEach(shape => shape.Draw(g, pen, this.Width, this.Height));
                        }

                        //invoke an action against the main thread to draw the buffer to the background image of the main form.
                        this.Invoke(new Action(() =>
                        {
                            this.BackgroundImage = buffer;
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
                if (chkboxShapes.GetItemCheckState(0) == CheckState.Checked)
                    AddRectangle(_minShapeCount, _maxShapeCount);

                if (chkboxShapes.GetItemCheckState(1) == CheckState.Checked)
                    AddTriangle(_minShapeCount, _maxShapeCount);

                if (chkboxShapes.GetItemCheckState(2) == CheckState.Checked)
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

        private void DrawDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isRunning = false;
            Thread.Sleep(100);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            StartStop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            _myShapes.Clear();
            this.Close();
        }

        private void btnAddText_Click(object sender, EventArgs e)
        {
            AddTekst();
        }

        private void AddTekst()
        {
            if (txtAdd.Text.Length > 0)
            {
                txtAdd.Text.Split().ToList()
                    .ForEach(s =>
                    {
                        lock (_myShapes)
                        {
                            _myShapes.Add(new Shapes.TextShape()
                            {
                                Height = Random.Shared.Next(16, 64),
                                Width = Random.Shared.Next(30, 100),
                                X = Random.Shared.Next(0, this.Width),
                                Y = Random.Shared.Next(0, this.Height),
                                XSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                                YSpeed = Random.Shared.Next(_minSpeed, _maxSpeed),
                                Color = Color.FromArgb(
                              Random.Shared.Next(0, 255),
                              Random.Shared.Next(0, 255),
                              Random.Shared.Next(0, 255)),
                                Text = s
                            });
                        }

                    });

                txtAdd.Text = string.Empty;
            }
        }

        private void txtAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddTekst();
            }

        }
    }
}