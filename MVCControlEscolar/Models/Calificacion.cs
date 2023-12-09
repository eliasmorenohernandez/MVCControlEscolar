using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCControlEscolar.Models;

public partial class Calificacion
{
    public int Id { get; set; }

    public int IdAlumno { get; set; }

    public int IdGrupo { get; set; }

    //[Column(TypeName = "decimal(5:1)")]
    [RegularExpression(@"^[0-9]+$")]
    [StringLength(3)]
    [MinLength(1)]
    public string CalificacionGrupo { get; set; } = null!;

    public int IdEstatusAcreditacion { get; set; }

    public int IdEstatusRegistro { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual EstatusAcreditacion IdEstatusAcreditacionNavigation { get; set; } = null!;

    public virtual EstatusRegistro IdEstatusRegistroNavigation { get; set; } = null!;

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;
}
