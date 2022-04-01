using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Runtime.CompilerServices;

namespace PTWServer1
{
    #region snippet_AsyncIterator
    public class AsyncEnumerableHub: Hub
    {
        public async IAsyncEnumerable<int> Counter(
            int count, 
            int delay,
            [EnumeratorCancellation]
        CancellationToken cancellationToken)
        {
            Console.WriteLine("counter 1");
            for (var i = 0; i < count; i++)
            {
                // Check the cancellation token regularly so that the server will stop
                // producing items if the client disconnects.
                cancellationToken.ThrowIfCancellationRequested();

                yield return i;

                // Use the cancellationToken in other APIs that accept cancellation
                // tokens so the cancellation can flow down to them.
                await Task.Delay(delay, cancellationToken);
            }
        }
    }
    #endregion
}
