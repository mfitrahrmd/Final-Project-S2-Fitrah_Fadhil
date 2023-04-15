namespace API.Repositories.Contracts;

public interface IEntity<Tpk>
{
    public Tpk Pk { get; set; }
}