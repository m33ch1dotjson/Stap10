namespace Domain.Interfaces
{
    using Domain.Entities;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IJustForTodayService
    {
        Task InitializeAsync(CancellationToken ct = default);
        JustForToday? GetJFTForToday(DateTime? date = null);
    }
}
