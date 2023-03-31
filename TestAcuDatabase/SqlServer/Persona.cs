using System;
using System.Collections.Generic;

namespace TestAcuDatabase.SqlServer
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public int? Edad { get; set; }
    }
}
