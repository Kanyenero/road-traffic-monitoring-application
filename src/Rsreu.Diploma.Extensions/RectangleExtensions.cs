using System.Drawing;

namespace Rsreu.Diploma.Extensions;

public static class RectangleExtensions
{
    public static Point Center(this Rectangle rectangle)
    {
        return new Point(rectangle.Left + rectangle.Width / 2, rectangle.Top + rectangle.Height / 2); ;
    }

    public static double IntersectionOverUnion(this RectangleF a, RectangleF b)
    {
        var intersection = RectangleF.Intersect(a, b);
        if (intersection.IsEmpty)
        {
            return 0d;
        }

        double intersectArea = (1.0 + intersection.Width) * (1.0 + intersection.Height);
        double unionArea = ((1.0 + a.Width) * (1.0 + a.Height)) + ((1.0 + b.Width) * (1.0 + b.Height)) - intersectArea;

        return intersectArea / (unionArea + 1e-5);
    }

    public static RectangleF ToRectangleF(this Rectangle rectangle)
    {
        return new RectangleF(rectangle.Location, rectangle.Size);
    }
}
