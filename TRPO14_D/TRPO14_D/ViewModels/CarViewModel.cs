using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TRPO14_D.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace TRPO14_D.ViewModels
{
    class CarViewModel
    {
        private Car _selectedCar;
        public ObservableCollection<Car> Cars { get; set; }
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set
            {
                _selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
              new Car { Model="ВАЗ-2105", Category="srtgeg", Discount = 0, Price=56000, Specific="Rewfwef" },
              new Car { Model="LADA Priora", Category="ergegeg", Discount = 0, Price=560000, Specific="ferfefwe"},
              new Car { Model="КамАЗ", Category="eagegeag", Discount = 50, Price=5600000, Specific="wefewfwf" },
              new Car { Model="LADA Priora", Category="ergegeg", Discount = 0, Price=560000, Specific="ferfefwe"}
            };
        }
        public void AddCar()
        {
            Car car = new Car();
            Cars.Insert(0, car);
            SelectedCar = car;
        }
        public void DeleteCar()
        {
            if (_selectedCar != null)
            {
                Cars.Remove(SelectedCar);
            }
        }

        public void CalcSaleGroup(string cat, int proc)
        {
            Cars.Where(c => c.Category == cat).ToList().ForEach(c => c.Discount = proc);
        }

        public void SavingJson()
        {
            string path = "cars.json";
            if (File.Exists(path)) 
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                string txt = JsonSerializer.Serialize(Cars, options);
                File.WriteAllText(path, txt);
            }
            else 
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };

                string txt = JsonSerializer.Serialize(Cars, options);
                File.WriteAllText(path, txt);
                File.Create(path);
            }

            MessageBox.Show("Данные сохранены в файл!");

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
