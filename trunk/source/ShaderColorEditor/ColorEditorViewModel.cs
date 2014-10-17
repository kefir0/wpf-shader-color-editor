using System.Collections.Generic;
using System.Linq;
using Kefir.ShaderColorEditor.Model;

namespace Kefir.ShaderColorEditor
{
    internal class ColorEditorViewModel : ModelBase
    {
        public ColorRgb Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<ColorEditorMode> Modes
        {
            get { return _modes; }
        }

        public ColorEditorMode SelectedMode
        {
            get { return _selectedMode; }
            set
            {
                _selectedMode = value;
                OnPropertyChanged();
            }
        }

        public double PickX { get; set; }
        public double PickY { get; set; }


        private readonly ColorEditorMode[] _modes = ColorEditorMode.GetAllModes().ToArray();
        private ColorRgb _color = new ColorRgb();
        private ColorEditorMode _selectedMode;
    }
}
