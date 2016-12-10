using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonesVianaGoncalves
{
    public class CwiTestDate
    {
        private int day;
        private int month;
        private int year;
        private int hour;
        private int minutes;

        public string ChangeDate(string Date, char op, long value)
        {
            try
            {
                TransformStringDateIntoIntParameters(Date);
            }
            catch
            {
                return "Data enviada em formato inválido!";
            }

            if (value < 0) value *= -1;

            switch (op)
            {
                case '-':
                    DecreaseTime(value);
                    break;
                case '+':
                    IncreaseTime(value);
                    break;
                default:
                    return "Operador Inválido!";
            }

            if (hour == 24) hour = 0;

            return string.Format("{0:00}/{1:00}/{2:0000} {3:00}:{4:00}", day, month, year, hour, minutes);
        }

        private void TransformStringDateIntoIntParameters(string Date)
        {
            var _dateTime = Date.Split(' ');
            if (_dateTime.Count() == 2)
            {
                var _date = _dateTime[0].Split('/');
                if (_date.Count() == 3)
                {
                    try
                    {
                        day = Convert.ToInt32(_date[0]);
                        month = Convert.ToInt32(_date[1]);
                        year = Convert.ToInt32(_date[2]);
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }

                var _time = _dateTime[1].Split(':');
                if (_time.Count() == 2)
                {
                    try
                    {
                        hour = Convert.ToInt32(_time[0]);
                        minutes = Convert.ToInt32(_time[1]);
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        private void IncreaseTime(long value)
        {
            value += minutes;

            int _hoursFromValue = (int)(value / 60);
            minutes = (int)(value % 60);

            int _daysFromValue = _hoursFromValue / 24;
            _hoursFromValue = _hoursFromValue % 24;

            hour += _hoursFromValue;
            if (hour > 24)
            {
                _daysFromValue++;
                hour -= 24;
            }

            SetMonthIncreasing(_daysFromValue);
        }

        private void SetMonthIncreasing(int daysFromValue)
        {
            daysFromValue += day;
            bool endWhile = false;
            while(!endWhile)
            {
                if(month == 2 && daysFromValue < 29)
                {
                    day = daysFromValue;
                    endWhile = true;
                }
                else if(month % 2 == 0 && month != 8 && month != 2 && daysFromValue < 31)
                {
                    day = daysFromValue;
                    endWhile = true;
                }else if((month == 8 || month % 2 != 0) && daysFromValue < 32)
                {
                    day = daysFromValue;
                    endWhile = true;
                }else
                {
                    if (month == 2)
                    {
                        daysFromValue -= 28;                        
                    }
                    else if (month % 2 == 0 && month != 8 && month != 2)
                    {
                        daysFromValue -= 30;                        
                    }
                    else if (month == 8 || month % 2 != 0)
                    {
                        daysFromValue -= 31;
                    }                    
                    month++;
                    if(month > 12)
                    {
                        month = 1;
                        year++;
                    }
                }                
            }
        }

        private void DecreaseTime(long value)
        {
            value -= minutes;

            minutes = 0;

            int _hoursFromValue = (int)(value / 60);
            minutes = (int)(value % 60);

            int _daysFromValue = _hoursFromValue / 24;
            _hoursFromValue = _hoursFromValue % 24;

            hour -= _hoursFromValue;
            if (hour < 0)
            {
                _daysFromValue++;
                hour = 24 + hour;
            }
            SetMonthDecreasing(_daysFromValue);
        }

        private void SetMonthDecreasing(int daysFromValue)
        {   
            bool endWhile = false;

            if (day > daysFromValue)
            {
                day -= daysFromValue;
                daysFromValue = 0;
                endWhile = true;
            }
            else
            {
                daysFromValue -= day;
                day = 0;
                month--;
            }

            while (!endWhile)
            {
                 if (month == 2 && daysFromValue < 29)
                {
                    endWhile = true;
                    day = 29 - daysFromValue;
                }else if(month % 2 == 0 && month != 8 && month != 2 && daysFromValue < 31)
                {
                    endWhile = true;
                    day = 31 - daysFromValue;
                }else if((month == 8 || month % 2 != 0) && daysFromValue < 32)
                {
                    endWhile = true;
                    day = 32 - daysFromValue;
                }
                else {
                    if (month == 2 && daysFromValue > 28)
                    {
                        month--;
                        daysFromValue -= 28;
                    } else if (month % 2 == 0 && month != 8 && month != 2 && daysFromValue > 30)
                    {
                        month--;
                        daysFromValue -= 30;
                    } else if ((month == 8 || month % 2 != 0) && daysFromValue > 31)
                    {
                        month--;
                        daysFromValue -= 31;
                    }
                    if (month < 1)
                    {
                        month = 12;
                        year--;
                    }
                }
            }
        }
    }
}
