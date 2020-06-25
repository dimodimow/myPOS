namespace myPOS.Web.Mappers.Contracts
{
    public interface IMapper<T, U>
    {
        T Map(U entity);
    }
}
