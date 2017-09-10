using System;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuickStartXamarin.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private object _parameter;

        public event PropertyChangedEventHandler PropertyChanged;

        public object Parametr => _parameter;
        private int _busyCounter;

       public ViewModelBase()
        {

        }

		public void Start(object parameter = null)
        {
			if (IsBusy)
				return;

            _parameter = parameter;
			
		}

		protected void IncrementBusyCounter()
		{
			Interlocked.Increment(ref _busyCounter);
			RaisePropertyChanged(nameof(BusyCounter));
			RaisePropertyChanged(nameof(IsBusy));
		}

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(property)));
        }

        protected void DecrementBusyCounter()
		{
			Interlocked.Decrement(ref _busyCounter);
			// ReSharper disable ExplicitCallerInfoArgument
			RaisePropertyChanged(nameof(BusyCounter));
			RaisePropertyChanged(nameof(IsBusy));
		}

		public int BusyCounter => _busyCounter;
		public bool IsBusy => _busyCounter != 0;

		public virtual bool DefaultCanExecute()
		{
			return !IsBusy;
		}

		public virtual bool DefaultCanExecute<T>(T parameter)
		{
			return DefaultCanExecute();
		}
    }
}
