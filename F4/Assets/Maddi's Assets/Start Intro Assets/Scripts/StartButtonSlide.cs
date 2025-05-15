using System.Collections;
using UnityEngine;

public class StartButtonSlide : MonoBehaviour
{
    public RectTransform buttonTransform; // Drag your StartButton RectTransform here
    public Vector2 startPosition = new Vector2(0, -400); // Offscreen position
    public Vector2 targetPosition = new Vector2(0, 100); // Where the button should land
    public float delayBeforeSlide = 5f; // Wait time before sliding (fadeDelay + fadeDuration)
    public float slideDuration = 1.5f; // How long the slide takes

    private void Start()
    {
        buttonTransform.anchoredPosition = startPosition;
        StartCoroutine(SlideButtonIn());
    }

    private IEnumerator SlideButtonIn()
    {
        // Wait until fade is done
        yield return new WaitForSeconds(delayBeforeSlide);

        float elapsedTime = 0f;

        while (elapsedTime < slideDuration)
        {
            buttonTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonTransform.anchoredPosition = targetPosition; // Snap exactly to final position
    }
}
