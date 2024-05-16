using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Cliente
    {
        [Key]
        public int idCLiente { get; set; }//Identificador del cliente
        public string nombreEmpresa { get; set; }//Nombre del sistema de información, nose porque coloqué empresaxd

        public virtual ICollection<Usuario> Usuarios { get; set; }//Relación uno a muchos con la tabla Usuario
    }

}

