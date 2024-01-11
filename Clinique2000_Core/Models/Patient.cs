using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models
{
    public class Patient
    {
        [Key]       
        public int PatientId { get; set; }
        [Display(Name = "Nom")]
        [StringLength(100)]
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        [StringLength(100)]
        public string Prenom { get; set; }
        [Display(Name = "Numero d'assurance maladie")]
        [StringLength(12)]
        public string NumeroAssuranceMaladie { get; set; }
        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Pas un numéro de téléphone valide")]
        public string Telephone {get; set; }
        [Display(Name = "Courriel")]
        [EmailAddress]
        public string Courriel { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "08/01/2006", ErrorMessage = "Le patient doit être majeur de 18 ans")]
        public DateTime DatedeNaissance { get; set; }
        [Display(Name = "Code Postal")]
        [DataType(DataType.PostalCode)]
        public string CodePostal { get; set; }
        [ForeignKey("User")]
        [ValidateNever]
        public string UserId {get; set; }
        [ValidateNever]
        public virtual User  User { get; set; }
    }
}
