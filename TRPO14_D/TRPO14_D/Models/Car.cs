using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TRPO14_D.Models
{
    public class Car : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string _model;
        private string _category;
        private decimal _price;
        private string _specific;
        private double _discount;

        public static string categoriesstring = "";
        int i = 0;
        string cates = "";

        public double Discount 
        {
            get 
            {
               return _discount; 
            }
            set 
            {
                _discount = value;
                OnPropertyChanged("HasDiscount");
                OnPropertyChanged("FinalPrice");
            } 
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                
                cates += value + " ";
                categoriesstring += cates;
                
                OnPropertyChanged("Category");
                OnPropertyChanged("Mass");
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("FinalPrice");
            }
        }
        public string Specific
        {
            get
            {
                return _specific;
            }
            set
            {
                _specific = value;
                OnPropertyChanged("Specific");
            }
        }

        public bool HasDiscount
        {
            get
            {
                return Discount > 0;
            }
          
        }

        public decimal FinalPrice
        {
            get
            {
                return Price - (Price * (decimal)(1 * Discount/100));
            }
        }

        
    }
}
