namespace leecodeTest.Recursion;

//遞迴
public class RecursionSolution
{
    /// <summary>
    /// 階成數
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Factorial(int n)
    {
        if (n < 2) return n;

        return n * Factorial(n - 1);
    }

    /// <summary>
    /// 反轉字的遞迴
    /// </summary>
    /// <param name="s"></param>
    public string ReverseString(string s)
    {
        if (s.Length <= 1) return s;

        return ReverseString(s.Substring(1)) + s[0];
    }

    /// <summary>
    /// 費式數列 O(2^n)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int Fib(int n)
    {
        if (n <= 1) return n;

        return Fib(n - 2) + Fib(n - 1);
    }

    /*
     如何優化? 
     1. 記憶化遞迴 =>
     2. 迭代法 => 
     */

    /// <summary>
    /// leetcode 70 費式數列 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int ClimbStairs(int n)
    {
        /* Method 1 用迭代法
        
        if (n <= 2) return n;

        int a = 1;
        int b = 2;
        int current = 0;

        for (int i = 3; i <= n; i++)
        {
            current = a + b;
            a = b;
            b = current;
        }
        return b;
        */

        /*
         Method 2 記憶體優化寫法 O(2^n) => O(n), 空間 O(n)
         */
        int[] memo = new int[n + 1];
        return Helper(n, memo);
    }

    private int Helper(int n, int[] memo)
    {
        if (n <= 2) return n;

        if (memo[n] != 0)
        {
            return memo[n];
        }

        memo[n] = Helper(n - 1, memo) + Helper(n - 2, memo);

        return memo[n];
    }
}

/*
 1. Root : 根節點
 2. Leaf : left, right => if TreeNode.left = null, TreeNode.right = null => end
 3. 每一個Leaf 都是節點 => 遞迴
*/
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x) { val = x; }
}

public class DFSSolutioin
{
    /// <summary>
    /// leetcode 104 Maximum Depth of Binary Tree DFS 的最基礎題
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        int leftHeight = MaxDepth(root.left);

        int rightHeight = MaxDepth(root.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    /// <summary>
    /// leetcode 111 Minimum Depth of Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int MinDepth(TreeNode root)
    {
        if (root == null) return 0;

        if (root.left == null)
        {
            return MinDepth(root.right) + 1;
        }

        if (root.right == null)
        {
            return MinDepth(root.left) + 1;
        }

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }

    /// <summary>
    /// leetcode 226 Invert Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode InvertTree(TreeNode root)
    {
        /*
         Method 1 手動用stack來做
        
        if (root == null) return null;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();

            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;

            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);
        }

        return root;
        */

        /*
         Method 2 DFS方法
        */
        if (root == null) return null; // 終止條件

        // 1. 交換左右
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        // 2. 遞迴下去
        InvertTree(root.left);
        InvertTree(root.right);

        return root;

    }


    /// <summary>
    /// leetcode 113 Path Sum II
    /// </summary>
    /// <param name="node"></param>
    /// <param name="targetSum"></param>
    /// <returns></returns>
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        var result = new List<IList<int>>();
        Leetcode113(root, targetSum, new List<int>(), result);
        return result;
    }

    private void Leetcode113(TreeNode node, int target, List<int> path, List<IList<int>> result)
    {
        if (node == null) return;

        path.Add(node.val);

        if (node.left == null && node.right == null && target == node.val)
        {
            result.Add(new List<int>(path));
        }
        else 
        {
            Leetcode113(node.left, target - node.val, path, result);
            Leetcode113(node.right, target - node.val, path, result);
        }

        path.RemoveAt(path.Count - 1);
    }

    /// <summary>
    /// leetcode 124 Binary Tree Maximum Path Sum
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public int MaxPathSum(TreeNode root)
    {
        CalculateContribution(root);
        return maxSum;
    }

    private int maxSum = int.MinValue;

    private int CalculateContribution(TreeNode node)
    {
        if (node == null) return 0;

        int leftContribution = Math.Max(0, CalculateContribution(node.left));
        int rightContribution = Math.Max(0, CalculateContribution(node.right));

        int current = node.val + leftContribution + rightContribution;

        maxSum = Math.Max(maxSum, current);

        return node.val + Math.Max(leftContribution, rightContribution);
    }
}

/*
 BFS - Breadth-First Serach 廣度優先搜尋
 用 Queue => FIFO 
 找最短路徑 Shortest Path
 層級遍歷 Level Order
 BFS => 太廣會 outofmemory, DFS => 太深會 StackOverflow, 如何取捨?
*/
public class BFSSolution
{
    /// <summary>
    /// leetcode 102 Binary Tree Level Order Traversal
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();

        if (root == null) return result;

        result.Add(new List<int> { root.val });

        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                TreeNode currentNode = queue.Dequeue();
                currentLevel.Add(currentNode.val);

                if (currentNode.left != null)
                    queue.Enqueue(currentNode.left);
                if (currentNode.right != null)
                    queue.Enqueue(currentNode.right);             
            }

            result.Add(currentLevel); //回這層的數量
        }

        return result;
    }
}

