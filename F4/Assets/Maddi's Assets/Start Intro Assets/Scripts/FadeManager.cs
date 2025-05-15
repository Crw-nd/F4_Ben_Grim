using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FadeInCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        StartCoroutine(FadeInCanvasGroupCoroutine(canvasGroup, duration));
    }

    private IEnumerator FadeInCanvasGroupCoroutine(CanvasGroup canvasGroup, float duration)
    {
        float time = 0f;
        canvasGroup.alpha = 0f; // start fully transparent
        canvasGroup.gameObject.SetActive(true);

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f; // fully visible at the end
    }
}
