using System;

namespace lab_rob_5
{
    static class Validator
    {
        /// <summary>
        /// перевіряє ім'я / прізвище на валідність
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Name(string name, out string Error)
        {
            if (name.Length > 100 || name.Length < 2)
            {
                Error = "Ім'я та прізвище повинні бути довшими за 2 символи та коротшим за - 100. ";
                return false;
                
            }

            foreach (char ch in name)
            {
                if (!char.IsLetter(ch))
                {
                    Error = "Ім'я та прізвище не можуть містити симолів, що не є літерами.  ";
                    return false;
                }
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє номер телефону на валідність
        /// </summary>
        /// <param name="number"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Phone_Number(string number, out string Error)
        {
            if (number.Length != 12)
            {
                Error = "Номер телефону повинен містити 12 символів. ";
                return false;
            }

            if (!number.StartsWith("380"))
            {
                Error = "Номер телефону повинен починатися з 380. ";
                return false;
            }

            foreach (char ch in number)
            {
                if (!char.IsDigit(ch))
                {
                    Error = "Номер телефону може містити тільки цифри. ";
                    return false;
                }
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє адресу алектронної пошти на валідність
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Email(string email, out string Error)
        {
            if (!email.EndsWith("@gmail.com"))
            {
                Error = "Адреса електронної пошти повинна містити наступний домен : @gmail.com. ";
                return false;
            }

            if (email.Length < 18 || email.Length > 50)
            {
                Error = "Адреса електронної пошти повинна бути довшою 8 символів та коротшою - 50. ";
                return false;
            }

            if (!char.IsLetter(email[0]))
            {
                Error = "Адреса електронної не може розпочинатися не з літери. ";
                return false;
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє вік на валідність
        /// </summary>
        /// <param name="age"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Age(string age, out string Error)
        {
            bool correctly;
            int Age;

            correctly = int.TryParse(age, out Age);

            if (!correctly || age.Length == 0)
            {
                Error = "В поле <вік> передано невалідне значення. ";
                return false;
            }

            if (correctly)
            {
                if (Age < 18 || Age > 100)
                {
                    Error = "Вік не може бути меншим за 18 років чи більшим за - 100. ";
                    return false;
                }
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє тему модуля чи тренінгу на валідність
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Topic(string name, out string Error)
        {
            if (name.Length < 10 || name.Length > 100)
            {
                Error = "Заголовки модулів та тренінгів повинні бути довшими за 10 символів та коротшими за - 100. ";
                return false;
            }

            Error = "";
            return true;

        }

        /// <summary>
        /// перевіряє дату початку та кінця на валідність
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Date(DateTime start, DateTime finish, out string Error)
        {
            if (start <= DateTime.Now)
            {
                Error = "Подія не може відбутися раніше сьогоднішньої дати чи відповідати сьогоднішній даті.";
                return false;
            }
            if (start > finish)
            {
                Error = "Дата початку не може відбувати пізніше дати закінчення. ";
                return false;
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє окрему дату на валідність
        /// </summary>
        /// <param name="start"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є</returns>
        static public bool Check_Date(DateTime start, out string Error)
        {
            if (start <= DateTime.Now)
            {
                Error = "Подія не може відбутися раніше сьогоднішньої дати чи відповідати сьогоднішній даті.";
                return false;
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє тривалість на валідність
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Duration(string duration, out string Error)
        {
            bool correctly;
            int Duration;

            correctly = int.TryParse(duration, out Duration);

            if (!correctly || duration.Length == 0)
            {
                Error = "В поле <тривалість> передано невалідне значення. ";
                return false;
            }

            if (correctly)
            {
                if (Duration < 1 || Duration > 48)
                {
                    Error = "Мінімальна тривалість модуля - 1 година, максимальна - 48. ";
                    return false;
                }
            }

            Error = "";
            return true;
        }

        /// <summary>
        /// перевіряє результат тесту на валідність
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Error"></param>
        /// <returns> повертає допустимість результату та текст помилки, якщо вона є </returns>
        static public bool Check_Result(string result, out string Error)
        {
            bool correctly;
            int Result;

            correctly = int.TryParse(result, out Result);

            if (!correctly || result.Length == 0)
            {
                Error = "В поле <результат> передано невалідне значення. ";
                return false;
            }

            if (Result > 100 || Result < 0)
            {
                Error = "Результат повинен бути більшим 0 та меншим 100. ";
                return false;
            }

            Error = "";
            return true;
        }
    }
}
