using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Misc
{
    public static partial class Misc
    {
        public static async Task SeedData(this IUnitOfWork unitOfWork)
        {
            if (await (await unitOfWork.Dogs.GetAll()).CountAsync() == 0)
            {
                await unitOfWork.BeginTransaction();

                try
                {
                    await unitOfWork.Dogs.Add(new Domain.Entities.Dog()
                    {
                        Name = "Neo",
                        Color = "red&amber",
                        TailLength = 22,
                        Weight = 32
                    });

                    await unitOfWork.Dogs.Add(new Domain.Entities.Dog()
                    {
                        Name = "Jessy",
                        Color = "black&white",
                        TailLength = 7,
                        Weight = 14
                    });

                    await unitOfWork.Dogs.Add(new Domain.Entities.Dog()
                    {
                        Name = "Lucky",
                        Color = "orange&black&white",
                        TailLength = 10,
                        Weight = 40
                    });

                    await unitOfWork.CommitTransaction();
                }
                catch
                {
                    await unitOfWork.RollbackTransaction();
                    return;
                }
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
