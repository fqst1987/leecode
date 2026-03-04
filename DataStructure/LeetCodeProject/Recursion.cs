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

public class TreeNodeSolutioin
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

    }

    /// <summary>
    /// leetcode 226 Invert Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode InverTree(TreeNode root)
    {

    }
}
