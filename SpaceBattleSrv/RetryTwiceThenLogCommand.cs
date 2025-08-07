using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattleSrv
{
    public class RetryTwiceThenLogCommand : ICommand
    {
        private readonly ICommand _originalCommand;
        private int _attempts;

        /// <summary>
        /// Оригинальная команда для выполнения
        /// </summary>
        public ICommand OriginalCommand => _originalCommand;

        /// <summary>
        /// Количество выполненных попыток
        /// </summary>
        public int Attempts => _attempts;

        public RetryTwiceThenLogCommand(ICommand originalCommand, int attempts = 0)
        {
            _originalCommand = originalCommand ?? throw new ArgumentNullException(nameof(originalCommand));
            _attempts = attempts;
        }

        /// <summary>
        /// Выполняет команду с обработкой ошибок
        /// </summary>
        public void Execute()
        {
            try
            {
                // Пытаемся выполнить оригинальную команду
                _originalCommand.Execute();
            }
            catch (Exception ex)
            {
                // Увеличиваем счетчик попыток
                _attempts++;

                if (_attempts < 2)
                {
                    // Если попыток меньше 2 - пробуем еще раз
                    Execute(); // Рекурсивный вызов
                }
                else
                {
                    // После двух неудачных попыток логируем ошибку
                    var logCommand = new LogExceptionCommand(ex, _originalCommand);
                    logCommand.Execute();
                }
            }
        }
    }
}
