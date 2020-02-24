using System;
using System.Threading;

namespace StaticClassServer
{
    /// <summary>
    /// Класс "Сервер" из условия задачи
    /// </summary>
    public static class Server
    {
        /// <summary>
        /// Счетчик из условия задачи
        /// </summary>
        private static int count = 0;
        
        /// <summary>
        /// Объект для синхронизации потоков
        /// </summary>
        private static readonly ReaderWriterLockSlim syncObj = new ReaderWriterLockSlim();

        /// <summary>
        /// Метод "Сервера" для чтения из count
        /// </summary>
        /// <returns>Значение count</returns>
        public static int GetCount()
        {
            // Хранитель результата считывания
            int result;
            // Получим блокировку чтения
            syncObj.EnterReadLock();
            try
            {
                // Считаем count
                result = count;
            }
            finally
            {
                // Отпустим блокировку чтения
                syncObj.ExitReadLock();
            }
            // Вернем считанное значение
            return result;
        }

        /// <summary>
        /// Метод "Сервера" для записи в count
        /// </summary>
        /// <param name="value">Число, которое нужно прибавить к count</param>
        public static void AddToCount(int value)
        {
            // Получим блокировку записи
            syncObj.EnterWriteLock();
            try
            {
                // Прибавим значение
                count += value;
            }
            finally
            {
                // Отпустим блокировку записи
                syncObj.ExitWriteLock();
            }
        }

    }
}
