using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class NewBehaviourScript2 : MonoBehaviour
{
    /* Hashtable
    private void Awake() 
    {
        Hashtable hash = new Hashtable();

        Goblin goblin = new Goblin();
        Slime slime = new Slime();

        hash["Goblin"] = goblin;

        hash.Add("Slime", slime);
        hash.Add(1, "정수");
        hash.Add(1.2f, "실수");
        hash.Add("안녕하세요. 이세입니다.", "문자열");

        foreach ( object key in hash.Keys )
        {
            Debug.Log($"hash[{key}] = {hash[key]}");
        }

        if ( hash.ContainsKey("Slime") )
        {
            Debug.Log($"Slime 키 존재");
        }

        if ( hash.ContainsValue(goblin) )
        {
            Debug.Log($"{goblin} 값 존재");
        }

        Debug.Log($"Hashtable Count : {hash.Count}");

        hash.Remove("Slime");

        Debug.Log($"Hashtable Count : {hash.Count}");

        hash.Clear();

        Debug.Log($"Hashtable Count : {hash.Count}");
    }

    public class Goblin {}

    public class Slime {}


    /* Stack
    private void Awake() 
    {
        Stack stack = new Stack();

        for ( int i = 0; i < 5; ++ i )
        {
            stack.Push(i);
        }

        Debug.Log($"Stack Count : {stack.Count}");

        Debug.Log($"마지막에 추가된 요소 : {stack.Peek()}");

        Debug.Log($"Stack Count : {stack.Count}");

        object data = stack.Pop();
        Debug.Log($"스택에서 빠져나온 데이터 : {data}");

        Debug.Log($"Stack Count : {stack.Count}");

        stack.Clear();

        Debug.Log($"Stack Count : {stack.Count}");
    }


    /* Queue
    private void Awake() 
    {
        Queue queue = new Queue();

        for (int i = 0; i < 5; ++i)
        {
            queue.Enqueue(i);
        }

        Debug.Log($"Queue Count : {queue.Count}");

        Debug.Log($"현재 0번 요소 : {queue.Peek()}");

        Debug.Log($"Queue Count : {queue.Count}");

        object data = queue.Dequeue();
        Debug.Log($"큐에서 빠져나온 데이터 : {data}");

        Debug.Log($"Queue Count : {queue.Count}");

        queue.Clear();

        Debug.Log($"Queue Count : {queue.Count}");
    }
    


    /* ArrayList
    private void Awake() 
    {
        ArrayList arrayList = new ArrayList();

        Debug.Log(arrayList.Add(10));

        PrintArrayList(arrayList);

        arrayList.Insert(1, 100);

        PrintArrayList(arrayList);

        Collection<int> data = new Collection<int>();
        data.Add(1);
        data.Add(3);
        data.Add(2);
        arrayList.AddRange(data);

        PrintArrayList(arrayList);

        arrayList.Sort();

        PrintArrayList(arrayList);

        arrayList.Remove(10);

        PrintArrayList(arrayList);

        arrayList.RemoveAt(0);

        PrintArrayList(arrayList);

        arrayList.RemoveRange(0, 2);

        PrintArrayList(arrayList);

        arrayList.Clear();

        Debug.Log(arrayList.Count);
    }

    public void PrintArrayList(ArrayList list)
    {
        Debug.Log("==============================");

        for ( int i = 0; i < list.Count; ++ i )
        {
            Debug.Log($"list[{i}] = {list[i]}");
        }
    }
    */
}
