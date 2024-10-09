namespace OnlineWeatherService.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IWeatherRepository WeatherkRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}
