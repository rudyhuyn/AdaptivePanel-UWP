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


namespace AdaptivePanel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MinimumWidthSlider.ValueChanged += MinimumWidthSlider_ValueChanged;
            MaximumWidthSlider.ValueChanged += MaximumWidthSlider_ValueChanged;

            MinimumHeightSlider.ValueChanged += MinimumHeightSlider_ValueChanged;
            MaximumHeightSlider.ValueChanged += MaximumHeightSlider_ValueChanged;

        }




        #region Horizontal
        private void RadioHorizontalBehavior_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = ((RadioButton)sender);
            AdaptivePanel.HorizontalBehavior = (Huyn.AdaptiveBehavior)Enum.Parse(typeof(Huyn.AdaptiveBehavior), (string)radioButton.Tag);

        }


        private void HorizontalAlignmentRadio_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = ((RadioButton)sender);
            AdaptivePanel.HorizontalAlignment = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), (string)radioButton.Tag);
        }

        private void MinimumWidthCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.IsChecked.Value)
            {
                MinimumWidthSlider.Visibility = Visibility.Visible;
                AdaptivePanel.MinWidth = MinimumWidthSlider.Value;
            }
            else
            {
                MinimumWidthSlider.Visibility = Visibility.Collapsed;
                AdaptivePanel.MinWidth = 0;
            }
        }

        private void MinimumWidthSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            AdaptivePanel.MinWidth = e.NewValue;
        }


        private void MaximumWidthCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.IsChecked.Value)
            {
                MaximumWidthSlider.Visibility = Visibility.Visible;
                AdaptivePanel.MaxWidth = MaximumWidthSlider.Value;

            }
            else
            {
                MaximumWidthSlider.Visibility = Visibility.Collapsed;
                AdaptivePanel.MaxWidth = double.PositiveInfinity;
            }
        }

        private void MaximumWidthSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            AdaptivePanel.MaxWidth = e.NewValue;
        }

        #endregion


        #region Vertical

        private void RadioVerticalBehavior_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = ((RadioButton)sender);
            AdaptivePanel.VerticalBehavior = (Huyn.AdaptiveBehavior)Enum.Parse(typeof(Huyn.AdaptiveBehavior), (string)radioButton.Tag);

        }

        private void VerticalAlignmentRadio_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = ((RadioButton)sender);
            AdaptivePanel.VerticalAlignment = (VerticalAlignment)Enum.Parse(typeof(VerticalAlignment), (string)radioButton.Tag);
        }

        private void MinimumHeightCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.IsChecked.Value)
            {
                MinimumHeightSlider.Visibility = Visibility.Visible;
                AdaptivePanel.MinHeight = MinimumHeightSlider.Value;
            }
            else
            {
                MinimumHeightSlider.Visibility = Visibility.Collapsed;
                AdaptivePanel.MinHeight = 0;
            }
        }

        private void MinimumHeightSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            AdaptivePanel.MinHeight = e.NewValue;
        }


        private void MaximumHeightCheckbox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.IsChecked.Value)
            {
                MaximumHeightSlider.Visibility = Visibility.Visible;
                AdaptivePanel.MaxHeight = MaximumHeightSlider.Value;

            }
            else
            {
                MaximumHeightSlider.Visibility = Visibility.Collapsed;
                AdaptivePanel.MaxHeight = double.PositiveInfinity;
            }
        }

        private void MaximumHeightSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            AdaptivePanel.MaxHeight = e.NewValue;
        }

        #endregion

   
    }
}
