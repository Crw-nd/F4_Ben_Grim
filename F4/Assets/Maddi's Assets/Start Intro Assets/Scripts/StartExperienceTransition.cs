using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartExperienceTransition : MonoBehaviour
{
    [Header("Objects to Control")]
    public GameObject spinGroup;              // SpinGroup (Fantastic + 4 logos parent)
    public CanvasGroup marvelLogoCanvasGroup; // Marvel Studios logo CanvasGroup
    public CanvasGroup backgroundCanvasGroup; // Background CanvasGroup

    [Header("Spinning Settings")]
    public float spinSpeed = 20f;              // Slow spin speed (degrees per second)
    private bool isSpinning = false;

    [Header("Fade Settings")]
    public CanvasGroup fadeScreenOverlay;     // Black screen overlay
    public float fadeDuration = 2f;            // Duration of final fade to black
    public string nextSceneName;               // Scene to load

    private void Update()
    {
        if (isSpinning && spinGroup != null)
        {
            // Gently rotate around Y-axis (like turning head left-to-right)
            spinGroup.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.World);
        }
    }

    public void OnStartButtonPressed()
    {
        StartCoroutine(HandleStartExperience());
    }

    private IEnumerator HandleStartExperience()
    {
        // Step 1: Fade out Marvel logo smoothly
        yield return StartCoroutine(FadeOutCanvasGroup(marvelLogoCanvasGroup, 1f));

        // Step 2: Fade out background smoothly
        yield return StartCoroutine(FadeOutCanvasGroup(backgroundCanvasGroup, 1f));

        // Step 3: Start spinning (slow turn) after background fade
        isSpinning = true;

        // Step 4: Let it gently turn for a few seconds
        yield return new WaitForSeconds(3f);

        // Step 5: Fade to black
        yield return StartCoroutine(FadeInCanvasGroup(fadeScreenOverlay, fadeDuration));

        // Step 6: Load next scene
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator FadeOutCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        if (canvasGroup == null) yield break;

        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        canvasGroup.gameObject.SetActive(false);
    }

    private IEnumerator FadeInCanvasGroup(CanvasGroup canvasGroup, float duration)
    {
        if (canvasGroup == null) yield break;

        canvasGroup.gameObject.SetActive(true);
        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 1f, elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
