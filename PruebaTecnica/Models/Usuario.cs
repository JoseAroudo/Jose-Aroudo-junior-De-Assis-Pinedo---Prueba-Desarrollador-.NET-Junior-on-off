using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; } //Identificador del usuario


        [MaxLength(50, ErrorMessage = "El Campo {0} debe ser de máximo {1} caracteres.")]//Validación de longitud de campo, máximo 50 caracteres
        public string nombreUsuario { get; set; } //Nombre del usuario

        public DateTime fechaNacimiento { get; set; } //Fecha de nacimiento del usuario


        [Required]
        public int idCliente { get; set; } // FK de la tabla Cliente
        [ForeignKey("idCliente")]
        public virtual Cliente cliente { get; set; }


        [Required]
        public int idSorteo { get; set; } // FK de la tabla sorteo
        [ForeignKey("idSorteo")]
        public virtual Sorteo sorteo { get; set; }
    }
}