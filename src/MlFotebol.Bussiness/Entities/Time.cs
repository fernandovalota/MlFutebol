
namespace MlFutebol.Bussiness.Entities
{
    public class Time: Entity
    {
        public string Nome { get; set; }
        public string Serie { get; set; }
        /*EF Relation*/
        public List<Jogador> Jogadores { get; set; }
    }
}
