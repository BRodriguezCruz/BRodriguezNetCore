using System;
using System.Collections.Generic;

namespace DL;

public partial class RecetaMedica
{
    public int IdReceta { get; set; }

    public DateTime? FechaConsulta { get; set; }

    public string? Diagnostico { get; set; }

    public string? NombreMedico { get; set; }

    public string? NotaAdicional { get; set; }

    public int IdPaciente { get; set; }

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;

    //ALIAS EN LOS SP DE LOS GET

    public string? NombrePaciente { get; set; }
}
