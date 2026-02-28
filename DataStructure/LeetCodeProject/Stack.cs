/*
    Stack

    Basic :
    1. Last In First Out (LIFO)


    c# 
    
    Property :
    1. Push : 將一個新元素放在stack的最後一筆
    2. Pop : 取出stack的最新一筆
    3. Peek : 查看stack中的某一筆元素 index

    Trap :
    1. overflow 數字溢位
    2. return type different 資料回傳型態不同
    3. ListNode 是 reference value 傳址
    
    常用的實作
    1. 上一頁 : 開新網頁 = Stack.Push(new url)
    2. Undo : 每一次變更 = Push 變更到stack中, 按 undo 的時候 = Pop 最新的 stack 取出

    面試重點: 
    1. 處理對稱性, 嵌套關係
*/

namespace LeetCodeProject.Stack;

public class Stack
{
    public bool IsSymmetryWithoutPriority(string s){
        
        //如果長度為基數 一定不對稱
        if (s.Length % 2 != 0) return false;
        
        Dictionary<char, char> map = new Dictionary<char, char>
        {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
            if (map.ContainsKey(c))
            {
                if (stack.Count == 0 || stack.Pop() != map[c])
                    return false;
                
            }
            else
            {
                stack.Push(c);
            }
        }
            
        return stack.Count == 0;
    }
}  


