using System;
using System.Windows.Input;
namespace QuickStartXamarin
{
    public class ReverseCommand : ICommand
    {
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;
        public event EventHandler Executed;

        public event EventHandler CanExecuteChanged;

        public ReverseCommand(Action execute = null, Func<bool> canExecute = null)
        {
			_execute = execute;
			_canExecute = canExecute;
        }

		public bool CanExecute()
		{
			return _canExecute?.Invoke() ?? true;
		}

		public void Execute()
		{
			if (CanExecute())
			{
				RaiseExecuted();
				_execute?.Invoke();
			}
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		private void RaiseExecuted()
		{
			Executed?.Invoke(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute();
		}

		void ICommand.Execute(object parameter)
		{
			Execute();
		}
    }

	public class ReverseCommand<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Func<T, bool> _canExecute;
		public event EventHandler<T> Executed;

		public event EventHandler CanExecuteChanged;

		public ReverseCommand(Action<T> execute = null, Func<T, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(T parameter)
		{
			return _canExecute?.Invoke(parameter) ?? true;
		}

		public void Execute(T parameter)
		{
			if (CanExecute(parameter))
			{
				RaiseExecuted(parameter);
				_execute?.Invoke(parameter);
			}
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		private void RaiseExecuted(T parameter)
		{
			Executed?.Invoke(this, parameter);
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute((T)parameter);
		}

		void ICommand.Execute(object parameter)
		{
			Execute((T)parameter);
		}
	}
}
