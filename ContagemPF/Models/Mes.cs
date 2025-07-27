using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContagemPF.Models;

public class Mes
{
    [Key]
    public int IdMes { get; set; }
    [MaxLength(50)]
    public string MesAno { get; set; } = string.Empty;
}