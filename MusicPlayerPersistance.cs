using UnityEngine;

public class MusicPlayerPersistance : MonoBehaviour
{
    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayerPersistance>().Length;
        if (numMusicPlayers > 1) { Destroy(gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }
}
