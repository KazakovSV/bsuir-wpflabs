using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point oldMousePosition;
        
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            oldMousePosition = new Point(0, 0);
        }

        private void Grid_OnMouseMove(object sender, MouseEventArgs e)
        {
            var mouse = e.GetPosition(BoardCanvas);
            var button = new Point(
                Canvas.GetLeft(NoButton) + NoButton.Width / 2,
                Canvas.GetTop(NoButton) + NoButton.Height / 2);

            var speed = 2;

            var deltaX = button.X - mouse.X;
            var deltaY = button.Y - mouse.Y;

            if (Math.Abs(deltaX) < 100 && Math.Abs(deltaY) < 100)
            {
                if (deltaX >= 0)
                {
                    button.X += speed;
                }
                else
                {
                    button.X -= speed;
                }

                if (deltaY >= 0)
                {
                    button.Y += speed;
                }
                else
                {
                    button.Y -= speed;
                }
            }

            if (button.X - NoButton.Width / 2 < 0)
            {
                button.X = BoardCanvas.ActualWidth - NoButton.Width / 2;
            }

            if (button.X + NoButton.Width / 2 > BoardCanvas.ActualWidth)
            {
                button.X = NoButton.Width / 2;
            }

            if (button.Y - NoButton.Height / 2 < 0)
            {
                button.Y = BoardCanvas.ActualHeight - NoButton.Height / 2;
            }

            if (button.Y + NoButton.Height / 2 > BoardCanvas.ActualHeight)
            {
                button.Y = NoButton.Height / 2;
            }

            Canvas.SetLeft(NoButton, button.X - NoButton.Width / 2);
            Canvas.SetTop(NoButton, button.Y - NoButton.Height / 2);
        }

        private void YesButton_OnClick(object sender, RoutedEventArgs e)
        {
            string text = "Молодец! Так держать!";
            string caption = "Правильный ответ";

            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
