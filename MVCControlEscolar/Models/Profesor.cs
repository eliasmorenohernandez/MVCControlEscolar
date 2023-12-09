using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVCControlEscolar.Models;

public partial class Profesor
{
    public int Id { get; set; }

    //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    //[StringLength(60, MinimumLength = 3)]
    //[Required]
    public string Nombre { get; set; } = null!;

    //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    //[StringLength(60, MinimumLength = 3)]
    //[Required]
    public string PrimerApellido { get; set; } = null!;

    //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    //[StringLength(60, MinimumLength = 3)]
    public string? SegundoApellido { get; set; }

    //[RegularExpression(@"^(([^<>()[\]\.,;:\s@\""]+(\.[^<>()[\]\.,;:\s@\""]+)*)|(\"".+\""))@(([^<>()[\]\.,;:\s@\""]+\.)+[^<>()[\]\.,;:\s@\""]{2,})$")]
    //[StringLength(150, MinimumLength = 15)]
    //[Required]
    //[EmailAddress]
    public string CorreoElectronico { get; set; } = null!;

    //[RegularExpression(@"^[0-9]+$")]
    //[StringLength(13, MinimumLength = 10)]
    public string? Telefono { get; set; }

    public int IdEstatusRegistro { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual EstatusRegistro IdEstatusRegistroNavigation { get; set; } = null!;
}
