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
    
    public partial class sysdiagram : BaseViewModel
    {
        private string _name { get; set; }
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private int _principal_id { get; set; }
        public int principal_id { get => _principal_id; set { _principal_id = value; OnPropertyChanged(); } }
        private int _diagram_id { get; set; }
        public int diagram_id { get => _diagram_id; set { _diagram_id = value; OnPropertyChanged(); } }
        private Nullable<int> _version { get; set; }
        public Nullable<int> version { get => _version; set { _version = value; OnPropertyChanged(); } }
        private byte[] _definition { get; set; }
        public byte[] definition { get => _definition; set { _definition = value; OnPropertyChanged(); } }
    }
}
