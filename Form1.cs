using System;
using System.Drawing;
using System.Windows.Forms;
// TODO: ШАГ 1. Подключи библиотеку через директиву using

namespace VectorApp
{
    public partial class Form1 : Form
    {
        private PictureBox canvas;
        private ListBox logBox;
        private TextBox txtVx, txtVy, txtSx1, txtSy1, txtSx2, txtSy2;
        private Button btnAddVector, btnAddSegment, btnCheckPoint, btnClear;

        private float scale = 10f;

        // TODO: ШАГ 2. Создай два списка для хранения объектов твоей библиотеки (векторов и сегментов).

        public Form1()
        {
            InitializeComponentSetup();
        }

        private void InitializeComponentSetup()
        {
            this.Text = "Векторы и Отрезки (Оболочка)";
            this.Size = new Size(800, 600);

            Panel panel = new Panel { Parent = this, Dock = DockStyle.Right, Width = 300 };

            canvas = new PictureBox { Parent = this, Dock = DockStyle.Fill, BackColor = Color.White };
            canvas.Paint += Canvas_Paint;

            int y = 10;
            Label lblV = new Label { Parent = panel, Text = "Вектор/Точка (X; Y):", Location = new Point(10, y), AutoSize = true };
            y += 25;
            txtVx = new TextBox { Parent = panel, Location = new Point(10, y), Width = 50, Text = "5" };
            txtVy = new TextBox { Parent = panel, Location = new Point(70, y), Width = 50, Text = "5" };
            btnAddVector = new Button { Parent = panel, Location = new Point(130, y - 2), Text = "Добавить", Width = 80 };
            btnAddVector.Click += BtnAddVector_Click;

            y += 40;
            Label lblS = new Label { Parent = panel, Text = "Отрезок (X1; Y1) - (X2; Y2):", Location = new Point(10, y), AutoSize = true };
            y += 25;
            txtSx1 = new TextBox { Parent = panel, Location = new Point(10, y), Width = 40, Text = "-5" };
            txtSy1 = new TextBox { Parent = panel, Location = new Point(55, y), Width = 40, Text = "-5" };
            txtSx2 = new TextBox { Parent = panel, Location = new Point(105, y), Width = 40, Text = "10" };
            txtSy2 = new TextBox { Parent = panel, Location = new Point(150, y), Width = 40, Text = "10" };
            btnAddSegment = new Button { Parent = panel, Location = new Point(200, y - 2), Text = "Добавить", Width = 80 };
            btnAddSegment.Click += BtnAddSegment_Click;

            y += 40;
            btnCheckPoint = new Button { Parent = panel, Location = new Point(10, y), Text = "Проверить: Точка принадлежит Отрезку?", Width = 270 };
            btnCheckPoint.Click += BtnCheckPoint_Click;

            y += 40;
            btnClear = new Button { Parent = panel, Location = new Point(10, y), Text = "Очистить холст", Width = 270 };
            btnClear.Click += (s, e) =>
            {
                // TODO: ШАГ 3. Дополни функционал кнопки "Очистить холст", очистив списки методом Clear()
                logBox.Items.Clear();
                canvas.Invalidate();
            };

            y += 40;
            logBox = new ListBox { Parent = panel, Location = new Point(10, y), Width = 270, Height = 250 };

            panel.BringToFront();
        }

        private PointF ToScreen(double x, double y)
        {
            float screenX = (float)(canvas.Width / 2f + x * scale);
            float screenY = (float)(canvas.Height / 2f - y * scale);
            return new PointF(screenX, screenY);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen axisPen = new Pen(Color.LightGray, 1);
            g.DrawLine(axisPen, 0, canvas.Height / 2, canvas.Width, canvas.Height / 2);
            g.DrawLine(axisPen, canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);

            // TODO: ШАГ 4. Рисование объектов: раскомментируй код ниже

            /*
            Pen segmentPen = new Pen(Color.Blue, 2);
            foreach (var seg in segments)
            {
                // Получаем координаты начала и конца из твоего класса Segment (seg.Begin.X, seg.Begin.Y и т.д.)
                PointF p1 = ToScreen(seg.Begin.X, seg.Begin.Y);
                PointF p2 = ToScreen(seg.End.X, seg.End.Y);

                // Рисуем линию отрезка
                g.DrawLine(segmentPen, p1, p2);

                // Рисуем точки на концах отрезка
                g.FillEllipse(Brushes.Blue, p1.X - 3, p1.Y - 3, 6, 6);
                g.FillEllipse(Brushes.Blue, p2.X - 3, p2.Y - 3, 6, 6);
            }

            Pen vectorPen = new Pen(Color.Red, 2);
            vectorPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            PointF center = ToScreen(0, 0); // Начало координат (0;0)

            foreach (var v in vectors)
            {
                // Получаем координаты из твоего класса Vector
                PointF p = ToScreen(v.X, v.Y);

                // Рисуем вектор как стрелку из центра
                g.DrawLine(vectorPen, center, p);

                // Рисуем саму точку на конце вектора
                g.FillEllipse(Brushes.DarkRed, p.X - 4, p.Y - 4, 8, 8);
            }
        */

        }


        private void BtnAddVector_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtVx.Text, out double x) && double.TryParse(txtVy.Text, out double y))
            {
                // TODO: ШАГ 5. Работа с классом Vector из библиотеки
                // 1. Создай объект вектора с координатами x и y
                // 2. Добавь вектор в список
                // 3. Найди длину вектора и запиши в переменную length
                // 4. Добавь такую строку для вывода сообщения: logBox.Items.Add($"Вектор/Точка ({v.X}; {v.Y}), Длина: {length:F2}");
                canvas.Invalidate();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для координат вектора.", "Ошибка ввода");
            }
        }

        private void BtnAddSegment_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtSx1.Text, out double x1) && double.TryParse(txtSy1.Text, out double y1) &&
                double.TryParse(txtSx2.Text, out double x2) && double.TryParse(txtSy2.Text, out double y2))
            {
                // TODO: ШАГ 6. Работа с классом Segment из библиотеки
                // 1. Создай объект сегмента из векторов с координатами (x1;y1) и (x2;y2)
                // 2. Добавь сегмент в список
                // 3. Найди длину сегмента и запиши в переменную length
                // 4. Добавь такую строку для вывода сообщения: logBox.Items.Add($"Отрезок ({s.Begin.X};{s.Begin.Y})-({s.End.X};{s.End.Y}), Длина: {length:F2}");
                canvas.Invalidate();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для координат отрезка.", "Ошибка ввода");
            }
        }

        private void BtnCheckPoint_Click(object sender, EventArgs e)
        {
            // TODO: ШАГ 7. Проверка принадлежности точки отрезку: раскомментируй код ниже

            /*

            if (vectors.Count == 0 || segments.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одну точку (вектор) и один отрезок для проверки!", "Внимание");
                return;
            }

            Vector v = vectors[vectors.Count - 1];
            Segment s = segments[segments.Count - 1];

            bool isInside = v.Belongs(s);

            string resultText = isInside ? "ДА" : "НЕТ";
            logBox.Items.Add($"Принадлежит ли точка ({v.X}; {v.Y}) отрезку? {resultText}");

            */
        }
    }
}
