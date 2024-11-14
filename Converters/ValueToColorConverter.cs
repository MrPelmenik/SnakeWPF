using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_MVVM.Converters
{

    public class ValueToColorConverter : IValueConverter
    {
        #region Colors
        private static readonly SolidColorBrush tile1Brush = GetSolidColorBrush(120, 120, 120, 255); //Голова
        private static readonly SolidColorBrush tile2Brush = GetSolidColorBrush(240, 240, 240, 255); //Тело
        private static readonly SolidColorBrush tile3Brush = GetSolidColorBrush(250, 128, 114, 255); //Фрукт

        private static readonly SolidColorBrush tileEmptyBrush = GetSolidColorBrush(18, 18, 18, 255); //ПустоеПоле
        #endregion

        private static readonly Dictionary<string, Brush> tileBrushes = new()
        {
            { "1", tile1Brush }, //Голова
            { "2", tile2Brush }, //Тело
            { "3", tile3Brush }, //Фрукт
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (tileBrushes.TryGetValue(value as string, out Brush brush))
                return brush;
            else
                return tileEmptyBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static SolidColorBrush GetSolidColorBrush(byte r, byte g, byte b, byte a)
        {
            return new SolidColorBrush(GetColor(r, g, b, a));
        }

        private static Color GetColor(byte r, byte g, byte b, byte a)
        {
            return new Color { R = r, G = g, B = b, A = a };
        }
    }
}
