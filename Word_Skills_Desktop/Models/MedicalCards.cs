//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Word_Skills_Desktop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalCards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicalCards()
        {
            this.MedicalHistories = new HashSet<MedicalHistories>();
            this.Patients = new HashSet<Patients>();
        }
    
        public int medical_card_id { get; set; }
        public Nullable<System.DateTime> issue_date { get; set; }
        public System.DateTime last_contact_date { get; set; }
        public Nullable<System.DateTime> next_contact_date { get; set; }
        public int insurance_policy_id { get; set; }
    
        public virtual InsurancePoles InsurancePoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalHistories> MedicalHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patients> Patients { get; set; }
    }
}
