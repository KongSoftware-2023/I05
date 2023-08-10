using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(new Vector3(0f, 0f, 15f), 0.25f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}

