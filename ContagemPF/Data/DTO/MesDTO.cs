using System.Text.Json.Serialization;

namespace ContagemPF.Data.DTO;

public class MesDTO
{
    [JsonIgnore]
    public int IdMes { get; set; }
    public string MesAno { get; set; } = string.Empty;
}