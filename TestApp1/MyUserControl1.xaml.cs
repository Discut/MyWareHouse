using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace TestApp1
{
    public sealed partial class MyUserControl1 : UserControl
    {

        private Point _size;

        public Point Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public MyUserControl1()
        {
            this.InitializeComponent();


            this.PointerEntered += MyUserControl1_PointerEntered;
        }

        private void MyUserControl1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            //this.InfoBoxInAnimationTransform.Children[0].SetValue(Windows.UI.Xaml.Media.Animation.DoubleAnimation.FromProperty, this.InfoBoxInAnimation.Y);
            //InfoBoxInAnimationTransform.Children[0].SetValue(Windows.UI.Xaml.Media.Animation.DoubleAnimation.ToProperty, InfoBoxInAnimation.Y > 0 ? 100 : 0);
            //this.InfoBoxInAnimationTransform.Begin();
        }

        private void StackPanel_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            (sender as StackPanel).Translation = new System.Numerics.Vector3(0, 0, 0);
            //Windows.UI.Composition.ExpressionAnimation expressionAnimation = Window.Current.Compositor.CreateExpressionAnimation();
            //expressionAnimation.Expression = "Vector3(1/scaleElement.Scale.X, 1/scaleElement.Scale.Y, 1)";
            //expressionAnimation.Target = "Scale";

            //// Use SetExpressionReferenceParameter to alias a UIElement into the expression string
            //expressionAnimation.SetExpressionReferenceParameter("scaleElement", stack);

            //// Start the animation on the ellipse
            //(sender as Grid).StartAnimation(expressionAnimation);
            //Console.WriteLine("erntry");

        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            (sender as StackPanel).Translation = new System.Numerics.Vector3(0, -3, 0);
        }
    }
}
