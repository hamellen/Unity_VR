using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager manager;


    SoundManager soundManager = new SoundManager();//�Ҹ� 
    TokenManager tokenManager = new TokenManager();
    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }
    public static TokenManager TOKENMANAGER { get { return manager.tokenManager; } }

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
