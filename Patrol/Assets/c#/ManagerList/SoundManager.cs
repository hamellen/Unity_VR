using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager 
{
    public AudioSource[] audioSources = new AudioSource[(int)Define.Sound.MaxCount];


    public void Init()
    {

        GameObject root = GameObject.Find("Sound");

        if (root == null)
        {

            root = new GameObject { name = "Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i = 0; i < soundNames.Length - 1; i++)
            {


                GameObject go = new GameObject { name = soundNames[i] };
                audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;

            }

            audioSources[(int)Define.Sound.BGM].loop = true;
        }


    }
    public void Play(Define.Sound type, AudioClip clip, float pitch)
    {

        if (type == Define.Sound.BGM)
        {

            AudioSource audiosource = audioSources[(int)Define.Sound.BGM];
            if (audiosource.isPlaying)
            {
                audiosource.Pause();
            }
            audiosource.pitch = pitch;
            audiosource.clip = clip;
            audiosource.Play();
        }
    }

    public void Play_Position(Vector3 position, AudioClip clip, float pitch)
    {

      

        AudioSource.PlayClipAtPoint(clip, position, pitch);

    }

}
