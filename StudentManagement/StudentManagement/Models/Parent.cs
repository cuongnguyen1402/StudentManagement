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
    
    public partial class Parent : BaseViewModel
    {
        public Parent()
        {
            this.Students = new HashSet<Student>();
        }
    
        private System.Guid _id { get; set; }
        public System.Guid Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _nameDad { get; set; }
        public string NameDad { get => _nameDad; set { _nameDad = value; OnPropertyChanged(); } }
        private string _nameMom { get; set; }
        public string NameMom { get => _nameMom; set { _nameMom = value; OnPropertyChanged(); } }
        private string _addressDad { get; set; }
        public string AddressDad { get => _addressDad; set { _addressDad = value; OnPropertyChanged(); } }
        private string _addressMom { get; set; }
        public string AddressMom { get => _addressMom; set { _addressMom = value; OnPropertyChanged(); } }
        private string _phoneDad { get; set; }
        public string PhoneDad { get => _phoneDad; set { _phoneDad = value; OnPropertyChanged(); } }
        private string _phoneMom { get; set; }
        public string PhoneMom { get => _phoneMom; set { _phoneMom = value; OnPropertyChanged(); } }
        private string _jobDad { get; set; }
        public string JobDad { get => _jobDad; set { _jobDad = value; OnPropertyChanged(); } }
        private string _jobMom { get; set; }
        public string JobMom { get => _jobMom; set { _jobMom = value; OnPropertyChanged(); } }
    
        public virtual ICollection<Student> Students { get; set; }
    }
}
