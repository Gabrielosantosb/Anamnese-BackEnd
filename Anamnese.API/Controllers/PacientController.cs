﻿using Anamnese.API.Application.Services.Pacient;
//using Anamnese.API.Migrations;
using Anamnese.API.ORM.Entity;
using Anamnese.API.ORM.Model.PacientModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anamnese.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private readonly IPacientService _pacientService;
        public PacientController(IPacientService pacientService)
        {
            _pacientService = pacientService;         
        }

        [HttpGet("get-pacients")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPacients()
        {
            var pacients = _pacientService.GetAllPacients();

            return Ok(pacients);
        }

        [HttpGet("get-pacient/{pacientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPacientsById(int pacientId)
        {
            var pacient = _pacientService.GetPacientById(pacientId);

            if (pacient != null)
            {
                return Ok(pacient);
            }
            else
            {
                return BadRequest("Paciente não encontrado");
            }
        }

        [HttpGet("get-profissional-pacient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProfissionalPacients()
        {
            var pacients = _pacientService.GetPacientsByProfissional();

            if (pacients != null)
            {
                return Ok(pacients);
            }
            else
            {
                return BadRequest("Pacientes não encontrados para o profissional especificado");
            }
        }
        [HttpGet("count-pacient-by-specialty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CountReferralsBySpecialty()
        {
            var pacientCount = _pacientService.CountPacientBySpecialty();
            return Ok(pacientCount);
        }

        [HttpPost("create-pacient")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePacient([FromBody] CreatePacientRequest pacientModel)
        {

            if (pacientModel == null)
            {
                return BadRequest("Dados do paciente inválidos");
            }
            var createdPacient = _pacientService.CreatePacient(pacientModel);
            if (createdPacient != null)
            {
                return Ok(pacientModel);
            }
            else
            {
                return BadRequest();
            }
        }
 

        [HttpPut("update-pacient/{pacientId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public PacientModel UpdatePacient(int pacientId, CreatePacientRequest updatedPacientModel)
        {
            var existingPacient = _pacientService.GetPacientById(pacientId);

            if (existingPacient != null)
            {
                existingPacient.Username = updatedPacientModel.Username;
                existingPacient.Email = updatedPacientModel.Email;
                existingPacient.Address = updatedPacientModel.Address;
                existingPacient.Uf = updatedPacientModel.Uf;
                existingPacient.Phone = updatedPacientModel.Phone;
                existingPacient.Birth = updatedPacientModel.Birth;
                existingPacient.Gender = updatedPacientModel.Gender;

                _pacientService.UpdatePacient(pacientId, existingPacient);
                return existingPacient;
            }

            return null;
        }

        [HttpDelete("remove-pacient/{pacientId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RemovePacient(int pacientId)
        {
            var removedPacient = _pacientService.DeletePacient(pacientId);

            return Ok(removedPacient);

        }

        [HttpGet("count-pacients")]
        public IActionResult CountAllPacients()
        {
            int totalPacients = _pacientService.CountAllPacients();
            return Ok(totalPacients);
        }

        [HttpGet("count-profissional")]
        public IActionResult CountProfissionalPacients()
        {
            int totalProfissionalPacients = _pacientService.CountAllProfissionalPacients();
            return Ok(totalProfissionalPacients);
        }

    }
}
