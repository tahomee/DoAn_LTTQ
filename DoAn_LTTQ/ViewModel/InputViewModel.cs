using DoAn_LTTQ.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoAn_LTTQ.ViewModel
{
    public class InputViewModel : BaseViewModel
    {
        private ObservableCollection<INPUT_INFOR> _List;
        public ObservableCollection<INPUT_INFOR> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private INPUT_INFOR _SelectedItem;
        public INPUT_INFOR SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    AMOUNT = SelectedItem.AMOUNT_MONEY;
                    TYPE = SelectedItem.TYPE_INPUT;
                    PERIODIC = SelectedItem.PERIODIC;
                    DATE_INPUT = SelectedItem.INPUT.DATE_INPUT;
                }
            }
        }

        private double? _Amount;
        public double? AMOUNT { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }


        private DateTime? _Date_input;
        public DateTime? DATE_INPUT { get => _Date_input; set { _Date_input = value; OnPropertyChanged(); } }


        private string _TYPE;
        public string TYPE { get => _TYPE; set { _TYPE = value; OnPropertyChanged(); } }


        private string _Periodic;
        public string PERIODIC { get => _Periodic; set { _Periodic = value; OnPropertyChanged(); } }




        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public InputViewModel()
        {
            List = new ObservableCollection<INPUT_INFOR>(DataProvider.Ins.DB.INPUT_INFOR);

            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                var INPUT_INFOR = new INPUT_INFOR() { AMOUNT_MONEY = AMOUNT, TYPE_INPUT = TYPE, PERIODIC = PERIODIC };

                DataProvider.Ins.DB.INPUT_INFOR.Add(INPUT_INFOR);
                DataProvider.Ins.DB.SaveChanges();

                List.Add(INPUT_INFOR);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;

                var displayList = DataProvider.Ins.DB.INPUT_INFOR.Where(x => x.INPUT_INFOR_ID == SelectedItem.INPUT_INFOR_ID);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {
                var Infor = DataProvider.Ins.DB.INPUT_INFOR.Where(x => x.INPUT_INFOR_ID == SelectedItem.INPUT_INFOR_ID).SingleOrDefault();
                Infor.AMOUNT_MONEY = AMOUNT;
                Infor.TYPE_INPUT = TYPE;
                Infor.PERIODIC = PERIODIC;
                Infor.INPUT.DATE_INPUT = DATE_INPUT;
                DataProvider.Ins.DB.SaveChanges();

                SelectedItem.AMOUNT_MONEY = AMOUNT;
            });
        }
    }
}
