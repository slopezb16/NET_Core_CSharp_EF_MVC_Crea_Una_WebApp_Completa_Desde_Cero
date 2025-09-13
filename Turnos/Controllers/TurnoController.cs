using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;
        private IConfiguration _configuration;

        public TurnoController(TurnosContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList(
                (from medico in _context.Medico.ToList() select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + medico.Apellido }),
                "IdMedico",
                "NombreCompleto");

            ViewData["IdPaciente"] = new SelectList(
            (from paciente in _context.Paciente.ToList() select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }),
            "IdPaciente",
            "NombreCompleto");

            return View();
        }

        public JsonResult ObtenerTurnos(int idMedico)
        {
            // List<Turno> turnos = new List<Turno>();
            // turnos = _context.Turnos.Where(x => x.IdMedico == idMedico).ToList();

            var turnos = _context.Turnos.Where(x => x.IdMedico == idMedico)
            .Select(x => new
            {
                x.IdTurno,
                x.IdMedico,
                x.IdPaciente,
                x.FechaHoraInicio,
                x.FechaHoraFin,
                Paciente = x.Paciente.Nombre + " " + x.Paciente.Apellido,
            })
            .ToList();

            return Json(turnos);
        }

        [HttpPost]
        public JsonResult CreateTurno(Turno turno)
        {
            bool result = false;
            // var result = false;
            try
            {
                _context.Turnos.Add(turno);

                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exepciones encontradas", ex);
            }

            var jsonResult = new { ok = result };

            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult DelateTurno(int idTurno)
        {
            bool result = false;
            // var result = false;
            try
            {
                var turno = _context.Turnos.Where(x => x.IdTurno == idTurno).FirstOrDefault();

                if (turno is not null)
                {
                    _context.Turnos.Remove(turno);

                    _context.SaveChanges();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exepciones encontradas", ex);
            }

            var jsonResult = new { ok = result };

            return Json(jsonResult);
        }
    }
}