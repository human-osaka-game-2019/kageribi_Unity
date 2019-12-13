using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : IEnumerable, System.IDisposable
{

    class Item // Item Class
    {
        public bool active;  //使用中の状態確認
        public GameObject gameObject;
    }

    Item[] table;
    //列挙子　基本　再定義

    public IEnumerator GetEnumerator()
    {
        if (table == null)
            yield break;

        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            if (item.active)
                yield return item.gameObject;
        }
    }

    //Memory Pool Create
    // original : 原本Source
    // count : Max Pool 個数

    public void Create(Object original, int count)
    {
        Dispose();
        table = new Item[count];

        for (int i = 0; i < count; i++)
        {
            Item item = new Item();
            item.active = false;
            item.gameObject = GameObject.Instantiate(original) as GameObject;
            item.gameObject.SetActive(false);
            table[i] = item;
        }
    }

    // 新しいItem要請　－　運休状態の客体を返却する

    public GameObject NewItem()
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

    // Itemの使用終了

    public void RemoveItem(GameObject gameObject)
    {
        if (table == null || gameObject == null)
            return;
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            if (item.gameObject == gameObject)
            {
                item.active = false;
                item.gameObject.SetActive(false);
                break;
            }
        }
    }

    //全てのItem使用終了　－　すべての客体を運休する

    public void ClearItem()
    {
        if (table == null)
            return;
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            if (item != null && item.active)
            {
                item.active = false;
                item.gameObject.SetActive(false);
            }
        }
    }

    // Memory Pool 削除

    public void Dispose()
    {
        if (table == null)
            return;
        int count = table.Length;

        for (int i = 0; i < count; i++)
        {
            Item item = table[i];
            GameObject.Destroy(item.gameObject);
        }

        table = null;
    }
}
