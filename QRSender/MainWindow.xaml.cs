using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

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
            var qrcode = DecodeQRCode(screenshot);
            ResultText.Text = qrcode;
        }

        private string? DecodeQRCode(Bitmap bitmap)
        {
            var source = new BitmapLuminanceSource(bitmap);
            var binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));
            var reader = new QRCodeReader();
            var result = reader.decode(binaryBitmap);
            return result?.Text;
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

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.SelectAll();
                Clipboard.SetText(textBox.Text);
                MessageBox.Show("Text copied to clipboard.");
            }
        }
    }
}
