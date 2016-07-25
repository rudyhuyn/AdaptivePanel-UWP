using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Linq;

namespace Huyn
{


    public enum AdaptiveBehavior { Standard = 0, StretchToMaxSizeIfPossible = 1, MinSizeOnlyIfAvailable = 2 }

    public sealed class AdaptivePanel : Panel
    {

        protected override Size ArrangeOverride(Size finalSize)
        {


            var newSize = ComputeSize(finalSize, false);

            foreach (var item in Children)
            {
                item.Arrange(new Rect(0, 0, newSize.Width, newSize.Height));
            }
            return newSize;
        }


        protected override Size MeasureOverride(Size availableSize)
        {


            return ComputeSize(availableSize, true);
        }

        private Size ComputeSize(Size availableSize, bool isMeasure)
        {



            double computedWidth = 0d;
            double computedHeight = 0d;


            if (isMeasure)
                foreach (var item in Children)
                {
                    item.Measure(availableSize);
                }

            var maxWidthChildren = Children.Select(c => c.DesiredSize.Width).Max();
            var maxHeightChildren = Children.Select(c => c.DesiredSize.Height).Max();
            return new Size(ComputeOneDimension(HorizontalBehavior, availableSize.Width, MinWidth, MaxWidth, maxWidthChildren, HorizontalAlignment == HorizontalAlignment.Stretch),
                ComputeOneDimension(VerticalBehavior, availableSize.Height, MinHeight, MaxHeight, maxHeightChildren, VerticalAlignment == VerticalAlignment.Stretch));
        }


        private double ComputeOneDimension(AdaptiveBehavior Behavior, double availableSize, double minSize, double maxSize, double maxWidthChildren, bool isStretch)
        {

            var computedWidth = 0d;

            switch (Behavior)
            {
                default:
                case AdaptiveBehavior.Standard:
                    {
                        if (!double.IsNaN(Width))
                            computedWidth = Width;
                        else if (isStretch)
                            computedWidth = Math.Min(availableSize, maxSize);
                        else
                        {
                            computedWidth = Math.Max(Math.Min(Math.Min(availableSize, maxWidthChildren), maxSize), minSize);
                        }
                    }
                    break;
                case AdaptiveBehavior.StretchToMaxSizeIfPossible:
                    {
                        computedWidth = Math.Max(Math.Min(availableSize, maxSize), minSize);
                    }
                    break;
                case AdaptiveBehavior.MinSizeOnlyIfAvailable:
                    {

                        if (!double.IsNaN(Width))
                            computedWidth = Width;
                        else if (isStretch)
                            computedWidth = Math.Min(availableSize, maxSize);
                        else
                        {
                            computedWidth = Math.Min(Math.Min(Math.Max(minSize, maxWidthChildren), maxSize), availableSize);
                        }

                    }
                    break;
            }
            return computedWidth;
        }


        #region MinWidth



        public double MinWidth
        {
            get { return (double)GetValue(MinWidthProperty); }
            set { SetValue(MinWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinWidthProperty =
            DependencyProperty.Register("MinWidth", typeof(double), typeof(AdaptivePanel), new PropertyMetadata(0d, MinWidthCallback));

        private static void MinWidthCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = (AdaptivePanel)d;
            owner.MinWidth = (double)e.NewValue;
            owner.InvalidateMeasure();
        }



        #endregion






        #region Horizontal Fill Behavior
        public AdaptiveBehavior HorizontalBehavior
        {
            get { return (AdaptiveBehavior)GetValue(HorizontalBehaviorProperty); }
            set { SetValue(HorizontalBehaviorProperty, value); }
        }

        public static readonly DependencyProperty HorizontalBehaviorProperty =
            DependencyProperty.Register("HorizontalBehavior", typeof(AdaptiveBehavior), typeof(AdaptivePanel), new PropertyMetadata(AdaptiveBehavior.Standard, HorizontalBehaviorCallback));

        private static void HorizontalBehaviorCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var own = (AdaptivePanel)d;
            own.InvalidateMeasure();
            own.InvalidateArrange();

        }

        #endregion
        #region Vertical Fill Behavior
        public AdaptiveBehavior VerticalBehavior
        {
            get { return (AdaptiveBehavior)GetValue(VerticalBehaviorProperty); }
            set { SetValue(VerticalBehaviorProperty, value); }
        }

        public static readonly DependencyProperty VerticalBehaviorProperty =
            DependencyProperty.Register("VerticalBehavior", typeof(AdaptiveBehavior), typeof(AdaptivePanel), new PropertyMetadata(AdaptiveBehavior.Standard, VerticalBehaviorCallback));

        private static void VerticalBehaviorCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var own = (AdaptivePanel)d;
            own.InvalidateMeasure();
            own.InvalidateArrange();

        }

        #endregion
    }
}
