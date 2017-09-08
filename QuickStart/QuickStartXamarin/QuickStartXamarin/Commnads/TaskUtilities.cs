using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuickStartXamarin
{
    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Func<Task> fnc, CancellationToken ct = default(CancellationToken)) 
        {
            try
            {
                var invoke = fnc?.Invoke();
                if (invoke != null)
                {
                    await Task.Run((async () => await invoke), ct);
                }
            }
            catch (Exception ex)
            {
                await HandleError(ex);
            }
        }
#pragma warning disable RECS0165
		public static async void FireAndForgetSafeTaskAsync(this Task task, CancellationToken ct = default(CancellationToken))
#pragma warning restore RECS0165
		{
			try
			{
                await Task.Run((async()=> await task),ct);
			}
			catch (Exception ex)
			{
				await HandleError(ex);
			}
		}

        public static async Task<T> ExecuteTaskSafeAsync<T>(this Task<T> task, CancellationToken ct = default(CancellationToken))
        {
            T result = default(T);
            try
            {
                result = await Task.Run((async () => await task), ct);
            }
            catch (Exception ex)
            {
                await HandleError(ex);
            }

            return result;
        }


        private static async Task HandleError(Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("УУУУУУПС", $"Кажется возникла ошибочка...{ex.Message}", "Okay");
        }
    }
}
