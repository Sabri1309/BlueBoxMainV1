using UnityEngine;

public class VenueMusicManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    public AudioClip[] tracks;

    private int currentTrackIndex = 0;
    private bool isPlaying = false;

    void Start()
    {
        if (tracks == null || tracks.Length == 0) return;

        foreach (AudioSource source in audioSources)
        {
            if (source == null) continue;
            source.clip = tracks[currentTrackIndex];
        }
    }

  public void SetVolume(float normalizedValue)
{
    float volume = Mathf.Clamp01(normalizedValue);

    foreach (AudioSource source in audioSources)
    {
        if (source != null)
            source.volume = volume;
    }
}

    public void TogglePlayPause()
    {
        if (tracks == null || tracks.Length == 0) return;

        if (isPlaying)
        {
            foreach (AudioSource source in audioSources)
            {
                if (source == null) continue;
                source.Pause();
            }

            isPlaying = false;
        }
        else
        {
            foreach (AudioSource source in audioSources)
            {
                if (source == null) continue;

                if (source.clip == null)
                    source.clip = tracks[currentTrackIndex];

                source.Play();
            }

            isPlaying = true;
        }
    }

    public void NextTrack()
    {
        if (tracks == null || tracks.Length == 0) return;

        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;

        foreach (AudioSource source in audioSources)
        {
            if (source == null) continue;

            source.Stop();
            source.clip = tracks[currentTrackIndex];

            if (isPlaying)
                source.Play();
        }
    }

    public void PreviousTrack()
    {
        if (tracks == null || tracks.Length == 0) return;

        currentTrackIndex--;
        if (currentTrackIndex < 0)
            currentTrackIndex = tracks.Length - 1;

        foreach (AudioSource source in audioSources)
        {
            if (source == null) continue;

            source.Stop();
            source.clip = tracks[currentTrackIndex];

            if (isPlaying)
                source.Play();
        }
    }
}