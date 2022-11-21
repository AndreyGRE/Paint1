using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ver2
{
  
    public partial class MainWindow : Window
    {
        enum DrawMode
        {
            PEN,
            LINE,
            ELLIPSE,
            pr

        }
        DrawMode mode;

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.PEN;
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.LINE;
        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.ELLIPSE;
        }
        private void btt4_Click_1(object sender, RoutedEventArgs e)
        {
            mode = DrawMode.pr;
        }


        Point startPoint;
        Line line;
        Ellipse ellipse;
        Rectangle Rectangle;
        Color color;
        Color fillColor;



        private void canvas_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
         
            startPoint = e.GetPosition(canvas);
         
            switch (mode)
            {
                case DrawMode.PEN:
                    startPoint = e.GetPosition(canvas);
                    break;
                case DrawMode.LINE:
                    line = new Line();
                    line.Stroke = new SolidColorBrush(color);
                    line.X1 = startPoint.X;
                    line.X2 = startPoint.X;
                    line.Y1 = startPoint.Y;
                    line.Y2 = startPoint.Y;
                    canvas.Children.Add(line);
                    break;
                case DrawMode.ELLIPSE:
                    ellipse = new Ellipse();
                    ellipse.Stroke = new SolidColorBrush(color);
                    canvas.Children.Add(ellipse);
                    Canvas.SetTop(ellipse, startPoint.Y);
                    Canvas.SetLeft(ellipse, startPoint.X);
                    ellipse.Width = 0;
                    ellipse.Height = 0;
                    break;
                case DrawMode.pr:
                    Rectangle = new Rectangle();
                    Rectangle.Stroke = new SolidColorBrush(color);
                    canvas.Children.Add(Rectangle);
                    Canvas.SetTop(Rectangle, startPoint.Y);
                    Canvas.SetLeft(Rectangle, startPoint.X);
                    Rectangle.Width = 0;
                    Rectangle.Height = 0;
                    break;

            }

        }

        private void canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            //обрабатываем движения мыши только если нажата левая кнопка
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                switch (mode)
                {
                    case DrawMode.PEN:
                        var currentPoint = e.GetPosition(canvas);
                        line = new Line();
                        line.Stroke = new SolidColorBrush(color);
                        line.X1 = startPoint.X;
                        line.Y1 = startPoint.Y;
                        line.X2 = currentPoint.X;
                        line.Y2 = currentPoint.Y;
                        canvas.Children.Add(line);
                        startPoint = currentPoint; 
                        break;
                    case DrawMode.LINE:
                        //обновляем координаты второго конца отрезка
                        line.X2 = e.GetPosition(canvas).X;
                        line.Y2 = e.GetPosition(canvas).Y;
                        break;
                    case DrawMode.ELLIPSE:
                        Point curPoint = e.GetPosition(canvas);
                        double width = curPoint.X - startPoint.X;
                        double height = curPoint.Y - startPoint.Y;

                        if (width < 0)
                        {
                            width = -width;
                            Canvas.SetLeft(ellipse, curPoint.X);
                        }
                        if (height < 0)
                        {
                            height = -height;
                            Canvas.SetTop(ellipse, curPoint.Y);
                        }
                        ellipse.Width = width;
                        ellipse.Height = height;
                        break;
                    case DrawMode.pr:
                        Point curPoint1 = e.GetPosition(canvas);
                        double width1 = curPoint1.X - startPoint.X;
                        double height1 = curPoint1.Y - startPoint.Y;

                        if (width1 < 0)
                        {
                            width1 = -width1;
                            Canvas.SetLeft(Rectangle, curPoint1.X);
                        }
                        if (height1 < 0)
                        {
                            height1 = -height1;
                            Canvas.SetTop(Rectangle, curPoint1.Y);
                        }
                        Rectangle.Width = width1;
                        Rectangle.Height = height1;
                        break;

                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            mode = DrawMode.LINE;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                color = ((SolidColorBrush)((Label)sender).Background).Color;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                fillColor = ((SolidColorBrush)((Label)sender).Background).Color;
            }
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                color = ((SolidColorBrush)((Label)sender).Background).Color;
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                fillColor = ((SolidColorBrush)((Label)sender).Background).Color;
            }
        }

        
    }

}