using System.Windows;
using System.Windows.Controls;

namespace ServerLogViewer
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

        private void lbInputFile_DragEnter(object sender, DragEventArgs e)
        {
            status.Content = "Drag";
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void lbInputFile_DragOver(object sender, DragEventArgs e)
        {
            //Check if the dragged file has the 'txt extension'
            bool dropEnabled = true;
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                dropEnabled = System.IO.Path.GetExtension(filenames[0]).ToUpperInvariant().Equals(".TXT"); 
            }

            if (!dropEnabled)
            {
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void lbInputFile_Drop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            status.Content = "Drop";
        }

    }
}
