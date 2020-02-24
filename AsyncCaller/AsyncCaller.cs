using System;
using System.Threading;

namespace AsyncCaller
{
    public class AsyncCaller
    {
        /// <summary>
        /// Хранитель переданного делегата
        /// </summary>
        private readonly EventHandler h;

        /// <summary>
        /// Хранитель хендла, выданного BeginInvoke
        /// </summary>
        public IAsyncResult asyncResult { get; private set;  }

        /// <summary>
        /// Конструктор по умолчанию выключен
        /// </summary>
        private AsyncCaller() { }

        /// <summary>
        /// Параметризованный конструктор
        /// </summary>
        /// <param name="h">Делегат, который нужно вызвать "полусинхронно"</param>
        AsyncCaller(EventHandler h)
        {
            // Запомним ссылку на переданный делегат
            this.h = h;
        }

        /// <summary>
        /// Вызов переданного конструктору делегата с ожиданием его завершения waitForMillis мс. Если выполнение делегата займет больше waitForMillis мс, то метод вернет управление.
        /// Независимо от выбранного варианта обработки завершения вызова делегата необходимо всегда использовать метод EndInvoke.
        /// </summary>
        /// <param name="millisecondsTimeout">Время ожидания в миллисекундах</param>
        /// <param name="sender">Первый параметр для BeginInvoke</param>
        /// <param name="e">Второй параметр для BeginInvoke</param>
        /// <param name="callback">Третий параметр для BeginInvoke</param>
        /// <param name="object">Четвертый параметр для BeginInvoke</param>
        /// <returns>Признак завершения асинхронного вызова</returns>
#nullable enable
        public bool Invoke(int millisecondsTimeout, object? sender, EventArgs e, AsyncCallback callback, object @object)
#nullable disable
        {
            // Проверим переданный аргумент
            if (millisecondsTimeout < 0 && millisecondsTimeout != Timeout.Infinite)
                throw new ArgumentOutOfRangeException("waitForMillis");
            // Запустим асинхронное выполнение
            asyncResult = h.BeginInvoke(sender, e, callback, @object);
            // Синхронно подождем 
            asyncResult.AsyncWaitHandle.WaitOne(millisecondsTimeout);
            // Вернем признак завершения
            return asyncResult.IsCompleted;
        }

        /// <summary>
        /// Реализует EndInvoke для удобства вызова клиентом
        /// </summary>
        public void EndInvoke()
        {
            h.EndInvoke(asyncResult);
            asyncResult.AsyncWaitHandle.Close();
        }
    }
}
