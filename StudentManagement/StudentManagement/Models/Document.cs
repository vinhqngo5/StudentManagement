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
    
    public partial class Document : BaseViewModel
    {
        private System.Guid _id { get; set; }
        public System.Guid Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private string _displayName { get; set; }
        public string DisplayName { get => _displayName; set { _displayName = value; OnPropertyChanged(); } }
        private string _content { get; set; }
        public string Content { get => _content; set { _content = value; OnPropertyChanged(); } }
        private Nullable<System.DateTime> _createdAt { get; set; }
        public Nullable<System.DateTime> CreatedAt { get => _createdAt; set { _createdAt = value; OnPropertyChanged(); } }
        private System.Guid _idPoster { get; set; }
        public System.Guid IdPoster { get => _idPoster; set { _idPoster = value; OnPropertyChanged(); } }
        private Nullable<System.Guid> _idFolder { get; set; }
        public Nullable<System.Guid> IdFolder { get => _idFolder; set { _idFolder = value; OnPropertyChanged(); } }
        private System.Guid _idSubjectClass { get; set; }
        public System.Guid IdSubjectClass { get => _idSubjectClass; set { _idSubjectClass = value; OnPropertyChanged(); } }
    
        public virtual Folder Folder { get; set; }
        public virtual User User { get; set; }
        public virtual SubjectClass SubjectClass { get; set; }
    }
}
