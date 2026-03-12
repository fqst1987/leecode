/*
    Linked List

    Basic :
    1.node => data : the actual value stored
    2.next => a pointer to the next node in the list

    VS Array :
    1. across memory
    2. easily to resize by add or remove the node
    3. re-plug for insertion or deletion

    c# 
    ListNode

    public class ListNode {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

    Trap :
    1. overflow 數字溢位
    2. return type different 資料回傳型態不同
    3. ListNode 是 reference value 傳址
    
    常用的實作
    1. 上一頁/下一頁 : doubly linked list
    2. LRU Cache 快取淘汰機制 : 這是開發高併發系統常見的技術。為了在 O(1) 時間內刪除最舊的資料並加入新資料，通常會結合 Dictionary (用於快速查詢) 和 Doubly Linked List (用於快速搬移節點)
    3. 利用快慢指標 O(1)空間 就可以解決大數據或高併發環境 節省記憶體量

    面試重點: 
    1. dummyNode (啞節點)
    2. Two Pointers (雙指標) slow fast
    3. 畫圖指向指標 用於說明
    4. 邊界條件處理 : 是否有考慮到head == null or 只有一個節點的情況
    5. 記憶體概念 .next 是 reference value
*/
using System.Collections.Generic;

    public class ListNode {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }

        /// <summary>
        /// 兩個ListNode相加
        /// Hint : 利用直式加法來做運算
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2){
            ListNode dummyNode = new ListNode(0)
            ListNode currentNode = dummyNode;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0){
                int sum = carry;

                if (l1 != nnull){
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null){
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                currentNode.next = new ListNode(sum % 10);
                currentNode = currentNode.next;
            }

            return dummyNode.next;
        }

        /// <summary>
        /// 刪除ListNode中重複的值 並以順序排列傳出 => 其實就是跳出相同的 => 沒有排序下
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicatesUnsorted(ListNode head){
            if (head == null) return null;

            HashSet<int> seen = new HashSet<int>();
            ListNode currentNode = head;
            ListNode prevNode = null;

            while (currentNode != null){
                if (seen.Contains(currentNode.val))
                    prevNode.next = currentNode.next;
                else{
                    seen.Add(currentNode.val);
                    prevNode = currentNode;
                }
                currentNode = currentNode.next;
            }

            return head;
        }

        /// <summary>
        /// 刪除ListNode中重複的值 並以順序排列傳出 => 其實就是跳出相同的 => 有排序下
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head) {
            if (head == null) return null;

            ListNode current = head;

            while (current != null && current.next != null) {
                if (current.val == current.next.val) {
                    current.next = current.next.next;
                } else {

                    current = current.next;
                }
            }

            return head; 
        }

        /// <summary>
        /// 查看這個ListNode是否有環 用快慢之間的差距是否相遇 
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head) {
            // 如果只有 0 或 1 個節點，不可能成環
            if (head == null || head.next == null) {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head; 

            while (fast != null && fast.next != null) {
                slow = slow.next;          
                fast = fast.next.next;  

                if (slow == fast) {
                    return true;
                }
            }
            return false;
        }   

        /// <summary>
        /// 查看這個ListNode是否有環 用快慢之間的差距是否相遇 且環的開頭是哪一個節點 Floyd's Cycle-Finding Algorithm
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool DetectCycle(ListNode head){
            if (head == null || head.next == null) return null;

            ListNode slow = head;
            ListNode fast = head;

            // 第一步：尋找相遇點
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast) { // 兩者相遇，代表有環
                    // 第二步：找入口
                    ListNode ptr1 = head;
                    ListNode ptr2 = slow;

                    while (ptr1 != ptr2) {
                        ptr1 = ptr1.next;
                        ptr2 = ptr2.next;
                    }
                    return ptr1; // 返回環的入口
                }
            }

            return null; // fast 走到盡頭，代表無環
        }
  
        /// <summary>
        /// 刪除倒數第N個節點
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n) {           
            ListNode dummy = new ListNode(0, head);
            ListNode fast = dummy;
            ListNode slow = dummy;

            // Fast 先走 n 步
            for (int i = 0; i <= n; i++) fast = fast.next;

            // 同時走，直到 Fast 到底
            while (fast != null) {
                slow = slow.next;
                fast = fast.next;
            }

            // 跳過目標節點
            slow.next = slow.next.next;
            return dummy.next;
        }       

        /// <summary>
        /// 合併兩個已排序的串列 (Merge Two Sorted Lists)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {

            ListNode dummy = new ListNode(0);
            ListNode curr = dummy;

            // 2. 當兩條鏈都還有東西時，進行比較
            while (l1 != null && l2 != null) {
                if (l1.val <= l2.val) {
                    curr.next = l1;
                    l1 = l1.next; 
                } else {
                    curr.next = l2;
                    l2 = l2.next; 
                }
                curr = curr.next; 
            }

            curr.next = l1 ?? l2; 

            return dummy.next;
        }       

        /// <summary>
        /// 尋找中間節點 (Middle of the Linked List)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head) {
            ListNode slow = head;
            ListNode fast = head;

            // 只要 Fast 還能往前衝兩步，就繼續走
            while (fast != null && fast.next != null) {
                slow = slow.next;       // 走 1 步
                fast = fast.next.next;  // 走 2 步
            }

            return slow; // 這就是中點！
        }

        /// <summary>
        /// 查看是不是回文（Palindrome）
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head) {
            if (head == null || head.next == null) return true;

            // 1. 找中點 (用剛學過的快慢指標)
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            // 2. 反轉後半段 (用最常考的反轉邏輯)
            ListNode prev = null;
            ListNode curr = slow;
            while (curr != null) {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }

            // 3. 比對前半段與後半段
            ListNode p1 = head;
            ListNode p2 = prev; // 反轉後的起點
            while (p2 != null) {
                if (p1.val != p2.val) return false;
                p1 = p1.next;
                p2 = p2.next;
            }

            return true;
        }
    }
