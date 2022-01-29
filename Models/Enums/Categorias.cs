using System.ComponentModel;

namespace challenge_backend_2.Models.Enums
{
    public enum CategoriaType
    {
        [Description("Alimentação")]
        Alimentacao = 1,
        [Description("Saúde")]
        Saude = 2,
        [Description("Moradia")]
        Moradia = 3,
        [Description("Transporte")]
        Transporte = 4,
        [Description("Educação")]
        Educacao = 5,
        [Description("Lazer")]
        Lazer = 6,
        [Description("Imprevistos")]
        Imprevistos = 7,
        [Description("Outras")]
        Outras = 8
    }
}
