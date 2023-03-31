using Microsoft.AspNetCore.Mvc;
using TestAcu1.Database;

namespace TestAcu1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
            
        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

       //Proyecto de testing
        [HttpGet("")]
        public List<Persona> GetAll()
        {
            DBTestAcuContext ConexionBD = new DBTestAcuContext();
            return ConexionBD.Personas.ToList();
        }

        [HttpGet("Shuffle")]
        public Persona? Shuffle()
        {
            DBTestAcuContext ConexionBD = new DBTestAcuContext();
            int proximoRegistro = (new Random()).Next(ConexionBD.Personas.Count() - 1);
            Persona? personaABuscar = ConexionBD.Personas.Skip(proximoRegistro).FirstOrDefault();
            return personaABuscar;
        }

        [HttpGet("{id}")]
        public Persona? GetById(int id)
        {
            DBTestAcuContext ConexionBD = new DBTestAcuContext();
            Persona? personaABuscar = ConexionBD.Personas.Where(x => x.Id == id).FirstOrDefault();
            return personaABuscar;
        }

        [HttpDelete("{id}")]
        public bool DeleteById(int id)
        {
            DBTestAcuContext ConexionBD = new DBTestAcuContext();
            Persona? personaABuscar = ConexionBD.Personas.Where(x => x.Id == id).FirstOrDefault();
            return true;
        }

    }
}