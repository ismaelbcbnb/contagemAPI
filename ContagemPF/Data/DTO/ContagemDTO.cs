using System.Text.Json.Serialization;

namespace ContagemPF.Data.DTO;

public class ContagemDTO
{
    [JsonIgnore]
    public int IdContagem { get; set; }
    public int NumCard { get; set; }
    public int NumContagem { get; set; }
    public double? PontosDeFuncao { get; set; }
    public string Sistema { get; set; } = string.Empty;
    public bool Validado { get; set; }
    public bool Entregue { get; set; }
    public string? Link { get; set; } = string.Empty;
    public string? Mes { get; set; } = string.Empty;
}

