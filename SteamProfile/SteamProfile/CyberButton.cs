using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CyberpunkButton : Control
{
        // ── Цвета ──────────────────────────────────────────────
        private static readonly Color YellowColor = Color.FromArgb(0, 255, 0);
        private static readonly Color TextNormal = Color.FromArgb(220, 220, 220);
        private static readonly Color TextHover = Color.FromArgb(255, 255, 255);

        // ── Состояние анимации (0 = покой, 1 = hover) ──────────
        private float _anim = 0f;
        private float _flashAnim = 0f;
        private bool _isHovered = false;

        private readonly Timer _animTimer = new Timer { Interval = 16 };
        private readonly Timer _flashTimer = new Timer { Interval = 16 };

        // ── Свойство IsSelected (всегда в hover-виде) ──────────
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; _anim = value ? 1f : 0f; Invalidate(); }
        }

        public new string Text
        {
            get => base.Text;
            set { base.Text = value; Invalidate(); }
        }

        // ── Конструктор ────────────────────────────────────────
        public CyberpunkButton()
        {
            Size = new Size(320, 46);
            Margin = new Padding(0, 4, 0, 4);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            _animTimer.Tick += (s, e) =>
            {
                float target = (_isHovered || _isSelected) ? 1f : 0f;
                _anim += (_anim < target) ? 0.10f : -0.10f;
                _anim = Math.Max(0f, Math.Min(1f, _anim));
                Invalidate();
                if (Math.Abs(_anim - target) < 0.01f)
                {
                    _anim = target;
                    _animTimer.Stop();
                    Invalidate();
                }
            };

            _flashTimer.Tick += (s, e) =>
            {
                _flashAnim = Math.Max(0f, _flashAnim - 0.1f);
                Invalidate();
                if (_flashAnim <= 0f) _flashTimer.Stop();
            };
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            _animTimer.Start();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            if (!_isSelected) _animTimer.Start();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _flashAnim = 1f;
                _flashTimer.Start();
            }
        }

        // ── Отрисовка ──────────────────────────────────────────
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int w = Width, h = Height;
            int cut = 10; // размер среза угла (снизу справа)

            // ── Текст (всегда виден) ────────────────────────────
            Color txtColor = Lerp(TextNormal, TextHover, _anim);
            string fontName = ResolveFontName();
            using (var font = new Font(fontName, 13f, FontStyle.Bold, GraphicsUnit.Point))
            using (var txtBrush = new SolidBrush(txtColor))
            {
                var sf = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Near,
                    Trimming = StringTrimming.EllipsisCharacter
                };
                g.DrawString(base.Text, font, txtBrush,
                    new RectangleF(14, 0, w - 28, h), sf);
            }

            // Если анимация почти нулевая — не рисуем рамку
            if (_anim < 0.02f) return;

            // ── Форма со срезанным нижним правым углом ──────────
            // Точки по часовой: верх-лево → верх-право → (срез) → низ-право → низ-лево
            PointF[] shape =
            {
                new PointF(0,         0),
                new PointF(w - 1,     0),
                new PointF(w - 1,     h - cut),
                new PointF(w - cut,   h - 1),
                new PointF(0,         h - 1),
            };

            using (var path = new GraphicsPath())
            {
                path.AddPolygon(shape);

                // Внешнее свечение (несколько слоёв размытых линий)
                for (int i = 4; i >= 1; i--)
                {
                    int glowAlpha = (int)(30 * _anim * (1f / i));
                    using (var glowPen = new Pen(
                        Color.FromArgb(glowAlpha, YellowColor), i * 3f))
                    {
                        g.DrawPath(glowPen, path);
                    }
                }

                // Основная рамка
                using (var borderPen = new Pen(
                    Color.FromArgb((int)(255 * _anim), YellowColor), 1.5f))
                {
                    g.DrawPath(borderPen, path);
                }

                // Маленький акцент на срезе (яркая диагональная линия)
                using (var accentPen = new Pen(
                    Color.FromArgb((int)(200 * _anim), Color.White), 1f))
                {
                    g.DrawLine(accentPen,
                        w - cut - 2, h - 1,
                        w - 1, h - cut - 2);
                }
            }

            // ── Левая вертикальная полоска ──────────────────────
            using (var stripBrush = new SolidBrush(
                Color.FromArgb((int)(220 * _anim), YellowColor)))
            {
                g.FillRectangle(stripBrush, 0, 0, 3, h);
            }

            // ── Flash ───────────────────────────────────────────
            if (_flashAnim > 0f)
            {
                using (var flashBrush = new SolidBrush(
                    Color.FromArgb((int)(60 * _flashAnim), Color.White)))
                {
                    g.FillRectangle(flashBrush, 0, 0, w, h);
                }
            }
        }

        // ── Утилиты ────────────────────────────────────────────
        private static Color Lerp(Color a, Color b, float t)
        {
            t = Math.Max(0f, Math.Min(1f, t));
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        private static string ResolveFontName()
        {
            string[] candidates = { "Rajdhani", "Agency FB", "Arial Black", "Arial" };
            var installed = new System.Drawing.Text.InstalledFontCollection();
            var names = new System.Collections.Generic.HashSet<string>(
                StringComparer.OrdinalIgnoreCase);
            foreach (var ff in installed.Families)
                names.Add(ff.Name);
            foreach (var name in candidates)
                if (names.Contains(name)) return name;
            return "Arial";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animTimer.Dispose();
                _flashTimer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
