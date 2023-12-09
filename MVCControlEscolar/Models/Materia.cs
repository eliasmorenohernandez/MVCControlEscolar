using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCControlEscolar.Models;

public partial class Materia
{
    public int Id { get; set; }

    [StringLength(10)]
    [MinLength(5)]
    public string Clave { get; set; } = null!;

    [StringLength(60)]
    [MinLength(3)]
    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public int IdEstatusRegistro { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual EstatusRegistro IdEstatusRegistroNavigation { get; set; } = null!;
}
