using System.Runtime.CompilerServices;
using Genesis.Ensure;

namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static ConfiguredTaskAwaitable ContinueOnAnyContext(this Task @this)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            return @this.ConfigureAwait(false);
        }

        public static ConfiguredTaskAwaitable<T> ContinueOnAnyContext<T>(this Task<T> @this)
        {
            Ensure.ArgumentNotNull(@this, nameof(@this));
            return @this.ConfigureAwait(false);
        }
    }
}