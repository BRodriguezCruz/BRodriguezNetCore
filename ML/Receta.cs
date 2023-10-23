namespace ML
{
    public class Receta
    {
        public int IdReceta { get; set; }
        public string? FechaConsulta { get; set; }
        public string? Diagnostico { get; set; }
        public string? NombreMedico { get; set; }
        public string? NotaAdicional { get; set; }
        public ML.Paciente Paciente { get; set; }
        public List<object> Recetas { get; set; }

    }
}