using System.ComponentModel;

namespace Rsreu.Diploma.Controls;

public partial class ExtendedPictureBox : PictureBox
{
    private bool _regionSelectionEnabled;
    private Rectangle _region;
    private MouseButtons _mouseDownButton;
    private Point _mouseDownPosition;
    private Point _bufferPoint;

    public ExtendedPictureBox()
    {
        InitializeComponent();

        _region = new();
    }

    [Browsable(true)]
    [DefaultValue(false)]
    public bool RegionSelectionEnabled
    {
        get => _regionSelectionEnabled;
        set
        {
            if (value)
            {
                MouseDown += OnMouseDown;
                MouseMove += OnMouseMove;
                MouseUp += OnMouseUp;
            }
            else
            {
                MouseDown -= OnMouseDown;
                MouseMove -= OnMouseMove;
                MouseUp -= OnMouseUp;
            }

            _regionSelectionEnabled = value;
        }
    }

    public event EventHandler<RegionSelectionEventArgs> RegionSelected;

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        _mouseDownPosition = e.Location;
        _mouseDownButton = e.Button;
        _bufferPoint = Point.Empty;

        if (SizeMode == PictureBoxSizeMode.Zoom)
        {
            var inImage = RemapCursorPosOnZoomedImage(this, e.X, e.Y, out var point);
            _region.Location = inImage ? point : Point.Empty;
        }
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        if (!_bufferPoint.IsEmpty)
        {
            DrawReversibleRectangle(GetRectangle(_bufferPoint, _mouseDownPosition));
        }

        DrawReversibleRectangle(GetRectangle(e.Location, _mouseDownPosition));
        _bufferPoint = e.Location;

        RemapCursorPosOnZoomedImage(this, _mouseDownPosition.X, _mouseDownPosition.Y, out var mouseDownPosition);
        RemapCursorPosOnZoomedImage(this, _bufferPoint.X, _bufferPoint.Y, out var bufferPoint);

        _region.Size = new Size(Math.Abs(mouseDownPosition.X - bufferPoint.X), Math.Abs(mouseDownPosition.Y - bufferPoint.Y));

        Invalidate();
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && _mouseDownButton == MouseButtons.Left)
        {
            if (!_bufferPoint.IsEmpty)
            {
                DrawReversibleRectangle(GetRectangle(_bufferPoint, _mouseDownPosition));
                _bufferPoint = Point.Empty;
            }
            if (!new Rectangle(Point.Empty, GetImageSize()).Contains(_mouseDownPosition))
            {
                return;
            }
        }

        _mouseDownButton = MouseButtons.None;

        var inImage = RemapCursorPosOnZoomedImage(this, e.X, e.Y, out var point);
        if (inImage)
        {
            RegionSelected?.Invoke(this, new RegionSelectionEventArgs(_region, e.Location));
        }
    }

    protected internal Size GetImageSize()
    {
        return Image is null ? default : Image.Size;
    }

    protected internal static Size Min(Size s1, Size s2)
    {
        return new Size((s1.Width < s2.Width) ? s1.Width : s2.Width, (s1.Height < s2.Height) ? s1.Height : s2.Height);
    }

    private void DrawReversibleRectangle(Rectangle rect)
    {
        rect.Location = PointToScreen(rect.Location);
        ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Thick);
    }

    public static Rectangle GetRectangle(Point p1, Point p2)
    {
        int x = Math.Min(p1.X, p2.X);
        int y = Math.Min(p1.Y, p2.Y);

        var width = Math.Max(p1.X, p2.X) - x;
        var height = Math.Max(p1.Y, p2.Y) - y;

        return new Rectangle(x, y, width, height);
    }

    private static bool RemapCursorPosOnZoomedImage(PictureBox pictureBox, int x, int y, out Point result)
    {
        // original size of image in pixel
        float imgSizeX = pictureBox.Image.Width;
        float imgSizeY = pictureBox.Image.Height;

        // current size of picturebox (without border)
        float cSizeX = pictureBox.ClientSize.Width;
        float cSizeY = pictureBox.ClientSize.Height;

        // calculate scale factor for both sides
        float facX = cSizeX / imgSizeX;
        float facY = cSizeY / imgSizeY;

        // use smaller one to fit picturebox zoom layout
        float factor = Math.Min(facX, facY);

        // calculate current size of the displayed image
        float rSizeX = imgSizeX * factor;
        float rSizeY = imgSizeY * factor;

        // calculate offsets because image is centered
        float startPosX = (cSizeX - rSizeX) / 2;
        float startPosY = (cSizeY - rSizeY) / 2;

        float endPosX = startPosX + rSizeX;
        float endPosY = startPosY + rSizeY;

        // check if cursor hovers image
        var isInImage = true;
        if (x < startPosX || x > endPosX) isInImage = false;
        if (y < startPosY || y > endPosY) isInImage = false;

        // remap cursor position
        float cPosX = (x - startPosX) / factor;
        float cPosY = (y - startPosY) / factor;

        // create new point with mapped coords
        result = new Point((int)cPosX, (int)cPosY);
        return isInImage;
    }
}

public class RegionSelectionEventArgs : EventArgs
{
    public RegionSelectionEventArgs(Rectangle region, Point bottomRight) 
    {
        Region = region;
        BottomRight = bottomRight;
    }

    public Rectangle Region { get; }

    public Point BottomRight { get; }
}
