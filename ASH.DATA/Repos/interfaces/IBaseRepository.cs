
namespace ASH.DATA.Repos.interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Save(T request, int userId);
        T Delete(int id);

    }
}
