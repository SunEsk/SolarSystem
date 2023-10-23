using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SolarSystem
{

    public partial class MainWindow : Window
    {
        // timeDispatcher
        private DispatcherTimer animationTimer;
        private Ellipse earth;
        private Ellipse mars;
        private double angle = 0.0;
        private double centerX, centerY, radius;

        public MainWindow()
        {
            InitializeComponent();

            // Create a Canvas and add it to the window
            Canvas canvas = new Canvas();
            this.Content = canvas;

            // Create the Sun
            Ellipse sun = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = new SolidColorBrush(Colors.Orange)
            };

            // Position the Sun in the center of the canvas

            Canvas.SetLeft(sun, 340);//(canvas.ActualWidth - sun.Width) / 2);
            Canvas.SetTop(sun, 155);//(canvas.ActualHeight - sun.Height) / 2);
            canvas.Children.Add(sun);

            // Create the Earth
            earth = new Ellipse
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Blue)
            };
            canvas.Children.Add(earth);

            // Create Mars
            mars = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = new SolidColorBrush(Colors.DarkRed)
            };
            canvas.Children.Add(mars);

            // Initialize the animation timer
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(16); // Update every 16 milliseconds
            animationTimer.Tick += Timer_Tick;
            animationTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Calculate the center of the canvas
            centerX = this.ActualWidth / 2;
            centerY = this.ActualHeight / 2;

            radius = this.ActualWidth / 7; // Adjust this value as needed

            angle += 2.0; // Increment the angle to make the circle spin faster/slower

            // Calculate the ellipse new position
            double x = centerX + radius * Math.Cos(angle * Math.PI / 180);
            double x2 = centerX + radius * Math.Cos(angle * Math.PI / 150);
            double y = centerY + radius * Math.Sin(angle * Math.PI / 180);
            double y2 = centerY + radius * Math.Sin(angle * Math.PI / 150);

            // Update the earths position
            Canvas.SetLeft(earth, x - earth.Width / 2);
            Canvas.SetTop(earth, y - earth.Height / 2);

            // Update mars position
            Canvas.SetLeft(mars, x2 - mars.Width / 2);
            Canvas.SetTop(mars, y2 - mars.Height / 2);
        }


    }

    /*
    //System threading
    public partial class MainWindow : Window
    {
    private System.Threading.Timer animationTimer;
    private Ellipse earth;
    private Ellipse mars;
    private double angle = 0.0;
    private double centerX, centerY, radius;

        public MainWindow()
        {
            InitializeComponent();

            // Create a Canvas and add it to the window
            Canvas canvas = new Canvas();
            this.Content = canvas;

            // Create the Sun
            Ellipse sun = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = new SolidColorBrush(Colors.Orange)
            };

            // Position the Sun in the center of the canvas
            Canvas.SetLeft(sun, 340);//(canvas.ActualWidth - sun.Width) / 2);
            Canvas.SetTop(sun, 155);//(canvas.ActualHeight - sun.Height) / 2);
            canvas.Children.Add(sun);

            // Create the Earth
            earth = new Ellipse
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Blue)
            };
             canvas.Children.Add(earth);

            //Create mars
            mars = new Ellipse
            {
            Width = 30,
            Height = 30,
            Fill = new SolidColorBrush(Colors.DarkRed)
            };
            canvas.Children.Add(mars);


            // Calculate the center of the canvas
            centerX = this.ActualWidth / 2;
            centerY = this.ActualHeight / 2;

            radius = this.ActualWidth / 7; // Adjust this value as needed

            // Initialize the animation timer
            animationTimer = new System.Threading.Timer(TimerCallback, null, 0, 16); // Update every 16 milliseconds
        }

        private void TimerCallback(object state)
        {
            // Calculate the circle's new position
            angle += 2.0; // Increment the angle to make the circle spin faster/slower

            // Calculate the circle's new position
            double x = centerX + radius * Math.Cos(angle * Math.PI / 180);
            double x2 = centerX + radius * Math.Cos(angle * Math.PI / 150);
            double y = centerY + radius * Math.Sin(angle * Math.PI / 180);
            double y2 = centerY + radius * Math.Sin(angle * Math.PI / 150);

            // Update the earths position on the UI thread
            Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(earth, x - earth.Width / 2);
                Canvas.SetTop(earth, y - earth.Height / 2);
            });
            // Update mars postion on the UI thread
        Dispatcher.Invoke(() =>
        {
            Canvas.SetRight(mars, x2 - mars.Width / 2);
            Canvas.SetBottom(mars, y2 - mars.Height / 2);
        });
        }
    }
    */
}
