using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace FibClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int lastHour, lastMinute;
        private FibonacciResolver resolver;
        private FibonacciClockHelper helper;

        private static ColorViewModel colorModel = new ColorViewModel();
        private static Dictionary<Color, SolidColorBrush> brushMap = new Dictionary<Color, SolidColorBrush> {
            { Colors.Blue, new SolidColorBrush(Colors.Blue) },
            { Colors.Red, new SolidColorBrush(Colors.Red) },
            { Colors.Green, new SolidColorBrush(Colors.Green) },
            { Colors.White, new SolidColorBrush(Colors.White) }
        };

        private Dictionary<int, Action<SolidColorBrush>> modelMap = new Dictionary<int, Action<SolidColorBrush>>{
                { 0, x => colorModel.ValueOneFirst = x },
                { 1, x => colorModel.ValueOneSecond = x },
                { 2, x => colorModel.ValueTwo = x },
                { 3, x => colorModel.ValueThree = x },
                { 5, x => colorModel.ValueFive = x },
               };

        public MainWindow()
        {
            
            InitializeComponent();
            this.DataContext = colorModel;
            resolver = new FibonacciResolver();
            helper = new FibonacciClockHelper(modelMap, brushMap);

            var timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += this._TimeHandler;

            timer.Start();
            //helper.SetTime(resolver.GetTileColors(11, 30));
        }

        private void _DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _TimeHandler(object sender, ElapsedEventArgs e)
        {
            var date = DateTime.Now;
            var hour = date.Hour % 12;
            var minute = date.Minute;

            if (hour != lastHour || minute / 5 != lastMinute)
            {
                Console.WriteLine("Setting time for " + hour + ":" + minute);
                var tileColor = resolver.GetTileColors(hour, minute);
                helper.SetTime(tileColor);

                lastHour = hour;    
                lastMinute = minute / 5;
            }
        }
    }
}
