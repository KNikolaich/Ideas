//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbConnector
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enterprise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enterprise()
        {
            this.BusinessAgent_Enterprise = new HashSet<BusinessAgent_Enterprise>();
            this.OurEnterprise = new HashSet<OurEnterprise>();
        }
    
        public System.Guid ID { get; set; }
        public string DerivedType { get; set; }
        public System.Guid VersionID { get; set; }
        public System.Guid SessionID { get; set; }
        public string ChiefAccountant { get; set; }
        public string LeaderDative { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Nullable<System.DateTime> LiscenseDate { get; set; }
        public string LiscenceNumber { get; set; }
        public string LiscenseIssue { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string OGRN { get; set; }
        public string INN { get; set; }
        public string Address { get; set; }
        public string Account { get; set; }
        public string Bank { get; set; }
        public string BankCity { get; set; }
        public string KorrAccount { get; set; }
        public string BIK { get; set; }
        public string KPP { get; set; }
        public string OKPO { get; set; }
        public string OKVED { get; set; }
        public string Info { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string FactAddress { get; set; }
        public string SettlementAccount { get; set; }
        public string PersonalAccount { get; set; }
        public string BudgetAccount { get; set; }
        public string Leader { get; set; }
        public string OKONX { get; set; }
        public string OKOGY { get; set; }
        public string EVRO { get; set; }
        public string OKTMO { get; set; }
        public string EGRN { get; set; }
        public string OKATO { get; set; }
        public string OKFS { get; set; }
        public string OKOPF { get; set; }
        public string OMSCode { get; set; }
        public Nullable<int> DerivedTypeID { get; set; }
        public Nullable<System.Guid> RFRegionID { get; set; }
        public string KBK { get; set; }
        public string CodeCardioRegister { get; set; }
        public string CodeOMSCardioRegister { get; set; }
        public string FOMSCode { get; set; }
        public string IEMKCode { get; set; }
        public string FedCode { get; set; }
        public string MDLPSubjectId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BusinessAgent_Enterprise> BusinessAgent_Enterprise { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OurEnterprise> OurEnterprise { get; set; }
    }
}
