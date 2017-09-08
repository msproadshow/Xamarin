using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuickStartXamarin
{
    public class AsyncCommand : ICommand
    {

		private bool _isExecuting;
		private readonly Func<Task> _execute;
		private readonly Func<bool> _canExecute;

		public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

        public event EventHandler CanExecuteChanged;

        public bool CanExecute()
		{
			return !_isExecuting && (_canExecute?.Invoke() ?? true);
		}

		public async Task ExecuteAsync()
		{
			if (CanExecute())
			{
				try
				{
					_isExecuting = true;
					await _execute();
				}
				finally
				{
					_isExecuting = false;
				}
			}
			RaiseCanExecuteChanged();
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parametr)
		{
			return CanExecute();
		}

		void ICommand.Execute(object parametr)
		{
            ExecuteAsync().FireAndForgetSafeTaskAsync(CancellationToken.None);
		}
    }

	public class SyncCommand : ICommand
	{

		private bool _isExecuting;
		private readonly Func<Task> _execute;
		private readonly Func<bool> _canExecute;

		public SyncCommand(Func<Task> execute, Func<bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute()
		{
			return !_isExecuting && (_canExecute?.Invoke() ?? true);
		}

		public Task Execute()
		{
            var result = default(Task);
			if (CanExecute())
			{
				try
				{
					_isExecuting = true;
                    result = _execute();
				}
				finally
				{
					_isExecuting = false;
				}
			}
			RaiseCanExecuteChanged();

            return result;
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parametr)
		{
			return CanExecute();
		}

		void ICommand.Execute(object parametr)
		{
			Execute().FireAndForgetSafeTaskAsync(CancellationToken.None);
		}
	}

	public class SyncCommand<T> : ICommand
	{

		private bool _isExecuting;
        private readonly Action<T> _execute;
		private readonly Func<T, bool> _canExecute;

		public SyncCommand(Action<T> execute, Func<T, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(T parametr)
		{
            return !_isExecuting && (_canExecute?.Invoke(parametr) ?? true);
		}

        public void Execute(T parametr)
		{
            if (CanExecute(parametr))
			{
				try
				{
					_isExecuting = true;
                    _execute.Invoke(parametr);
				}
				finally
				{
					_isExecuting = false;
				}
			}
			RaiseCanExecuteChanged();
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parametr)
		{
            return CanExecute((T)parametr);
		}

		void ICommand.Execute(object parametr)
		{
            Execute((T)parametr);
		}
	}
}
