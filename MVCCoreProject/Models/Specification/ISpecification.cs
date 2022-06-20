namespace MVCCoreProject.Models.Specification
{
    public interface ISpecification<T>
    {

        // lambda parameter...
        List<T> FindByCriter(Func<T, bool> expression);
    }
}
