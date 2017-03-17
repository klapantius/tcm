using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllerManager.ViewModel
{
    public static class MainWindowViewModelFactory
    {
        public static IMainViewModel CreateMainViewModel(bool isPreviewMode)
        {
            if (isPreviewMode)
            {
                return new MainWindowViewModelPreview();
            }
            return new MainWindowViewModel();
        }
    }
}
