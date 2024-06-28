using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace QRSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Bitmap screenshot = CaptureScreen();
        }

        private Bitmap CaptureScreen()
        {
            var screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            var screenHeight = (int)SystemParameters.PrimaryScreenHeight;
            Bitmap screenshot = new Bitmap(screenWidth, screenHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using(Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(screenWidth, screenHeight), CopyPixelOperation.SourceCopy);
            }
            return screenshot;
        }
    }
}
