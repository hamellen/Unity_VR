using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager manager;


    SoundManager soundManager = new SoundManager();//�Ҹ� 

    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }

    static void Init()
    {



        manager = FindObjectOfType<Manager>();
       
        manager.soundManager.Init();//���� �Ŵ��� �ʱ�ȭ
        





    }



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();
        if (manager != null)
        {
            Debug.Log("�Ŵ��� �ε� ����");
        }
    }

   
}
