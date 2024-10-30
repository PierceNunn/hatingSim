using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemporaryText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        StartCoroutine(FadeTextToZeroAlpha(10f, text));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
