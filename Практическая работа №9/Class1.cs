using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__9
{
    public struct MailSends
    {
        private string _town,
            _street,
            _recipient;

        private int _house,
            _apps,
            _count;

        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        public int House
        {
            get { return _house; }
            set
            {
                if (value > 0)
                {
                    _house = value;
                }
                else throw new ArgumentException("Номер дома не может быть отрицательным.");
            }
        }

        public int Apps
        {
            get { return _apps; }
            set
            {
                if (value >= 0)
                {
                    _apps = value;
                }
                else throw new ArgumentException("Номер квартиры не может быть отрицательным.");
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value >= 0)
                {
                    _count = value;
                }
                else throw new ArgumentException("Количество отправленных посылок не может быть меньше нуля");
            }
        }

        public MailSends()
        {
            _town = "Введите город";
            _street = "Введите улицу";
            _recipient = "Введите получателя";

            _house = 0;
            _apps = 0;
            _count = 0;
        }

        public MailSends(string town, string street, string recipient, int house, int apps, int count)
        {
            if (house <= 0 || apps <= 0 || count < 0)
            {
                throw new ArgumentException("Некорректные значения");
            }
            else
            {
                _town = town;
                _street = street;
                _recipient = recipient;

                _apps = apps;
                _count = count;
                _house = house;
            }
        }

        public static int GetResult(List<MailSends> list, string town)
        {
            int result = 0;

            foreach (MailSends i in list)
            {
                if (i.Town == town)
                {
                    result += i.Count;
                }
            }

            return result;
        }
    }
}
