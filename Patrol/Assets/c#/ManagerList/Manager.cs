using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager manager;


    SoundManager soundManager = new SoundManager();//소리 
    TokenManager tokenManager = new TokenManager();
    public static SoundManager SOUNDMANAGER { get { return manager.soundManager; } }
    public static TokenManager TOKENMANAGER { get { return manager.tokenManager; } }

    static void Init()
    {



        manager = FindObjectOfType<Manager>();
       
        manager.soundManager.Init();//사운드 매니저 초기화

       




    }



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Init();
        if (manager != null)
        {
            Debug.Log("매니저 로드 성공");
        }
    }

   
}
