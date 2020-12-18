using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityLibrary.Extensions
{
    public static class ExtensionMethods
    {
        
        /// <summary>
        /// Determine if a connection can be made asynchronously
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<bool> TestConnectionTask(this DbContext context) => 
            await Task.Run(async () => await context.Database.CanConnectAsync());

        public static async Task<bool> TestConnectionTask(this DbContext context, CancellationToken token) =>
            await Task.Run(async () => await context.Database.CanConnectAsync(token), token);
    }
}