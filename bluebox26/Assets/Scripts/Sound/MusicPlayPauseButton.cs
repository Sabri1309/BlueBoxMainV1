using UnityEngine;

public class MusicPlayPauseButton : MonoBehaviour
{
    public VenueMusicManager musicManager;

    public void Press()
    {
        if (musicManager != null)
            musicManager.TogglePlayPause();
    }
}