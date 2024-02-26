using System.ComponentModel;

namespace MlFutebol.Bussiness.Entities.Enum
{
    public enum Genero
    {
        /// <summary>
        /// Gênero masculino.
        /// </summary>        
        [Description("Gênero masculino")]
        Maculino,
        /// <summary>
        /// Gênero feminino
        /// </summary>
        [Description("Gênero feminino")]
        Feminino,
        /// <summary>
        /// Gênero não especificado
        /// </summary>
        [Description("Gênero não especificado")]
        Outro,
    }
}
