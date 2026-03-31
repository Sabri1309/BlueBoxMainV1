using UnityEngine;

public class LayoutButton : MonoBehaviour
{
    public VenueLayoutManager layoutManager;

    public enum LayoutType
    {
        Wedding,
        Concert,
        Conference
    }

    public LayoutType layoutType;

    public void Press()
    {
        if (layoutManager == null) return;

        switch (layoutType)
        {
            case LayoutType.Wedding:
                layoutManager.SetWedding();
                break;

            case LayoutType.Concert:
                layoutManager.SetConcert();
                break;

            case LayoutType.Conference:
                layoutManager.SetConference();
                break;
        }
    }
}