using leecodeTest.Recursion;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leecodeTest.ThreadSafety
{
    /*
      針對 Queue, 在多執行緒下 其實是不安全的 因為會有大量地使用同時 Enqueue, Dequeue.
      1. 使用 SafeEnqueue => 使用lock 讓一次只執行一個執行緒
      2. 使用 ConcurrentQueue<T> 

    public class ThreadSafety
    {
        private readonly object _lock = new object();
        public void SafeEnqueue(Queue<TreeNode> queue, TreeNode node)
        {
            lock (_lock)
            {
                queue.Enqueue(node);
            }
            ConcurrentQueue<TreeNode> concurrentQueue = new ConcurrentQueue<TreeNode>();
        }
    }
    */

    /*
      Async / Await 的問題
        為什麼適用await, 而不是用 .Result or .Wait() 
        => 因為await 會將未執行完成的執行緒先去將其他項目執行完成,  再回來繼續執行未完成者. 
    */

    /*
     如何處理超高流量 => 
        1. 佇列化 Queuing => 使用 RabbitMQ or Kafka 等地 Message Queue 裡面
        2. 配合使用非同步處理 Async
    */

    /*
      快取失效策略 cache strategy
        1. 快取雪崩 catche avalanche => 預防所有key同時失效
        2. 快取擊穿 catche breakdon => 使用lock or semaphoreslim 實作 雙重檢查鎖 double-ckeck locking
    */

}
