﻿namespace CatalogAPI.Models;

public class DoctorModel
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public ICollection<PacientModel> Pacients { get; set; }

}
