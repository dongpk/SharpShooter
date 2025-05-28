using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TakeDamageEffect : MonoBehaviour
{
    [Header("Effect Settings")]
    [Range(0,1)] public float maxIntensity = 0.8f;
    public float holdTime = 0.3f;
    public float fadeSpeed = 2f;

    Volume   volume;
    Vignette vignette;
    Coroutine runningCo;

    void Awake()
    {
        volume = GetComponent<Volume>();
        if (!volume || !volume.profile.TryGet(out vignette))
        {
            Debug.LogError("Không tìm thấy Vignette trong Volume!"); 
            enabled = false; return;
        }

        // Bật override
        vignette.intensity.overrideState = true;
        vignette.color.overrideState     = true;
        vignette.color.value             = Color.red;
        vignette.intensity.value         = 0f;
    }

    /// <summary>Gọi hàm này mỗi khi player dính sát thương.</summary>
    public void Play()
    {
        // Nếu hiệu ứng cũ còn đang chạy, dừng lại để chạy hiệu ứng mới
        if (runningCo != null) StopCoroutine(runningCo);
        runningCo = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        vignette.intensity.value = maxIntensity;

        yield return new WaitForSeconds(holdTime);

        while (vignette.intensity.value > 0f)
        {
            vignette.intensity.value -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        vignette.intensity.value = 0f;
        runningCo = null;
    }
}
