using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_5
{
    internal class Human:ICloneable
    {

        private string name;
        private int age;
        private DateTime birthday;
        public Car name_car;

        public Human(string name, int age, DateTime birthday, Car car)
        {
            Name = name;
            Age = age;
            Birthday = birthday;
            name_car = car;
        }


        public string Name
        {

            get { return name; }
            set
            {
                if (value != null)
                    name = value;
                else Console.WriteLine("Неверные данные");
            }

        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value != null)
                    birthday = value;
                else Console.WriteLine("Неверные данные");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value != null)
                    age = value;
                else Console.WriteLine("Неверные данные");
            }
        }

        public override string ToString()
        {
            return new string($"Имя: {Name}\nВозвраст: {Age}\nДень рождения: {Birthday}\nМашина: {name_car.Name}");
        }
        public object Clone() => new Human(name, age, birthday, new Car(name_car.Name));
        
    }
}
