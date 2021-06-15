using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;


namespace TimerApp
{
    public class NumberView: INotifyPropertyChanged
    {
        public AbsoluteLayout stackLayout = new AbsoluteLayout();
        public Xamarin.Forms.Shapes.Rectangle[,,] squars = new Xamarin.Forms.Shapes.Rectangle[6, 4, 5];
        public NumberView()
        {
            int dX = 0, dY = 0;
            for (var k = 0; k < 6; k++)
            {
                for (var i = 0; i < 4; i++)
                {
                    dY = 100;
                    for (var j = 0; j < 5; j++)
                    {
                        var square = new Xamarin.Forms.Shapes.Rectangle();
                        if ((k == 2 || k == 4) && i == 0 && j == 0)
                        {
                            for (var j1 = 0; j1 < 5; j1++)
                            {
                                var square1 = new Xamarin.Forms.Shapes.Rectangle();
                                square1.TranslationX = dX;
                                square1.TranslationY = dY;
                                square1.WidthRequest = 10;
                                square1.HeightRequest = 10;
                                dY += 14;
                                stackLayout.Children.Add(square1);
                                if (j1 == 1 || j1 == 3)
                                    square1.Fill = Brush.Black;
                            }
                            dY = 100;
                            dX += 20;
                        }
                        square.TranslationX = dX;
                        square.TranslationY = dY;
                        square.WidthRequest = 12;
                        square.HeightRequest = 12;
                        square.HorizontalOptions = LayoutOptions.Start;
                        square.Fill = Brush.White;
                        dY += 14;
                        squars[k, i, j] = square;
                        stackLayout.Children.Add(square);
                    }
                    dX += 14;
                }
                dX += 5;
            }
            Device.StartTimer(TimeSpan.FromSeconds(1), ChangeNumbers);
        }
        void Clear(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (squars[k, i, j].Fill != Brush.White)
                        squars[k, i, j].Fill = Brush.White;
                }
        }
        public void ChangeNumber(int time, int k)
        {
            Clear(k);
            switch (time)
            {
                case 0:
                    NumberZero(k);
                    break;
                case 1:
                    NumberOne(k);
                    break;
                case 2:
                    NumberTwo(k);
                    break;
                case 3:
                    NumberThree(k);
                    break;
                case 4:
                    NumberFour(k);
                    break;
                case 5:
                    NumberFive(k);
                    break;
                case 6:
                    NumberSix(k);
                    break;
                case 7:
                    NumberSeven(k);
                    break;
                case 8:
                    NumberEight(k);
                    break;
                case 9:
                    NumberNine(k);
                    break;
            }
        }
        public bool ChangeNumbers()
        {
            var time = DateTime.Now;
            ChangeNumber(time.Hour / 10, 0);
            ChangeNumber(time.Hour % 10, 1);
            ChangeNumber(time.Minute / 10, 2);
            ChangeNumber(time.Minute % 10, 3);
            ChangeNumber(time.Second / 10, 4);
            ChangeNumber(time.Second % 10, 5);
            return true;
        }
        void NumberZero(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i == 0 && (j != 0 && j != 4))
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3 && (j != 0 && j != 4))
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i == 1 || i == 2) && (j == 0 || j == 4))
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberOne(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i == 1 && j == 1)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i == 1 || i == 3) && j == 4)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberTwo(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i != 0 && j == 0)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3 && (j == 1))
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i != 0) && j == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i == 1) && j == 3)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i != 0 && j == 4)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberThree(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i != 0 && j == 0)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3 && (j == 1 || j == 3))
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i != 0) && j == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i != 0 && j == 4)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberFour(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i == 1 && (j != 3 && j != 4))
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 2 && j == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberFive(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i != 0 && j == 0)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 1 && (j == 1))
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i != 0) && j == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i == 3) && j == 3)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i != 0 && j == 4)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberSix(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i != 0 && j == 0)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 1 && (j == 1 || j == 3))
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i != 0) && j == 2)
                        squars[k, i, j].Fill = Brush.Black;
                    if ((i == 3) && j == 3)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i != 0 && j == 4)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberSeven(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i != 0 && j == 0)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3 && j != 0)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberEight(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i == 1)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 2 && (j != 1 && j != 3))
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }
        void NumberNine(int k)
        {
            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 5; j++)
                {
                    if (i == 1 && j != 3)
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 2 && (j != 1 && j != 3))
                        squars[k, i, j].Fill = Brush.Black;
                    if (i == 3)
                        squars[k, i, j].Fill = Brush.Black;
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
