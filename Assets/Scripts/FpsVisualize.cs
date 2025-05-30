using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsVisualize : MonoBehaviour
{
    private TMPro.TMP_Text fpsText;

    void Awake()
    {
        fpsText = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        // Her framede FPS'i hesapla ve göster
        float fps = 1f / Time.unscaledDeltaTime;
        fpsText.text = string.Format("FPS: {0:F1}", fps);
    }
}
