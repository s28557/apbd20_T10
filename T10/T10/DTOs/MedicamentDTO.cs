﻿namespace T10.DTOs;

public class MedicamentDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; } = null!;
}