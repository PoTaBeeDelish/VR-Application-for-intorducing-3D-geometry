using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Highlighting : MonoBehaviour
{
    public GameObject HighlightingPrefab;
    public float HighlightInterval = 3f;
    //butuh pasangin waktu biar loopingnya berdasarkan waktu

    private Coroutine highlightCoroutine = null;

    IEnumerator Highlights()
    {
        foreach (Transform obj in HighlightingPrefab.transform)
        {
            //hightlight
            obj.gameObject.SetActive(true);

            //nunggu
            yield return new WaitForSeconds(HighlightInterval);

            //matiin
            obj.gameObject.SetActive(false);
        }
    }

    public void highLightStart()
    {
        if(highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
            highlightCoroutine = null;
        }
        highlightCoroutine = StartCoroutine(Highlights());
    }
}
