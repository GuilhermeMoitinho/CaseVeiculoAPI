namespace CaseVeiculo.Domain.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DataDeAlteracao { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            DataDeAlteracao = DateTime.Now.ToLocalTime();
        }
    }
}
