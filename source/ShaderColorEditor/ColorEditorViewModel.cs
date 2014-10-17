using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Kefir.ShaderColorEditor.Model;

namespace Kefir.ShaderColorEditor
{
    internal class ColorEditorViewModel : ModelBase
    {
        public ColorEditorViewModel()
        {
            _modes = CreateModes().ToArray();
            _selectedMode = Modes.First();
            _color.PropertyChanged += Color_PropertyChanged;
        }

        public ColorRgb Color
        {
            get { return _color; }
        }

        public IEnumerable<ColorEditorMode> Modes
        {
            get { return _modes; }
        }

        public double PickX
        {
            get { return _pickX; }
            set
            {
                _pickX = value;
                OnPropertyChanged();
                SelectedMode.UpdateColor();
            }
        }

        public double PickY
        {
            get { return _pickY; }
            set
            {
                _pickY = value;
                OnPropertyChanged();
                SelectedMode.UpdateColor();
            }
        }

        public double PickZ
        {
            get { return _pickZ; }
            set
            {
                _pickZ = value;
                OnPropertyChanged();
                SelectedMode.UpdateColor();
            }
        }

        public ColorEditorMode SelectedMode
        {
            get { return _selectedMode; }
            set
            {
                if (value == null) throw new ArgumentNullException();

                _selectedMode = value;
                OnPropertyChanged();
                _selectedMode.UpdateCoordinates();
            }
        }

        void Color_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SelectedMode.UpdateCoordinates();
        }

        private IEnumerable<ColorEditorMode> CreateModes()
        {
            yield return new ColorEditorMode("R", "rgb_gb", "rgb_r", () => UpdateColor(PickZ, PickX, PickY), () => UpdateCoordinates(Color.G, Color.B, Color.R));
            yield return new ColorEditorMode("G", "rgb_rb", "rgb_g", () => UpdateColor(PickX, PickZ, PickY), () => UpdateCoordinates(Color.R, Color.B, Color.G));
            yield return new ColorEditorMode("B", "rgb_rg", "rgb_b", () => UpdateColor(PickX, PickY, PickZ), () => UpdateCoordinates(Color.R, Color.G, Color.B));
        }

        private void UpdateColor(double r, double g, double b)
        {
            ExecuteNonReentrant(() =>
            {
                Color.R = r;
                Color.G = g;
                Color.B = b;
            });
        }

        private void UpdateCoordinates(double x, double y, double z)
        {
            ExecuteNonReentrant(() =>
            {
                PickX = x;
                PickY = y;
                PickZ = z;
            });
        }

        private readonly ColorRgb _color = new ColorRgb
        {
            A = 1,
            R = 1,
            G = 0.5,
            B = 0.1
        };

        private readonly ColorEditorMode[] _modes;
        private double _pickX;
        private double _pickY;
        private double _pickZ;
        private ColorEditorMode _selectedMode;
    }
}
