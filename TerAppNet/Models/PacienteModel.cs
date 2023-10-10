using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TerAppNet.Models
{
    public class PacienteModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Paciente_Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        public int Telefono { get; set; }

        [Required, StringLength(100)]
        public string Correo { get; set; }

        [Required, StringLength(2000)]
        public string Historial_medico { get; set; }

        [Required, StringLength(2000)]
        public string Receta_Medica { get; set; }

        [Required]
        public int Duracion_Rec { get; set; }

        [Required]
        public string FotoPerfil { get; set; }
    }
}