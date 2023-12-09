using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCControlEscolar.Models;

public partial class Grupo
{
    public int Id { get; set; }

    [StringLength(50)]
    [MinLength(10)]
    public string Nombre { get; set; } = null!;

    public int IdProfesor { get; set; }

    public int IdMateria { get; set; }

    public int IdEstatusRegistro { get; set; }

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    public virtual EstatusRegistro IdEstatusRegistroNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;

    //public ICollection<Calificacion> Calificacion { get; set; } = new List<Calificacion>();
}
