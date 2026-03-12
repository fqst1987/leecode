namespace leecodeTest.Basic
{
    public class Basic
    {
        public void DrowTriangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n-i; j++)
                {
                    Console.WriteLine(" ");
                }

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.WriteLine("*");
                }

                Console.WriteLine();
            }
        }

        public void DrowDiamond(int n)
        {
            // 上半部 (包含中間)
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++) Console.Write(" ");
                for (int k = 1; k <= (2 * i - 1); k++) Console.Write("*");
                Console.WriteLine();
            }

            // 下半部 (從 n-1 開始倒回去)
            for (int i = n - 1; i >= 1; i--)
            {
                for (int j = 1; j <= n - i; j++) Console.Write(" ");
                for (int k = 1; k <= (2 * i - 1); k++) Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
