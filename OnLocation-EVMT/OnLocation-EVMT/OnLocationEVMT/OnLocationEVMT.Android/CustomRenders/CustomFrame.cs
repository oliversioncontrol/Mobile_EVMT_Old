using Android.Content;
using Android.Graphics;
using OnLocationEVMT.Controls;
using OnLocationEVMT.Droid.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ACanvas = Android.Graphics.Canvas;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomFrames), typeof(CustomFrame))]
namespace OnLocationEVMT.Droid.CustomRenders
{
   public class CustomFrame:FrameRenderer
    {
        public CustomFrame(Context context) : base(context)
        {
            //AutoPackage = false;
        }
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            DrawOutline(canvas, canvas.Width, canvas.Height, 5f);//set corner radius
        }
        /// <summary>
        /// Method to create a border for button
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="cornerRadius"></param>
        void DrawOutline(ACanvas canvas, int width, int height, float cornerRadius)
        {
            using (var paint = new Paint { AntiAlias = true })
            using (var path = new Path())
            using (Path.Direction direction = Path.Direction.Cw)
            using (Paint.Style style = Paint.Style.Stroke)
            using (var rect = new RectF(0, 0, width, height))
            {
                float rx = Context.ToPixels(cornerRadius);
                float ry = Context.ToPixels(cornerRadius);
                path.AddRoundRect(rect, rx, ry, direction);

                paint.StrokeWidth = 2f;  //set outline stroke
                paint.SetStyle(style);
                paint.Color = Android.Graphics.Color.ParseColor("#918E85");//set outline color
                canvas.DrawPath(path, paint);
            }
        }

    }
}