using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Auto_Gen : MonoBehaviour
{
    public GameObject spawn_prefab;
    public int current_object;
    public int max_object;
    public int spawn_intarval;

    CancellationTokenSource cts;

    public Queue<GameObject> spawn_list = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cts = new CancellationTokenSource();//���ο� ��ū ����

       
    }

    public async UniTaskVoid Generate_Prefab()
    {

        while (spawn_list.Count < max_object)
        {
            await UniTask.Delay(spawn_intarval * 1000);
            GameObject go=Instantiate(spawn_prefab, transform);
            spawn_list.Enqueue(go);
            go.transform.parent = transform;

        }

        //if (spawn_list.Count == max_object)
        //{ //UniTask �ߴ� ��Ű�� waitutil ����ؼ� ���� �簳 

        //    Manager.TOKENMANAGER.RefreshToken(ref cts);//����
        //    await UniTask.WaitUntil(() => spawn_list.Count < max_object);
        //    Generate_Prefab().Forget();
        //}
    }

    public void GameStart() {

        Generate_Prefab().Forget();
    }

    public void Dequeue()
    {
        spawn_list.Dequeue();
    }
}
