using System;
using System.Drawing;
using System.Windows.Forms;

namespace FRMBIER
{
    public partial class FrmGen : Form
    {

        private Button btnCalcular;
        private Label lblArea, lblPerimetro, lblScale, lblRotation;
        private float scale = 0.001f;
        private float rotation = 0f;
        private PointF position = new PointF(0, 0);
        private string currentFigure = "";
        private PointF[] currentPoints;

        public FrmGen()
        {
            InitializeComponent();
            this.KeyPreview = true;
            btnCalcular = new Button { Text = "Calcular", Location = new Point(10, 300), Size = new Size(100, 30) };
            btnCalcular.Click += btnCalcular_Click;
            this.Controls.Add(btnCalcular);

            lblArea = new Label { Location = new Point(120, 305), AutoSize = true };
            lblPerimetro = new Label { Location = new Point(120, 330), AutoSize = true };

            lblScale = new Label { Text = "Escala: 1.0x", Location = new Point(10, 370), AutoSize = true };

            scaleTrackBar.Scroll += ScaleTrackBar_Scroll;
            lblRotation = new Label { Text = "Rotación: 0°", Location = new Point(10, 410), AutoSize = true };
       rotationTrackBar.Scroll += RotationTrackBar_Scroll;

            this.Controls.AddRange(new Control[] {
                lblArea, lblPerimetro,
            });

            this.KeyDown += Form1_KeyDown;
        }

        private void ScaleTrackBar_Scroll(object sender, EventArgs e)
        {
            scale = scaleTrackBar.Value / 10f;
            lblScale.Text = $"Escala: {scale:F1}x";
            RedrawFigure();
        }

        private void RotationTrackBar_Scroll(object sender, EventArgs e)
        {
            rotation = rotationTrackBar.Value;
            lblRotation.Text = $"Rotación: {rotation}°";
            RedrawFigure();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            const float moveStep = 10f;

            switch (e.KeyCode)
            {
                case Keys.Up: position.Y -= moveStep; break;
                case Keys.Down: position.Y += moveStep; break;
                case Keys.Left: position.X -= moveStep; break;
                case Keys.Right: position.X += moveStep; break;
                case Keys.Add:
                case Keys.Oemplus:
                    scaleTrackBar.Value = Math.Min(scaleTrackBar.Maximum, scaleTrackBar.Value + 1);
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    scaleTrackBar.Value = Math.Max(scaleTrackBar.Minimum, scaleTrackBar.Value - 1);
                    break;
                case Keys.Q:
                    rotationTrackBar.Value = (rotationTrackBar.Value - 5 + 360) % 360;
                    break;
                case Keys.E:
                    rotationTrackBar.Value = (rotationTrackBar.Value + 5) % 360;
                    break;
                default: return;
            }

            RedrawFigure();
            e.Handled = true;
        }

        private void RedrawFigure()
        {
            if (currentPoints == null) return;

            Bitmap bmp = new Bitmap(picCnv.Width, picCnv.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.TranslateTransform(picCnv.Width / 2 + position.X, picCnv.Height / 2 + position.Y);
                g.ScaleTransform(scale, scale);
                g.RotateTransform(rotation);

                using (Pen pen = new Pen(Color.Blue, 1))
                {
                    g.DrawPolygon(pen, currentPoints);
                }
            }
            picCnv.Image = bmp;
        }

        private void cmbFig_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlParametros.Controls.Clear();
            currentFigure = cmbFig.SelectedItem?.ToString();
            if (currentFigure == null) return;

            switch (currentFigure)
            {
                case "Rombo":
                    AddParametro("Diagonal 1", "txtD1");
                    AddParametro("Diagonal 2", "txtD2");
                    break;
                case "Pentágono":
                    AddParametro("Lado", "txtLado");
                    break;
                case "Romboide":
                    AddParametro("Base", "txtBase");
                    AddParametro("Altura", "txtAltura");
                    break;
                case "Trapezoide":
                    AddParametro("Base mayor", "txtBMayor");
                    AddParametro("Base menor", "txtBMenor");
                    AddParametro("Altura", "txtAltura");
                    break;
            }
            RedrawFigure();
        }

        private void AddParametro(string labelText, string textboxName)
        {
            int y = pnlParametros.Controls.Count * 30;
            pnlParametros.Controls.Add(new Label { Text = labelText, Location = new Point(10, y) });
            pnlParametros.Controls.Add(new TextBox { Name = textboxName, Location = new Point(120, y), Width = 130 });
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFigure))
            {
                MessageBox.Show("Selecciona una figura primero.");
                return;
            }

            try
            {
                float area = 0, perimetro = 0;
                float.TryParse(GetParamValue("scale").ToString(), out scale);

                switch (currentFigure)
                {
                    case "Rombo":
                        float d1 = GetParamValue("txtD1");
                        float d2 = GetParamValue("txtD2");
                        area = (d1 * d2) / 2;
                        perimetro = 4 * (float)Math.Sqrt((d1 * d1 + d2 * d2) / 2);
                        currentPoints = CreateRhombusPoints(d1, d2);
                        break;
                    case "Pentágono":
                        float lado = GetParamValue("txtLado");
                        area = (5 * lado * lado) / (4 * (float)Math.Tan(Math.PI / 5));
                        perimetro = 5 * lado;
                        currentPoints = CreatePentagonPoints(lado);
                        break;
                    case "Romboide":
                        float b = GetParamValue("txtBase");
                        float h = GetParamValue("txtAltura");
                        area = b * h;
                        perimetro = 2 * (b + h);
                        currentPoints = CreateParallelogramPoints(b, h);
                        break;
                    case "Trapezoide":
                        float B = GetParamValue("txtBMayor");
                        float bm = GetParamValue("txtBMenor");
                        float alt = GetParamValue("txtAltura");
                        area = (B + bm) * alt / 2;
                        perimetro = B + bm + 2 * alt;
                        currentPoints = CreateTrapezoidPoints(B, bm, alt);
                        break;
                }

                lblArea.Text = $"Área: {area:F2}";
                lblPerimetro.Text = $"Perímetro: {perimetro:F2}";
                RedrawFigure();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private float GetParamValue(string name)
        {
            var control = pnlParametros.Controls.Find(name, false);
            if (control.Length == 0 || !float.TryParse(control[0].Text, out float value))
                return 50f; // Default value
            return value;
        }

        private PointF[] CreateRhombusPoints(float d1, float d2)
        {
            return new PointF[] {
                new PointF(0, -d2/2),
                new PointF(d1/2, 0),
                new PointF(0, d2/2),
                new PointF(-d1/2, 0)
            };
        }

        private PointF[] CreatePentagonPoints(float side)
        {
            PointF[] points = new PointF[5];
            float R = side / (2 * (float)Math.Sin(Math.PI / 5));
            for (int i = 0; i < 5; i++)
            {
                double angle = -Math.PI / 2 + i * 2 * Math.PI / 5;
                points[i] = new PointF(
                    R * (float)Math.Cos(angle),
                    R * (float)Math.Sin(angle)
                );
            }
            return points;
        }

        private PointF[] CreateParallelogramPoints(float b, float h)
        {
            return new PointF[] {
                new PointF(-b/2, -h/2),
                new PointF(b/2, -h/2),
                new PointF(b/2 - b/4, h/2),
                new PointF(-b/2 - b/4, h/2)
            };
        }

        private PointF[] CreateTrapezoidPoints(float B, float b, float h)
        {
            return new PointF[] {
                new PointF(-B/2, h/2),
                new PointF(B/2, h/2),
                new PointF(b/2, -h/2),
                new PointF(-b/2, -h/2)
            };
        }

    }
}