using UnityEngine;
using UnityEngine.Video;

public class ShowStartScreen : MonoBehaviour
{
    // References to the objects we want to show after the intro
    public GameObject theFantastic; 
    public GameObject buttonLogo;
    public GameObject marvelLogoImage; // NEW: Marvel Studios logo UI image

    // Reference to the VideoPlayer component
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Hide everything at the beginning
        theFantastic.SetActive(false);
        buttonLogo.SetActive(false);
        marvelLogoImage.SetActive(false);

        // Subscribe to the video player's "loopPointReached" event (when video finishes)
        videoPlayer.loopPointReached += ShowStartScreenElements;
    }

    // This function will be called automatically when the video finishes
    void ShowStartScreenElements(VideoPlayer vp)
    {
        // Show the hidden elements
        theFantastic.SetActive(true);
        buttonLogo.SetActive(true);
        marvelLogoImage.SetActive(true);

        // Disable the VideoPlayer so it's not visible anymore
        videoPlayer.gameObject.SetActive(false);
    }
}
