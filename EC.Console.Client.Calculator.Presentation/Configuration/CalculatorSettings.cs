using System.ComponentModel.DataAnnotations;

public class CalculatorSettings
{
    [Required]
    public string CalculatorApiUrl { get; set; }
}