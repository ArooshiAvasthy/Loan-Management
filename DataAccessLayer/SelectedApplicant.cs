//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class SelectedApplicant
    {
        public int SelectedAppID { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<double> LoanAmount { get; set; }
        public string TypeOfLoan { get; set; }
        public Nullable<int> Interest { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<System.DateTime> DateofLoan { get; set; }
        public Nullable<double> EMI { get; set; }
    
        public virtual LoanApplicant LoanApplicant { get; set; }
    }
}
