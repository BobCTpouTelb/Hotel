using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hotel.AppData
{
    /// <summary>
    /// Предоставляет методы для создания ссобщений обратной связи с пользователем.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Генерирует сообщение с ошибкой
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        /// <param name="title">Заголовок ошибки</param>
        public static void Error(string text, string title = "Ошибка")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Генерирует сообщение с предупреждением
        /// </summary>
        /// <param name="text">Текст предупреждения</param>
        /// <param name="title">Заголовок предупреждения</param>
        public static void Warning(string text, string title = "Предупреждение")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// Генерирует сообщение с информацией
        /// </summary>
        /// <param name="text">Текст информационного сообщения</param>
        /// <param name="title">Заголовок информационного сообщения</param>
        public static void Info(string text, string title = "Информация")
        {
            MessageBox.Show(text, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}
