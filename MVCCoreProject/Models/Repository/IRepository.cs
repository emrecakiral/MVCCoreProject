namespace MVCCoreProject.Models.Repository
{
    // interface generic yaparak üyelerinin dinamik tipte olması sağlanır...
    public interface IRepository<T>
    {
        List<T> GetAll(); // bütün kayıtları listeler

        T Get(int id); // tek bir kayıt listeler

        int Add(T item);// kayıt ekler
        
        int Update(T item);// kayıt günceller

        int Delete(T item);// kayıt siler
    }
}
