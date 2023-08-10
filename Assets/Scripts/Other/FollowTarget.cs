using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected Vector3 target;
    private RectTransform rectTransform;
    private Vector3 initialPosition;
    private Image image;

    private void Start()
    {
        image = transform.GetComponent<Image>();
        // Lấy tham chiếu tới RectTransform của GameObject
        rectTransform = GetComponent<RectTransform>();
        // Lưu giữ vị trí ban đầu của RectTransform
        initialPosition = rectTransform.localPosition;
        transform.DORotate(new Vector3(0f, 0f, 15f), 0.25f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void LateUpdate()
    {
        // Gán lại vị trí Z của RectTransform thành giá trị Z ban đầu
        Vector3 currentPosition = rectTransform.localPosition;
        currentPosition.z = initialPosition.z;
        rectTransform.localPosition = currentPosition;
    }
    void Update()
    {
        Vector3 currentPosition = rectTransform.localPosition;
        currentPosition.z = 0f;
        if (InputManager.Instance.GetMouse())
        {
            image.enabled=true;
            rectTransform.localPosition=currentPosition;
            this.target = InputManager.Instance.MouseworldPosition;
            target.z = 0;
            transform.position = target;
        }
        else if(InputManager.Instance.GetMouseUp())
        {
           image.enabled=false;
        }
    }
}

