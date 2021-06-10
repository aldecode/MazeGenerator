using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MazeGenerator
{
    public partial class Form1 : Form
    {
        private int _cellWid, _cellHgt;
        private Bitmap _inBm = new(1, 1);
        private Maze _inMaze = new(10, 10);

        public Form1()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как...";
            
            //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.OverwritePrompt = true;
            
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            savedialog.CheckPathExists = true;
            
            //список форматов файла, отображаемый в поле "Тип файла"
            savedialog.Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            
            //отображается ли кнопка "Справка" в диалоговом окне
            savedialog.ShowHelp = true;
            
            if (savedialog.ShowDialog() == DialogResult.OK)
                try
                {
                    picMaze.Image.Save(savedialog.FileName, ImageFormat.Jpeg);
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            _inMaze.SolveMaze();
            DrawSolve();

            void DrawSolve()
            {
                Brush blueBrush = new SolidBrush(Color.DeepPink);
                Brush pinkBrush = new SolidBrush(Color.LightBlue);
                using (var gr = Graphics.FromImage(_inBm))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;

                    foreach (var c in _inMaze.Visited)
                    {
                        var point = new Point(c.X * _cellWid, c.Y * _cellWid);
                        var size = new Size(_cellWid, _cellWid);
                        var rec = new Rectangle(point, size);
                        gr.FillRectangle(pinkBrush, rec);
                    }

                    foreach (var c in _inMaze.Solve)
                    {
                        var point = new Point(c.X * _cellWid, c.Y * _cellWid);
                        var size = new Size(_cellWid, _cellWid);
                        var rec = new Rectangle(point, size);
                        gr.FillRectangle(blueBrush, rec);
                    }

                    gr.FillRectangle(new SolidBrush(Color.Green),
                        new Rectangle(new Point(_inMaze.Start.X * _cellWid, _inMaze.Start.Y * _cellWid),
                            new Size(_cellWid, _cellWid)));
                    gr.FillRectangle(new SolidBrush(Color.Red),
                        new Rectangle(new Point(_inMaze.Finish.X * _cellWid, _inMaze.Finish.Y * _cellWid),
                            new Size(_cellWid, _cellWid)));
                }

                picMaze.Image = _inBm;
            }
        }


        private void createBtn_Click(object sender, EventArgs e)
        {
            var width = 0;
            var height = 0;

            try
            {
                width = int.Parse(txtWidth.Text);
                height = int.Parse(txtHeight.Text);

                if (width == 0 || height == 0) throw new FormatException();
            }
            catch (FormatException)
            {
                const string message = "Размерность должна быть числом, больше 0.";
                var caption = "Ошибка ввода размерности";
                var buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                txtWidth.Text = @"10";
                txtHeight.Text = @"10";

                return;
            }


            var oddW = 0;
            var oddH = 0;
            
            if (width % 2 != 0) oddW = 1;
            if (height % 2 != 0) oddH = 1;
            
            _cellWid = picMaze.ClientSize.Width / (width + 2);
            _cellHgt = picMaze.ClientSize.Height / (height + 2);
            
            var cellMin = 10;
            if (_cellWid < cellMin)
            {
                _cellWid = cellMin;
                _cellHgt = _cellWid;
            }
            else if (_cellHgt < cellMin)
            {
                _cellHgt = cellMin;
                _cellWid = _cellHgt;
            }
            else if (_cellWid > _cellHgt)
            {
                _cellWid = _cellHgt;
            }
            else
            {
                _cellHgt = _cellWid;
            }


            var maze = new Maze(width, height);
            
            maze.Finish.X = maze.Finish.X + oddW;
            maze.Finish.Y = maze.Finish.Y + oddH;
            maze.CreateMaze();
            DrawMaze();

            _inMaze = maze;

            void DrawMaze()
            {
                _inBm.Dispose();
                
                var bm = new Bitmap(
                    _cellWid * (maze.Finish.X + 2),
                    _cellHgt * (maze.Finish.Y + 2), PixelFormat.Format16bppRgb555);

                Brush whiteBrush = new SolidBrush(Color.White);
                Brush blackBrush = new SolidBrush(Color.Black);

                using (var gr = Graphics.FromImage(bm))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    for (var i = 0; i < maze.Cells.GetUpperBound(0) + oddW; i++)
                    for (var j = 0; j < maze.Cells.GetUpperBound(1) + oddH; j++)
                    {
                        var point = new Point(i * _cellWid, j * _cellWid);
                        var size = new Size(_cellWid, _cellWid);
                        var rec = new Rectangle(point, size);
                        if (maze.Cells[i, j].IsCell)
                            gr.FillRectangle(whiteBrush, rec);
                        else
                            gr.FillRectangle(blackBrush, rec);
                    }

                    gr.FillRectangle(new SolidBrush(Color.Green),
                        new Rectangle(new Point(maze.Start.X * _cellWid, maze.Start.Y * _cellWid),
                            new Size(_cellWid, _cellWid)));
                    gr.FillRectangle(new SolidBrush(Color.Red),
                        new Rectangle(new Point(maze.Finish.X * _cellWid, maze.Finish.Y * _cellWid),
                            new Size(_cellWid, _cellWid)));
                }

                picMaze.Image = bm;
                _inBm = bm;
            }
        }
    }
}