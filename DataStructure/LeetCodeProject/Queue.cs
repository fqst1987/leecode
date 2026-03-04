namespace leecodeTest.Queue;

public class Solution
{
    public int[] MaxSlidingWindow1(int[] nums, int k) {
        if (nums.Length == 0) return new int[0];
    
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        for (int i = 0; i <= n - k; i++) { // 確保 i + k 不會越界
            int currentMax = nums[i];
            for (int j = i; j < i + k; j++) {
                if (nums[j] > currentMax) currentMax = nums[j];
            }
            result[i] = currentMax;
        }
        return result;
    }

    /// <summary>
    /// 滑移找最大值 leetcode 239 Sliding Window Maximum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        if (nums == null || nums.Length == 0) return new int[0];
    
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        // 使用 LinkedList 作為 Deque (存放 Index)
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < n; i++) {
            // 1. 踢掉尾部比現在數字小的（因為它們沒機會當最大值了）
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
                deque.RemoveLast();
            }

            // 2. 加入現在的索引
            deque.AddLast(i);

            // 3. 檢查頭部是否過期（索引距離 i 超過 k）
            if (deque.First.Value <= i - k) {
            deque.RemoveFirst();
            }

            // 4. 當視窗填滿 k 個後，開始記錄結果
            if (i >= k - 1) {
            result[i - k + 1] = nums[deque.First.Value];
            }
        }

        return result;
    }
}
