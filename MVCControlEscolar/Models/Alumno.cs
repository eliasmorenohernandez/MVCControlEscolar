using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCControlEscolar.Models;

public partial class Alumno
{
    public int Id { get; set; }

    [StringLength(10)]
    [MinLength(10)]
    public string Matricula { get; set; } = null!;

    [StringLength(60)]
    [MinLength(3)]
    public string Nombre { get; set; } = null!;

    [StringLength(60)]
    [MinLength(3)]
    public string PrimerApellido { get; set; } = null!;

    [StringLength(60)]
    [MinLength(3)]
    public string? SegundoApellido { get; set; }

    [StringLength(150)]
    [MinLength(15)]
    [EmailAddress]
    public string CorreoElectronico { get; set; } = null!;

    [StringLength(13)]
    [MinLength(10)]
    [Phone]
    public string? Telefono { get; set; }

    public int IdEstatusRegistro { get; set; }

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    public virtual EstatusRegistro IdEstatusRegistroNavigation { get; set; } = null!;
}
