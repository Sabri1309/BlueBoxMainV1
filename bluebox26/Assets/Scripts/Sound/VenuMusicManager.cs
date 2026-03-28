using UnityEngine;

public class VenueMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] tracks;

    private int currentTrackIndex = 0;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (tracks != null && tracks.Length > 0)
            audioSource.clip = tracks[currentTrackIndex];
    }

    public void SetVolume(float normalizedValue)
    {
        if (audioSource == null) return;
        audioSource.volume = Mathf.Clamp01(normalizedValue);
    }

    public void TogglePlayPause()
    {
        if (audioSource == null || tracks == null || tracks.Length == 0) return;

        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            if (audioSource.clip == null)
                audioSource.clip = tracks[currentTrackIndex];

            if (audioSource.time > 0f)
                audioSource.UnPause();
            else
                audioSource.Play();
        }
    }

    public void NextTrack()
    {
        if (audioSource == null || tracks == null || tracks.Length == 0) return;

        bool wasPlaying = audioSource.isPlaying;

        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        audioSource.clip = tracks[currentTrackIndex];

        if (wasPlaying)
            audioSource.Play();
    }

    public void PreviousTrack()
    {
        if (audioSource == null || tracks == null || tracks.Length == 0) return;

        bool wasPlaying = audioSource.isPlaying;

        currentTrackIndex--;
        if (currentTrackIndex < 0)
            currentTrackIndex = tracks.Length - 1;

        audioSource.clip = tracks[currentTrackIndex];

        if (wasPlaying)
            audioSource.Play();
    }

    public void StopMusic()
    {
        if (audioSource == null) return;
        audioSource.Stop();
    }
}