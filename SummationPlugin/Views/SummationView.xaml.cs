using Plugin;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace SummationPlugin.Views
{
    /// <summary>
    /// SummationView.xaml の相互作用ロジック
    /// </summary>
    [Export(typeof(IPlugin))]
    public partial class SummationView : UserControl, IPlugin
    {
        public SummationView()
        {
            InitializeComponent();
        }
    }
}