// 這邊記錄網路上看到關於 C# 的觀念部分的題目

/*
  1. IEnumerable 與 IQueryable 的差異
    IEnumerable : Linq to Objects, Client-side(記憶體內), 運作方式 : 將資料全部撈在記憶體內之後, 在記憶體內做篩選。
    IQueryable : Linq to SQL, Server-side(資料庫端), 運作方式 : 將語法轉換成SQL語法, 到資料庫裏面做搜尋, ToList() or ToArray() 這種才是再轉換成 IEnumerable 


  2. interface 與 abstract 的差異
    特性	  抽象類別 (Abstract Class)	介面 (Interface)
    關鍵字	  abstract	                interface
    本質	是一個類別 (Class)	是一個合約 (Contract)
    繼承限制	單一繼承 (只能繼承一個類別)	多重實作 (可以實作多個介面)
    成員內容	可以有欄位、建構子、實作邏輯	只能定義簽章（C# 8.0 後可有預設實作，但不建議濫用）
    存取修飾詞	可以是 public, protected, private 等	預設通常是 public
    設計邏輯	Is-A (它是什麼，例如：貓是動物)	Can-Do (它能做什麼，例如：它會飛)

    abstract : 定義身分和共用邏輯
    interface : 定義合約和行為規範

  3. Restful API 的定義 :

  4. SOLID 原則 : 

  5. Singleton, Scoped, Transient 的差異 :
    生命週期 : 
    Singleton : 單例, 從程式啟動到結束 只會有一個實例. ex : catche service 快取服務. 
    Scoped : 範圍, 在同一個 HTTP Request 內共用同一個實例
    Transient :　順時, 每次注入時都產生一個新的實例. ex : 

  6. LRU Catche => Least Recently Used
     Dictionary + Doubly Linked List
     為什麼要雙向不能單向 雙向可以知道前後是什麼只需要 O(1), 只有單向 還是O(n)

     public class Node 
     {
       public int Key;
       public int Value;
       public Node Prev;
       public Node Next;
     }

     如何取出
     1. 前一個對接後一個 兩頭都要給定
     node.Prev.Next = node.Next;
     node.Next.Prev = node.Prev;

     2. 移至頭部
     node.Next = Head.Next;
     node.Prev = Head;

     node.Next.Prev = node;
     Head.Next = node;
*/
