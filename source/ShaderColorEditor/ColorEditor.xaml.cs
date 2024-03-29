﻿namespace Kefir.ShaderColorEditor
{
    /// <summary>
    /// Interaction logic for ColorEditor.xaml
    /// </summary>
    public partial class ColorEditor
    {
        public ColorEditor()
        {
            InitializeComponent();
            RootGrid.DataContext = _viewModel = new ColorEditorViewModel();
        }

        private readonly ColorEditorViewModel _viewModel;
    }
}
