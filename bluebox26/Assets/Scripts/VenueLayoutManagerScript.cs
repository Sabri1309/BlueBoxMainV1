using UnityEngine;

public class VenueLayoutManager : MonoBehaviour
{
    public GameObject weddingLayout;
    public GameObject concertLayout;
    public GameObject conferenceLayout;

    void Start()
    {
        HideAllLayouts();
    }

    public void HideAllLayouts()
    {
        if (weddingLayout != null) weddingLayout.SetActive(false);
        if (concertLayout != null) concertLayout.SetActive(false);
        if (conferenceLayout != null) conferenceLayout.SetActive(false);
    }

    public void SetWedding()
    {
        HideAllLayouts();

        if (weddingLayout != null)
            weddingLayout.SetActive(true);
    }

    public void SetConcert()
    {
        HideAllLayouts();

        if (concertLayout != null)
            concertLayout.SetActive(true);
    }

    public void SetConference()
    {
        HideAllLayouts();

        if (conferenceLayout != null)
            conferenceLayout.SetActive(true);
    }
}