using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeType : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    public float delay = 0.1f;
    private string fullText;
    private string currentText;
    public float fadeOutWait;
    private TMPro.TextMeshProUGUI text;

    public bool StartTyping = false;
    public bool everyOther = true;
    private bool hasStarted = false;
    public bool fadeOut = true;
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        fullText = text.text;
        text.text = null;
        if (StartTyping)
        {
            StartCoroutine(StartTypeWriter());
        }
    }
    private void Update()
    {
        if (StartTyping && !hasStarted)
        {
            hasStarted = true;
            StartCoroutine(StartTypeWriter());
        }
    }

    private IEnumerator StartTypeWriter()
    {
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;

            if (i != fullText.Length && everyOther && currentText.Length % 2 == 0 && clips.Length != 0)
            {
                source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            }
            else if (i != fullText.Length && !everyOther && clips.Length != 0)
            {
                source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            }

            yield return new WaitForSeconds(delay);
        }
        if(fadeOut)
        {
            StartCoroutine(Delay(fadeOutWait));
        }
    }

    private IEnumerator Delay(float tempDelay = 0)
    {
        if (tempDelay != 0)
        {
            yield return new WaitForSeconds(tempDelay);
        }
        while (text.color.a > 0)
        {
            text.color -= new Color(0, 0, 0, 0.01f);
            yield return null;
        }
        yield return null;
    }
}
