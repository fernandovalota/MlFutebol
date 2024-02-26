

namespace MlFutebol.Bussiness.Entities
{
    public abstract class Entity
    {
        /// <summary>
        /// classe genérica
        /// </summary>
        protected Entity() 
        { 
            Id = Guid.NewGuid();
        } 
        public Guid Id { get; set; }
    }
}
