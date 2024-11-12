using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip _morningMusic;
    [SerializeField] private AudioClip _eveningMusic;
    [SerializeField] private AudioSource _musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SetMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetMusic()
    {
        if(PlayerPrefs.GetInt("currentTime", 0) == 0)
        {
            _musicPlayer.clip = _morningMusic;
        }
        else
        {
            _musicPlayer.clip = _eveningMusic;
        }
    }
}
