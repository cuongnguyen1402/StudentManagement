﻿using StudentManagement.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagement.ViewModels
{
    public class AdminNotificationViewModel: BaseViewModel
    {
        public class CardNotification
        {
            private int _id;
            private string _nguoiDang;
            private string _noiDung;
            private string _chuDe;
            private DateTime _ngayDang;
            private string _loaiBaiDang;

            public CardNotification(int id , string nguoiDang, string loaiBaiDang, string noiDung, string chuDe, DateTime ngayDang)
            {
                Id = id;
                NguoiDang = nguoiDang;
                LoaiBaiDang = loaiBaiDang;
                NoiDung = noiDung;
                ChuDe = chuDe;
                NgayDang = ngayDang;
            }
            public CardNotification(CardNotification a)
            {
                Id = a.Id;
                ChuDe = a.ChuDe;
                NguoiDang = a.NguoiDang;
                LoaiBaiDang = a.LoaiBaiDang;
                NoiDung = a.NoiDung;
                NgayDang = a.NgayDang;
            }

            public string NguoiDang { get => _nguoiDang; set => _nguoiDang = value; }
            public string NoiDung { get => _noiDung; set => _noiDung = value; }
            public string ChuDe { get => _chuDe; set => _chuDe = value; }
            public DateTime NgayDang { get => _ngayDang; set => _ngayDang = value; }
            public string LoaiBaiDang { get => _loaiBaiDang; set => _loaiBaiDang = value; }
            public int Id { get => _id; set => _id = value; }
        }
        public ObservableCollection<CardNotification> _cards;
        private ObservableCollection<CardNotification> _realCards;
        private ObservableCollection<string> _type;
        private ObservableCollection<string> _typeInMain;



        private ICommand _popUpNotification;
        public ICommand PopUpNotification { get => _popUpNotification; set => _popUpNotification = value; }
        private ICommand _searchCommand;
        public ICommand SearchCommand { get => _searchCommand; set => _searchCommand = value; }

        private ICommand _searchTypeCommand;
        public ICommand SearchTypeCommand { get => _searchTypeCommand; set => _searchTypeCommand = value; }


        private string _searchInfo;
        public string SearchInfo 
        { 
            get => _searchInfo; 
            set 
            { 
                _searchInfo = value; 
                OnPropertyChanged(); 
            } 
        }

        public ObservableCollection<string> Type { get => _type; set => _type = value; }
        public ObservableCollection<CardNotification> Cards { get => _cards; set => _cards = value; }
        public ObservableCollection<CardNotification> RealCards { get => _realCards; set { _realCards = value; OnPropertyChanged(); } }
        public ObservableCollection<string> TypeInMain { get => _typeInMain; set => _typeInMain = value; }

        private DateTime? _searchDate;
        public DateTime? SearchDate
        {
            get => _searchDate;
            set
            {
                _searchDate = value;
                OnPropertyChanged();
            }
        }

        private string _searchType;
        public string SearchType
        {
            get => _searchType;
            set
            {
                _searchType = value;
                OnPropertyChanged();
            }
        }

      

        public AdminNotificationViewModel()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            Type = new ObservableCollection<string>() { "Thông báo chung", "Thông báo sinh viên", "Thông báo giáo viên" };
            TypeInMain = new ObservableCollection<string>(Type);
            TypeInMain.Add("Tất cả");
            SearchInfo = "";
            SearchType = "Tất cả";
            SearchDate = null;
            Cards = new ObservableCollection<CardNotification>() {
                new CardNotification(0,"Nguyễn Tấn Toàn","Thông báo chung","Chào các bạn sinh viên! Trung tâm Khảo thí và Đánh giá chất lượng đào tạo - ĐHQG-HCM thông báo lịch thi chứng chỉ trong các tháng 10, 11, 12  ...", "Tổ chức thi chứng chỉ tiếng Anh VNU-OPT", DateTime.Now),
                new CardNotification( 1,"Nguyễn Thị Quý","Thông báo sinh viên","ĐHQG-HCM thông báo lịch thi chứng chỉ trong các tháng 10, 11, 12  ...", "Tổ chức thi chứng chỉ tiếng Anh VNU-OPT", DateTime.Now),
                new CardNotification(2,"Nguyễn Thị Quý","Thông báo giáo viên","Chào các bạn sinh viên! Trung tâm Khảo thí và Đánh giá chất lượng đào tạo - ĐHQG-HCM thông báo lịch thi chứng chỉ trong các tháng 10, 11, 12  ...", "Tổ chức thi chứng chỉ tiếng Anh VNU-OPT", DateTime.Now),
                new CardNotification(3,"Nguyễn Tấn Toàn","Thông báo chung","Chào các bạn sinh viên! Trung tâm Khảo thí và Đánh giá chất lượng đào tạo - ĐHQG-HCM thông báo lịch thi chứng chỉ trong các tháng 10, 11, 12  ...", "Tổ chức thi chứng chỉ tiếng Anh VNU-OPT", DateTime.Now),
                new CardNotification(4,"Nguyễn Tấn Toàn","Thông báo chung","Chào các bạn sinh viên! Trung tâm Khảo thí và Đánh giá chất lượng đào tạo - ĐHQG-HCM thông báo lịch thi chứng chỉ trong các tháng 10, 11, 12  ...", "Cường chức thi chứng chỉ tiếng Anh VNU-OPT", DateTime.Now)

            };
            RealCards = Cards;
            SearchCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   Search();
               });
            PopUpNotification = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {

            });
        }
        public void Search()
        {
            RealCards = Cards;
            var tmp = Cards.Where(x => RemoveSign4VietnameseString(x.ChuDe).ToLower().Contains(RemoveSign4VietnameseString(SearchInfo.ToLower())));
            if (SearchDate != null)
            {
                RealCards = new ObservableCollection<CardNotification>(tmp);
                tmp = tmp.Where(x => x.NgayDang.Date == _searchDate);
            }
            if(!SearchType.Equals("Tất cả"))
            {
                tmp = tmp.Where(x => x.LoaiBaiDang.Contains(SearchType));
            }    
            RealCards = new ObservableCollection<CardNotification>(tmp);
        }
        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        public static string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }
    }
}
