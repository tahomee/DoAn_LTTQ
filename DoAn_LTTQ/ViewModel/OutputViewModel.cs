using DoAn_LTTQ.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace DoAn_LTTQ.ViewModel
{
    public class OutputViewModel : BaseViewModel
    {
        private ObservableCollection<OUTPUT_INFOR> _List;
        public ObservableCollection<OUTPUT_INFOR> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private OUTPUT_INFOR _SelectedItem;
        public OUTPUT_INFOR SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    AMOUNT = SelectedItem.AMOUNT_MONEY;
                    TYPE = SelectedItem.TYPE_OUTPUT;
                    PAY = SelectedItem.PAY;
                    DATE_OUTPUT = SelectedItem.OUTPUT.DATE_OUTPUT;
                }
            }
        }

        private double? _Amount;
        public double? AMOUNT { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }


        private DateTime? _Date_OUTPUT;
        public DateTime? DATE_OUTPUT { get => _Date_OUTPUT; set { _Date_OUTPUT = value; OnPropertyChanged(); } }
        private string _TYPE;
        public string TYPE { get => _TYPE; set { _TYPE = value; OnPropertyChanged(); } }


        private string _PAY;
        public string PAY { get => _PAY; set { _PAY = value; OnPropertyChanged(); } }




        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public OutputViewModel()
        {
            List = new ObservableCollection<OUTPUT_INFOR>(DataProvider.Ins.DB.OUTPUT_INFOR);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var OUTPUT_INFOR = new OUTPUT_INFOR() { AMOUNT_MONEY = AMOUNT, TYPE_OUTPUT = TYPE, PAY = PAY };

                DataProvider.Ins.DB.OUTPUT_INFOR.Add(OUTPUT_INFOR);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(OUTPUT_INFOR);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.OUTPUT_INFOR.Where(x => x.OUTPUT_INFOR_ID == SelectedItem.OUTPUT_INFOR_ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Infor = DataProvider.Ins.DB.OUTPUT_INFOR.Where(x => x.OUTPUT_INFOR_ID == SelectedItem.OUTPUT_INFOR_ID).SingleOrDefault();
                Infor.AMOUNT_MONEY = AMOUNT;
                Infor.TYPE_OUTPUT = TYPE;
                Infor.PAY = PAY;
                Infor.OUTPUT.DATE_OUTPUT = DATE_OUTPUT;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.AMOUNT_MONEY = AMOUNT;
            });
        }
    }
        
}