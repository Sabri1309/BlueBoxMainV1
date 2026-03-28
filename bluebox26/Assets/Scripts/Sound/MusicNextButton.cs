using UnityEngine;

public class MusicNextButton : MonoBehaviour
{
    public VenueMusicManager musicManager;

    public void Press()
    {
        if (musicManager != null)
            musicManager.NextTrack();
    }
}