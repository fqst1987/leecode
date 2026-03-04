

namespace leecodeTest.Dictionary;

/*
    1. 雜湊衝突
    2. 時間複雜度
    3. 與HashSet的差別在哪
*/
public class DictionarySolution
{
    /// <summary>
    /// leetcode 1 
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int targetremain = target - nums[i];
            
            if (dict.ContainsKey(targetremain))
            {
                return new int[] { dict[targetremain], i}; 
            }

            if (!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
        }

        return new int[0];
    }

    /// <summary>
    /// leetcode 169 
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement(int[] nums)
    {
        /* Method 1 暴力硬算 (O(n))
        int n = nums.Length;

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(nums[i]))
            {
                dict.Add(nums[i], 1);
            }
            else
            {
                dict[nums[i]] = dict[nums[i]] += 1;
            }
        }
        var maxKvp = dict.MaxBy(kvp => kvp.Value);

        return maxKvp.Key;
        */
        /* Method 只算超過一半的就停 時間複雜度 O(n/2) => O(n), 空間複雜度 O(n)
        int n = nums.Length;
        int half = n / 2;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        
        foreach(int num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }

            if (dict[num] > half)
            {
                return num;
            }
        }

        return -1;
        */
        /* Boyer-Moore Voting Algorithm
        */
        int a = 0;
        int b = 0;
        foreach (int num in nums)
        {
            if (b == 0)
            {
                a = num;
            }

            if (num == a)
                b++;
            else
                b--;

        }
        return a;
    }

    /// <summary>
    /// leetcode 3
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring(string s)
    {
        /* Method 1 Hasset + 左右指標 
        HashSet<char> hashSet = new HashSet<char>();
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (hashSet.Contains(s[right]))
            {
                hashSet.Remove(s[left]);
                left++;
            }

            hashSet.Add(s[right]);

            maxLen = Math.Max(maxLen, right - left + 1);    
        }

        return maxLen;
        */

        /* Method 2 使用dictionary 去紀錄 char 的位置 當有重複的時候 左指標跳到目前char的位置 + 1
        */

        if (string.IsNullOrEmpty(s)) return 0;

        Dictionary<char, int> dict = new Dictionary<char, int>();
        int maxLen = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];

            if (dict.ContainsKey(currentChar) && dict[currentChar] >= left)
            {
                left = dict[currentChar] + 1;
            }

            dict[currentChar] = right;

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

    /// <summary>
    /// leettcode 49 Group Anagrams
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        /* Method 1 讓每個字串的char 去排序 然後 再加入到字典裏面
        */
        List<List<string>> result = new List<List<string>>();

        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach (string s in strs)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if (!map.TryGetValue(key, out List<string> group))
            {
                group = new List<string>(); 
                map[key] = group;
            }

            group.Add(s);
        }

        return map.Values.Cast<IList<string>>().ToList();
        
    }

    /// <summary>
    /// leetcode 149 哪些點在同一條線上 => 斜率 用 GCD來化簡分數
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n <= 2) return n;

        int maxPoints = 0;

        for (int i = 0; i < n; i++)
        {
            Dictionary<string, int> sloopMap = new Dictionary<string, int>();

            int localMax = 0;

            for (int j = i + 1; j < n; j++)
            {
                int dx = points[j][0] - points[i][0];
                int dy = points[j][1] - points[i][1];

                int common = GCD(dx, dy);
                string key = (dx/common) + "_" + (dy/common);

                if (sloopMap.ContainsKey(key))
                    sloopMap[key]++;
                else
                    sloopMap[key] = 1;

                localMax = Math.Max(localMax, sloopMap[key]);
            }
            maxPoints = Math.Max(maxPoints, localMax + 1);
        }

        return maxPoints;
    }

    //求最大公因數 輾轉相除法
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}

/*
  LRU 的探討 Least, Rescently Used
  1. Doubly Linked List 雙向鏈結串列 
  2, Moved to head 
    a. Remove Node
    b. Add to head
leetcode 146 
*/
public class LRUCache
{
    public class Node
    {
        public int key, value;
        public Node prev, next;
        public Node(int k = 0, int v = 0) { key = k; value = v; }

    }

    private Dictionary<int, Node> map;
    private int capacity;
    private Node head, tail;

    public LRUCache(int capacity) 
    {
        this.capacity = capacity;
        map = new Dictionary<int, Node>();

        head = new Node();
        tail = new Node();
        head.next = tail;
        tail.prev = head;   
    }
    
    public int Get(int key)
    {
        if (!map.TryGetValue(key, out Node node)) return -1;

        MoveToHead(node);
        return node.value;
    }

    public void Put(int key, int value)
    {
        if (map.TryGetValue(key, out Node node))
        {
            node.value = value;
            MoveToHead(node);
        }
        else
        {
            Node newNode = new Node(key, value);
            map[key] = newNode;
            AddToHead(newNode);

            if (map.Count > capacity)
            {
                Node last = RemoveTail();
                map.Remove(last.key);
            }
        }
    }

    private void AddToHead(Node node)
    {
        node.prev = head;
        node.next = head.next;

        head.next.prev = node;
        head.next = node;
    }

    private void RemoveNode(Node node)
    {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }

    private void MoveToHead(Node node)
    {
        RemoveNode(node);
        AddToHead(node);
    }

    private Node RemoveTail()
    {
        Node res = tail.prev;
        RemoveNode(res);
        return res;
    }
}
