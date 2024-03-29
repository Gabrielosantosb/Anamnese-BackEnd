﻿using AnamneseAPI.Models;
using AnamneseAPI.Services.Pacient.Models;
using AnamneseAPI.Services.Report.Models;
using CatalogAPI.Context;
using CatalogAPI.Models;
using CatalogAPI.Repository;
using CatalogAPI.Services.Token;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Services.Pacient
{
    public class PacientService : IPacientService
    {
        private readonly MySQLContext _context;
        private readonly BaseRepository<PacientModel> _pacientRepository;        
        private ITokenService _tokenService { get; }
        

        public PacientService(MySQLContext context, BaseRepository<PacientModel> pacientRepository, ITokenService tokenService)
        {
            _context = context;
            _pacientRepository = pacientRepository;
            _tokenService = tokenService;        
        }

        public IEnumerable<PacientModel> GetAllPacients()
        {
            return _pacientRepository.GetAll();
        }

        public PacientModel GetPacientById(int id)
        {
            return _pacientRepository.GetById(id);
        }

        public PacientModel CreatePacient(CreatePacientRequest pacient)
        {            
            int userId = _tokenService.GetUserId();
            var res = _pacientRepository.Add(new PacientModel
            {
                Address = pacient.Address,
                Birth = pacient.Birth,
                Email = pacient.Email,
                Phone = pacient.Phone,
                Profession = pacient.Profession,
                Uf = pacient.Uf,
                UserName = pacient.Username,
                Gender = pacient.Gender,
                DoctorId = userId
            });
            _pacientRepository.SaveChanges();

            return res;
            //return _pacientRepository.Create(pacient);            
        }

        public PacientModel UpdatePacient(int id, PacientModel updatedPacient)
        {
            var existingPacient = _pacientRepository.GetById(id);

            if (existingPacient != null)
            {

                existingPacient.UserName = updatedPacient.UserName;
                existingPacient.Email = updatedPacient.Email;
                existingPacient.Address = updatedPacient.Address;
                existingPacient.Uf = updatedPacient.Uf;
                existingPacient.Phone = updatedPacient.Phone;
                existingPacient.Birth = updatedPacient.Birth;
                existingPacient.Gender = updatedPacient.Gender;
                
                _pacientRepository.SaveChanges();

                _pacientRepository.Update(existingPacient);

                return existingPacient;
            }
            
            return null;
        }

        public PacientModel DeletePacient(int id)
        {
            var pacientToRemove = _pacientRepository.GetById(id);

            if (pacientToRemove != null)
            {
                _pacientRepository.Delete(pacientToRemove);
                _context.SaveChanges();

                return pacientToRemove;
            }
            return null;

        }

        public void PatchPacient(int pacientId, int newReportId)
        {
            
            var pacient = _pacientRepository.GetById(pacientId);
            if (pacient != null)
            {
                pacient.ReportId = 1;
                _pacientRepository.Update(pacient);
                _pacientRepository.SaveChanges();
            }
            else
            {
                throw new Exception("Erro ao mudar ReportID");
                
            }
        }

        public bool PacientExists(int pacientId)
        {
            var pacient = _pacientRepository.GetById(pacientId);
            return pacient != null;
        }

        public ReportModel CreateReport(int pacientId, CreateReportRequest report)
        {
            throw new NotImplementedException();
        }
    }
}
