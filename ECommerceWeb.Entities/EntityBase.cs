namespace ECommerceWeb.Entities
{
    /// <summary>
    /// Clase base para todas las tablas en este proyecto
    /// </summary>
    public class EntityBase
    {
        public int Id { get; set; }
        public bool Estado { get; set; }

        protected EntityBase()
        {
            Estado = true;
        }
    }
}
