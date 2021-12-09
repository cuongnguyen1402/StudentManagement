//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.Models
{
    using StudentManagement.ViewModels;
    using System;
    using System.Collections.Generic;
    
    public partial class UserRole_UserInfo : BaseViewModel
    {
        public UserRole_UserInfo()
        {
            this.User_UserRole_UserInfo = new HashSet<User_UserRole_UserInfo>();
            this.UserRole_UserInfoItem = new HashSet<UserRole_UserInfoItem>();
        }
    
        private System.Guid _id { get; set; }
        public System.Guid Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private Nullable<System.Guid> _idRole { get; set; }
        public Nullable<System.Guid> IdRole { get => _idRole; set { _idRole = value; OnPropertyChanged(); } }
        private string _infoName { get; set; }
        public string InfoName { get => _infoName; set { _infoName = value; OnPropertyChanged(); } }
        private Nullable<int> _type { get; set; }
        public Nullable<int> Type { get => _type; set { _type = value; OnPropertyChanged(); } }
        private Nullable<bool> _isEnable { get; set; }
        public Nullable<bool> IsEnable { get => _isEnable; set { _isEnable = value; OnPropertyChanged(); } }
        private Nullable<bool> _isDeleted { get; set; }
        public Nullable<bool> IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
    
        public virtual ICollection<User_UserRole_UserInfo> User_UserRole_UserInfo { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserRole_UserInfoItem> UserRole_UserInfoItem { get; set; }
    }
}
