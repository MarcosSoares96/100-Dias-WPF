using System.ComponentModel.DataAnnotations;

namespace ExcelCadastro.Models
{
    public class Product
    {
        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O fornecedor é obrigatório")]
        public string Fornecedor { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A categoria é obrigatória")]
        public string Category { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; }

        [Display(Name = "Apresentação")]
        public string Presentation { get; set; }

        [Display(Name = "Especificações")]
        public string Specifications { get; set; }

        [Display(Name = "Área Terapêutica/Indicação")]
        public string TherapeuticArea { get; set; }

        [Display(Name = "Status Regulatório/Observação")]
        public string RegulatoryStatus { get; set; }

        [Display(Name = "Dosagem")]
        public string Dosage { get; set; }
    }
}
