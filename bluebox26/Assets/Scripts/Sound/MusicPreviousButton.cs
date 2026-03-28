using UnityEngine;

public class MusicPreviousButton : MonoBehaviour
{
    public VenueMusicManager musicManager;

    public void Press()
    {
        if (musicManager != null)
            musicManager.PreviousTrack();
    }
}