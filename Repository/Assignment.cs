//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TaskProjectId { get; set; }
        public int TeamId { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual Team Team { get; set; }
    }
}