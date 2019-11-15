using ServerLogLibrary;
using System.Collections.ObjectModel;
using System.Windows;

namespace ServerLogViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IServerViewModel _serverLogViewModel { get; set; }

        private ObservableCollection<IServerDataItem> _data { get; set; } = new ObservableCollection<IServerDataItem>();

        public MainWindow()
        {
            InitializeComponent();

            _serverLogViewModel = new LogViewModel();

            dgServerLogModel.ItemsSource = _data;
        }

        private void LbInputFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void LbInputFile_DragOver(object sender, DragEventArgs e)
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

        private void LbInputFile_Drop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            lbStatus.Content = "loading...";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (_data.Count <= 0)
            {
                _serverLogViewModel.LoadLogFile("Filename");
            }

            foreach (var item in _serverLogViewModel.GetViewItems())
            {
                _data.Add(item);
            }

            lbStatus.Content = "processing...";
        }
    }
}
