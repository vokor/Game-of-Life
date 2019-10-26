using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;


namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Emulator Emulator;
        
        private bool IsWorking;

        private const int WidthF = 980;

        private const int HeightF = 620;

        public MainWindow()
        {
            InitializeComponent();
            
            ITest test = new Sample2();
            Field field = new Field(HeightF, WidthF,test.GenerateTest(HeightF, WidthF));
            
            Emulator = new Emulator(field);
            
            foreach (var (_, pixel) in Emulator.Field.Pixels)
            {
                Background.Children.Add(pixel.Rectangle);
            }

            Generation.Text = (0).ToString();
            IsWorking = true;
        }

        private void UpdateBackPattern(object sender, SizeChangedEventArgs e)
        {
            //Background.Children.Clear(); 
            for (int x = 0; x < WidthF; x += Pixel.Size)
                AddLineToBackground(x, 0, x, HeightF);
            for (int y = 0; y < HeightF; y += Pixel.Size)
               AddLineToBackground(0, y, WidthF, y);
        }

        private void AddLineToBackground(double x1, double y1, double x2, double y2)
        {
            var line = new Line
            {
                X1 = x1, Y1 = y1,
                X2 = x2, Y2 = y2,
                Stroke = Brushes.Gray,
                SnapsToDevicePixels = true
            };
            line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            Background.Children.Add(line);
        }

        private void UpdatePixels()
        {
            foreach (var pixel in Emulator.GameStep.GetAddPixels())
            {
                Background.Children.Add(pixel.Rectangle);
            }

            foreach (var pixel in Emulator.GameStep.GetRemovePixels())
            {
                Background.Children.Remove(pixel.Rectangle);
            }
            Generation.Text = Emulator.CurrentStep.ToString();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Emulator.Execute())
            {
                UpdatePixels();
            }
        }
    }
}