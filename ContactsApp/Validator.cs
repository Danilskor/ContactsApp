﻿using System;

namespace ContactsApp
{
    /// <summary>
    /// Проверка данных на валидность
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Проверяет на наличие введенного текста, а так же
        /// на длину, которая должна быть не более 50 символов.
        /// </summary>
        /// <param name="text">Вводимая строкаю.</param>
        /// <param name="length">Максимальная длина строки.</param>
        public static void AssertText(string text, int length, string field)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Вы ввели пустую строку.");
            }

            if (text.Length > length)
            {
                throw new ArgumentException($"Длина {field} должна быть меньше " +
                                            $"{length} символов.");
            }
        }
        /// <summary>
        /// Первый символ преобразует в верхний регистр, остальные в нижний.
        /// </summary>
        /// <param name="text">Вводимая строка.</param>
        /// <returns></returns>
        public static string ToNameFormat(string text)
        {
            text.ToLower();
            text = char.ToUpper(text[0]) + text.Substring(1);
            return text;
        }

    }
}