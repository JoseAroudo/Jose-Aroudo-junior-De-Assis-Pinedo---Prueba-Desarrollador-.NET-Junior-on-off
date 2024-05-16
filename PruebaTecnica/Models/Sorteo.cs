using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Sorteo
    {
        [Key]
        public int idSorteo { get; set; } //Identificador del sorteo

        [MaxLength(10, ErrorMessage = "El Campo {0} debe ser de máximo {1} caracteres.")]//Validación de longitud de campo, máximo 10 numeros


        [Range(0, 99999, ErrorMessage = "El número del sorteo debe estar entre 0 y 99999.")]
        public int numeroSorteo { get; set; }//Numero ganador del sorteo, cual se puede igualar con la boleta del cliente para saber el ganador


        public virtual ICollection<Usuario> Usuarios { get; set; }//Relación uno a muchos con la tabla Usuario
    } 
}
