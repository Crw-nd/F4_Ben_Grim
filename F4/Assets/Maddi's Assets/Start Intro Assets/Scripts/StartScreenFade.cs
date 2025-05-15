using System.Collections;
using UnityEngine;

public class StartScreenFade : MonoBehaviour
{
    public CanvasGroup startScreenCanvasGroup; // Assign StartScreen_Canvas
    public CanvasGroup blackScreenCanvasGroup; // Assign BlackScreenOverlay
    public float fadeDelay = 2f;                // Delay after Marvel video
    public float fadeDuration = 2f;             // How long the black screen fades out

    private void Start()
    {
        // Set up initial states
        startScreenCanvasGroup.alpha = 0f;    // Start screen hidden
        blackScreenCanvasGroup.alpha = 1f;    // Black screen fully visible

        StartCoroutine(FadeInAfterDelay());
    }

    private IEnumerator FadeInAfterDelay()
    {
        // Wait after Marvel intro finishes
        yield return new WaitForSeconds(fadeDelay);

        float elapsedTime = 0f;

        // Fade out black screen
        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            blackScreenCanvasGroup.alpha = Mathf.Lerp(1f, 0f, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Snap final values
        blackScreenCanvasGroup.alpha = 0f;
        blackScreenCanvasGroup.gameObject.SetActive(false);

        // Fade in Start Screen using FadeManager
        FadeManager.Instance.FadeInCanvasGroup(startScreenCanvasGroup, 2f);
    }
}
