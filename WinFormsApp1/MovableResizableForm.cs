using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public abstract class MovableResizableForm : Form, IMessageFilter
    {
        private const int WmNcHitTest = 0x0084;
        private const int WmNcLButtonDown = 0x00A1;
        private const int WmMouseMove = 0x0200;
        private const int WmLButtonUp = 0x0202;
        private const int WmXButtonDown = 0x020B;
        private const int WmXButtonUp = 0x020C;
        private const int WmXButtonDoubleClick = 0x020D;
        private const int XButton1 = 1;
        private const int HtCaption = 2;
        private const int HtLeft = 10;
        private const int HtRight = 11;
        private const int HtTop = 12;
        private const int HtTopLeft = 13;
        private const int HtTopRight = 14;
        private const int HtBottom = 15;
        private const int HtBottomLeft = 16;
        private const int HtBottomRight = 17;
        private const int DragAreaHeight = 56;
        private const int CornerRadius = 18;
        private Button? closeButton;
        private Button? backButton;
        private bool messageFilterRegistered;
        private bool isResizing;
        private int resizeHitTest;
        private Rectangle resizeStartBounds;
        private Point resizeStartCursor;

        protected MovableResizableForm()
        {
            RegisterDragHandlers(this);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateWindowRegion();
            AddCloseButton();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateWindowRegion();
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            UpdateWindowRegion();
        }

        private void UpdateWindowRegion()
        {
            Region? previousRegion = Region;
            if (WindowState != FormWindowState.Normal || Width <= 0 || Height <= 0)
            {
                Region = null;
                previousRegion?.Dispose();
                return;
            }

            int radius = Math.Min(
                (int)Math.Ceiling(CornerRadius * DeviceDpi / 96d),
                Math.Min(Width, Height) / 2);
            if (radius <= 0)
            {
                Region = null;
                previousRegion?.Dispose();
                return;
            }

            int diameter = radius * 2;
            using GraphicsPath path = new();
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(Width - diameter, 0, diameter, diameter, 270, 90);
            path.AddArc(Width - diameter, Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(0, Height - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            Region = new Region(path);
            previousRegion?.Dispose();
        }

        protected override void WndProc(ref Message message)
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                if (message.Msg == WmNcLButtonDown
                    && WindowState == FormWindowState.Normal
                    && IsResizeHitTest(message.WParam.ToInt32()))
                {
                    BeginResize(message.WParam.ToInt32());
                    message.Result = IntPtr.Zero;
                    return;
                }

                if (isResizing && message.Msg == WmMouseMove)
                {
                    ResizeWindow(Cursor.Position);
                    message.Result = IntPtr.Zero;
                    return;
                }

                if (isResizing && message.Msg == WmLButtonUp)
                {
                    EndResize();
                    message.Result = IntPtr.Zero;
                    return;
                }
            }

            base.WndProc(ref message);

            if (FormBorderStyle != FormBorderStyle.None || message.Msg != WmNcHitTest)
            {
                return;
            }

            long coordinates = message.LParam.ToInt64();
            int screenX = unchecked((short)(coordinates & 0xFFFF));
            int screenY = unchecked((short)((coordinates >> 16) & 0xFFFF));
            Point cursor = PointToClient(new Point(screenX, screenY));
            int resizeGrip = Math.Max(8, (int)Math.Ceiling(8 * DeviceDpi / 96d));

            bool left = cursor.X < resizeGrip;
            bool right = cursor.X >= ClientSize.Width - resizeGrip;
            bool top = cursor.Y < resizeGrip;
            bool bottom = cursor.Y >= ClientSize.Height - resizeGrip;

            if (WindowState == FormWindowState.Normal)
            {
                if (left && top)
                    message.Result = (IntPtr)HtTopLeft;
                else if (right && top)
                    message.Result = (IntPtr)HtTopRight;
                else if (left && bottom)
                    message.Result = (IntPtr)HtBottomLeft;
                else if (right && bottom)
                    message.Result = (IntPtr)HtBottomRight;
                else if (left)
                    message.Result = (IntPtr)HtLeft;
                else if (right)
                    message.Result = (IntPtr)HtRight;
                else if (top)
                    message.Result = (IntPtr)HtTop;
                else if (bottom)
                    message.Result = (IntPtr)HtBottom;
                else if (cursor.Y < DragAreaHeight && !IsInteractiveControl(FindControlAtPoint(this, cursor)))
                    message.Result = (IntPtr)HtCaption;
            }
            else if (WindowState == FormWindowState.Maximized
                && cursor.Y < DragAreaHeight
                && !IsInteractiveControl(FindControlAtPoint(this, cursor)))
            {
                message.Result = (IntPtr)HtCaption;
            }
        }

        private static bool IsResizeHitTest(int hitTest)
        {
            return hitTest is HtLeft or HtRight or HtTop or HtTopLeft or HtTopRight
                or HtBottom or HtBottomLeft or HtBottomRight;
        }

        private void BeginResize(int hitTest)
        {
            isResizing = true;
            resizeHitTest = hitTest;
            resizeStartBounds = Bounds;
            resizeStartCursor = Cursor.Position;
            Capture = true;
        }

        private void ResizeWindow(Point cursor)
        {
            int deltaX = cursor.X - resizeStartCursor.X;
            int deltaY = cursor.Y - resizeStartCursor.Y;
            int left = resizeStartBounds.Left;
            int top = resizeStartBounds.Top;
            int right = resizeStartBounds.Right;
            int bottom = resizeStartBounds.Bottom;
            int minimumWidth = Math.Max(1, MinimumSize.Width);
            int minimumHeight = Math.Max(1, MinimumSize.Height);

            if (resizeHitTest is HtLeft or HtTopLeft or HtBottomLeft)
                left = Math.Min(resizeStartBounds.Left + deltaX, right - minimumWidth);
            if (resizeHitTest is HtRight or HtTopRight or HtBottomRight)
                right = Math.Max(resizeStartBounds.Right + deltaX, left + minimumWidth);
            if (resizeHitTest is HtTop or HtTopLeft or HtTopRight)
                top = Math.Min(resizeStartBounds.Top + deltaY, bottom - minimumHeight);
            if (resizeHitTest is HtBottom or HtBottomLeft or HtBottomRight)
                bottom = Math.Max(resizeStartBounds.Bottom + deltaY, top + minimumHeight);

            Bounds = Rectangle.FromLTRB(left, top, right, bottom);
        }

        private void EndResize()
        {
            isResizing = false;
            resizeHitTest = 0;
            Capture = false;
        }

        protected void ConfigureBackButton(Button button)
        {
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            button.Location = new Point(20, 12);
            button.Size = new Size(78, 34);
            button.Text = "← Back";
            backButton = button;

            if (!messageFilterRegistered)
            {
                Application.AddMessageFilter(this);
                messageFilterRegistered = true;
            }
        }

        public bool PreFilterMessage(ref Message message)
        {
            if (backButton is null || !backButton.Visible || !backButton.Enabled || backButton.IsDisposed
                || !Visible || Form.ActiveForm != this
                || message.Msg is not (WmXButtonDown or WmXButtonUp or WmXButtonDoubleClick)
                || ((message.WParam.ToInt64() >> 16) & 0xFFFF) != XButton1)
            {
                return false;
            }

            if (message.Msg is WmXButtonDown or WmXButtonDoubleClick)
            {
                backButton.PerformClick();
            }

            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && messageFilterRegistered)
            {
                Application.RemoveMessageFilter(this);
                messageFilterRegistered = false;
            }

            base.Dispose(disposing);
        }

        protected void CenterControlsHorizontally(int layoutWidth, params Control[] controls)
        {
            if (controls.Length == 0 || controls[0].Parent is not Control parent)
            {
                return;
            }

            int offset = (parent.ClientSize.Width - layoutWidth) / 2;
            foreach (Control control in controls)
            {
                control.Location = new Point(control.Left + offset, control.Top);
                control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }

            int initialWidth = parent.ClientSize.Width;
            int[] initialLefts = controls.Select(control => control.Left).ToArray();
            parent.SizeChanged += (_, _) =>
            {
                int offset = (parent.ClientSize.Width - initialWidth) / 2;
                for (int index = 0; index < controls.Length; index++)
                {
                    controls[index].Left = initialLefts[index] + offset;
                }
            };
        }

        protected void CenterControlHorizontally(Control control)
        {
            if (control.Parent is not Control parent)
            {
                return;
            }

            control.Left = (parent.ClientSize.Width - control.Width) / 2;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            int initialWidth = parent.ClientSize.Width;
            int initialLeft = control.Left;
            parent.SizeChanged += (_, _) =>
            {
                control.Left = initialLeft + (parent.ClientSize.Width - initialWidth) / 2;
            };
        }

        private void AddCloseButton()
        {
            if (FormBorderStyle != FormBorderStyle.None || closeButton is not null)
            {
                return;
            }

            closeButton = new Button
            {
                AccessibleName = "Close window",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(253, 232, 230),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(153, 27, 27),
                Location = new Point(ClientSize.Width - 48, 8),
                Name = "closeWindowButton",
                Size = new Size(40, 34),
                TabStop = false,
                Text = "×",
                UseVisualStyleBackColor = false
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(164, 32, 24);
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(196, 43, 30);
            closeButton.MouseEnter += (_, _) => closeButton.ForeColor = Color.White;
            closeButton.MouseLeave += (_, _) => closeButton.ForeColor = Color.FromArgb(153, 27, 27);
            closeButton.Click += CloseButton_Click;
            Controls.Add(closeButton);
            closeButton.BringToFront();
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void HandleControlAdded(object? sender, ControlEventArgs e)
        {
            RegisterDragHandlers(e.Control);
        }

        private void RegisterDragHandlers(Control control)
        {
            if (control is Label label && string.Equals(label.Text.Trim(), "X", StringComparison.OrdinalIgnoreCase))
            {
                label.Visible = false;
            }

            if (control != this)
            {
                control.MouseDown += DragWindow_MouseDown;
                control.MouseDoubleClick += DragWindow_MouseDoubleClick;
            }

            control.ControlAdded += HandleControlAdded;
            foreach (Control child in control.Controls)
            {
                RegisterDragHandlers(child);
            }
        }

        private void DragWindow_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || WindowState != FormWindowState.Normal || sender is not Control control || !IsDragArea(control, e.Location))
            {
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, WmNcLButtonDown, HtCaption, 0);
        }

        private void DragWindow_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && sender is Control control && IsDragArea(control, e.Location))
            {
                WindowState = WindowState == FormWindowState.Maximized
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            }
        }

        private bool IsDragArea(Control control, Point location)
        {
            if (FormBorderStyle != FormBorderStyle.None || IsInteractiveControl(control))
            {
                return false;
            }

            Point formLocation = PointToClient(control.PointToScreen(location));
            return formLocation.Y >= 0 && formLocation.Y < DragAreaHeight;
        }

        private static bool IsInteractiveControl(Control? control)
        {
            return control is ButtonBase or TextBoxBase or ComboBox or DataGridView or LinkLabel
                || control is Label label && string.Equals(label.Text.Trim(), "X", StringComparison.OrdinalIgnoreCase);
        }

        private static Control? FindControlAtPoint(Control parent, Point location)
        {
            for (int index = parent.Controls.Count - 1; index >= 0; index--)
            {
                Control child = parent.Controls[index];
                if (!child.Visible || !child.Bounds.Contains(location))
                {
                    continue;
                }

                Point childLocation = new(location.X - child.Left, location.Y - child.Top);
                return FindControlAtPoint(child, childLocation) ?? child;
            }

            return null;
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr windowHandle, int message, int wParam, int lParam);
    }
}
