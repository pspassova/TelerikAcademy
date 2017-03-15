namespace Movies.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
