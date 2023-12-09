using System;
using System.Collections.Generic;

namespace MVCControlEscolar.Models;

public partial class EstatusAcreditacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
