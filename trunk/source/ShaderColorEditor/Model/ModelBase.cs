using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kefir.ShaderColorEditor.Annotations;

namespace Kefir.ShaderColorEditor.Model
{
    public class ModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void ExecuteNonReentrant(Action action)
        {
            if (_isUpdating)
            {
                return;
            }

            _isUpdating = true;
            try
            {
                action();
            }
            finally
            {
                _isUpdating = false;
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isUpdating;
    }
}