using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WordleCopy_v1._0.Model
{
    public static class Animate
    {
        public static void Flip(TextBox tb)
        {
            ScaleTransform flipTransform = new ScaleTransform();


            tb.RenderTransformOrigin = new Point(0.5, 0.5);
            tb.RenderTransform = flipTransform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1,
                To = -1,
                Duration = TimeSpan.FromSeconds(0.3),
                AutoReverse = true
            };

            flipTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }

        public static void Shake(TextBox tb)
        {
            SkewTransform shakeTransform = new SkewTransform();


            tb.RenderTransformOrigin = new Point(0.5, 0.5);
            tb.RenderTransform = shakeTransform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 1,
                To = 10,
                Duration = TimeSpan.FromSeconds(0.2),
                AutoReverse = true
            };
            shakeTransform.BeginAnimation(SkewTransform.AngleXProperty, animation);
            shakeTransform.BeginAnimation(SkewTransform.AngleYProperty, animation);
        }

        public static void AnimateShake()
        {
            for (int i = (MainWindow.GuessCounter * 5) - 5; i < (MainWindow.GuessCounter * 5); i++)
            {
                Shake(MainWindow.tiles[i]);
            }
        }

        public static void DepressedAnimation(TextBox textBox)
        {

            var WidthAnimation = new DoubleAnimation()
            {
                From = textBox.ActualWidth,
                To = textBox.ActualWidth - 10,
                Duration = TimeSpan.FromSeconds(0.1),
                AutoReverse = true
            };
            var HeightAnimation = new DoubleAnimation()
            {
                From = textBox.ActualHeight,
                To = textBox.ActualHeight - 10,
                Duration = TimeSpan.FromSeconds(0.1),
                AutoReverse = true
            };
            textBox.BeginAnimation(TextBox.WidthProperty, WidthAnimation);
            textBox.BeginAnimation(TextBox.HeightProperty, HeightAnimation);
        }
    }
}
