using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using DG.Tweening;
using UnityEngine.UI;
public class ButtonNextLevel : MonoBehaviour
{
    protected RectTransform rect;
    protected void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        this.MoveObj();
    }

    private void MoveObj()
    {
        Debug.Log("da vao");
        rect.DOAnchorPos(new Vector3(0, 250f, 0), 0.5f).OnComplete(() => ScaleObj());
    }
    private void ScaleObj()
    {
        rect.DOScale(Vector3.one + Vector3.one * 0.25f, 0.2f)
           .SetLoops(-1, LoopType.Yoyo);
    }    
}
