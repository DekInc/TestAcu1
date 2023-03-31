using Microsoft.AspNetCore.Mvc;
using TestAcuDatabase.SqlServer;
using TestAcu1.Models;

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

        [HttpGet("")]
        public RetValue<List<Persona>> GetAll()
        {
            try
            {
                DBTestAcuContext conexionBD = new DBTestAcuContext();
                return new RetValue<List<Persona>>()
                {
                    Value = conexionBD.Personas.ToList()
                };
            }
            catch (Exception e1)
            {
                return new RetValue<List<Persona>>()
                {
                    ErrorMessage = e1.Message
                };
            }
        }

        [HttpGet("Shuffle")]
        public RetValue<Persona?> Shuffle()
        {
            try
            {
                DBTestAcuContext conexionBD = new DBTestAcuContext();
                int proximoRegistro = (new Random()).Next(conexionBD.Personas.Count() - 1);
                Persona? personaABuscar = conexionBD.Personas.Skip(proximoRegistro).FirstOrDefault();
                return new RetValue<Persona?>()
                {
                    Value = personaABuscar
                };
            }
            catch (Exception e1)
            {
                return new RetValue<Persona?>()
                {
                    ErrorMessage = e1.Message
                };
            }
        }

        [HttpGet("{id}")]
        public RetValue<Persona?> GetById(int id)
        {
            try
            {
                DBTestAcuContext conexionBD = new DBTestAcuContext();
                Persona? personaABuscar = conexionBD.Personas.Where(x => x.Id == id).FirstOrDefault();
                return new RetValue<Persona?>()
                {
                    Value = personaABuscar,
                    ErrorMessage = personaABuscar == null ? "Not found" : ""
                };
            }
            catch (Exception e1)
            {
                return new RetValue<Persona?>()
                {
                    ErrorMessage = e1.Message
                };
            }
        }

        [HttpDelete("{id}")]
        public RetValue<bool> DeleteById(int id)
        {
            try
            {
                DBTestAcuContext conexionBD = new DBTestAcuContext();
                Persona? personaABuscar = conexionBD.Personas.Where(x => x.Id == id).FirstOrDefault();
                if (personaABuscar == null)
                {
                    return new RetValue<bool>()
                    {
                        Value = false,
                        ErrorMessage = "Not found"
                    };
                }
                else
                {
                    conexionBD.Personas.Remove(personaABuscar);
                    conexionBD.SaveChanges();
                    return new RetValue<bool>()
                    {
                        Value = true
                    };
                }
            }
            catch (Exception e1)
            {
                return new RetValue<bool>()
                {
                    Value = false,
                    ErrorMessage = e1.Message
                };
            }
        }

    }
}