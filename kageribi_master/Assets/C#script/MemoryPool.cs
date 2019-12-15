using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : IEnumerable, System.IDisposable
{
    //-------------------------------------------------------------------------------------
    // Item Class
    //-------------------------------------------------------------------------------------
    class Item
    {
        public bool active;// Object使用中の判断をする
        public GameObject gameObject;// 保管するObject
    }

    // 上のItem Classを配列で宣言（つまり、多数を保管できる）
    Item[] table;

    //------------------------------------------------------------------------------------
    // 列挙子　基本　再定義（でも、使うことはない　使う部分はForeachらしいがここには欠点があるらしい）
    //------------------------------------------------------------------------------------
    public IEnumerator GetEnumerator()
    {
        if (table == null)   // もし、tableが客体化されてないなら？
            yield break;   // 関数からBreak

        // tableが存在すればここから実行   
        // countは tableの ながさ（つまり、配列の大きさ)
        int count = table.Length;

        for (int i = 0; i < count; i++)   // 総 countほど反復
        {
            Item item = table[i];
            // itemに tableの i番に該当する客体を代入
            if (item.active)// itemが使用中なら
                yield return item.gameObject;// 現 itemのObjectをReturn

        }
    }

    //-------------------------------------------------------------------------------------
    // MemoryPool 生成
    // original : 事前に生成する原本ソース
    // count : Poolの最高個数
    //-------------------------------------------------------------------------------------
    public void Create(Object original, int count)
    {
        Dispose();   // MemoryPool初期化
        table = new Item[count];// countほど配列を生成

        for (int i = 0; i < count; i++)// countほど反復
        {
            Item item = new Item();
            item.active = false;
            item.gameObject = GameObject.Instantiate(original) as GameObject;
            // originalを GameObject 形式に item.gameObjectに保管
            item.gameObject.SetActive(false);
            // SetActiveは活性化関数であるが、メモリにだけ上げるのでFalseで保管
            table[i] = item;
        }
    }

    //-------------------------------------------------------------------------------------
    // 新しいItem要請 - 運休中の客体を返還する
    //-------------------------------------------------------------------------------------
    public GameObject NewItem()// GetEnumerator()と似ている
    {
        if (table == null)
            return null;
        int count = table.Length;
        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            if (item.active == false)
            {
                item.active = true;
                item.gameObject.SetActive(true);
                return item.gameObject;
            }
        }

        return null;
    }

    //--------------------------------------------------------------------------------------
    // Item使用終了 - 使用中の客体を運休させる
    // gameOBject : NewItemで得た客体
    //--------------------------------------------------------------------------------------
    public void RemoveItem(GameObject gameObject)
    {
        // tableが客体化されなかったり、媒介変数で来る gameObjectがなかったら
        if (table == null || gameObject == null)
            return;// 関数 Break

        // tableが存在したり、 媒介変数で来る gameObjectがあるならここから実行
        // countは tableの長さ(配列の大きさ)
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            // gameObjectと itemの gameObjectが同じなら
            if (item.gameObject == gameObject)
            {
                // active 変数を falseに
                item.active = false;
                // そして、gameObjectを非活性化する
                item.gameObject.SetActive(false);
                break;
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // 全てのItemを使用終了 - 全ての客体を運休させる
    //--------------------------------------------------------------------------------------
    public void ClearItem()
    {
        // tableが客体化されなかったら
        if (table == null)
            return;

        // tableが存在するなら
        // countは tableの長さ(配列の大きさ)
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            // itemが空ではなく活性化されてたら
            if (item != null && item.active)
            {
                // 非活性化処理をします
                item.active = false;
                item.gameObject.SetActive(false);
            }
        }
    }

    //--------------------------------------------------------------------------------------
    // MemoryPool 削除
    //--------------------------------------------------------------------------------------
    public void Dispose()
    {
        // tableが客体化されなかったら
        if (table == null)
            return;

        // tableが存在するなら
        // countは tableの長さ(配列の大きさ)
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            GameObject.Destroy(item.gameObject);
            //MemoryPoolを削除することだからすべてのObjectをDestroyする
        }
        table = null;
    }

}

