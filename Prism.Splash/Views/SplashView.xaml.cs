using Splash.ViewModels;

namespace Splash.Views
{
    /// <summary>
    /// SplashView.xaml
    /// </summary>
    public partial class SplashView
    {
        public SplashView(SplashViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
