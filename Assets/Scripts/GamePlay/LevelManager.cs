using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] protected ScratchImage canScratch;
    [SerializeField] protected List<Dont> lisDontScratch;
    [SerializeField] protected int numberChild;
    [SerializeField] protected GameObject after;
    [SerializeField] protected GameObject before;
    [SerializeField] protected GameObject otherafter;
    [SerializeField] protected float percent;
    [SerializeField] protected float percentDont = 0.1f;
    protected bool isWinning = false;
    protected void Start()
    {
        numberChild = 0;
        this.CheckCanvas();
    }

    protected void Update()
    {

        if (InputManager.Instance.GetMouseUp())
        {
            if (GameManager.Instance.UIManager.isFadding && !isWinning)
            {
                GameManager.Instance.UIManager.Fadding();
            }
            if (this.CheckWinCondition())
                this.Winning();
            else
            {
                StartCoroutine(ResetMask());
            }
        }
        if (InputManager.Instance.GetMouse() && !isWinning)
        {
            if (GameManager.Instance.UIManager.isFadding)
            {
                GameManager.Instance.UIManager.StopFadding();
            }
        }
    }
    IEnumerator ResetMask()
    {
        yield return new WaitForSeconds(0.02f);
        foreach (Dont child in lisDontScratch)
        {
            child.ResetMask();
        }
        canScratch.ResetMask();
    }
    bool CheckWinCondition()
    {
        if (canScratch.GetStatData().fillPercent > percent)
        {
            Debug.Log("can" + canScratch.GetStatData().fillPercent);
            foreach (Dont obj in lisDontScratch)
            {
                Debug.Log(obj.GetStatData().fillPercent);
                if (obj.GetStatData().fillPercent > this.percentDont)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    protected virtual void Winning()
    {
        Debug.Log("win");
        if (isWinning) return;
        isWinning = true;
        this.ActiveAfter();
        StartCoroutine(this.Fx());
        int lv = GameManager.Instance.LevelGame;
        GameManager.Instance.SetLevel(lv + 1);
        GameManager.Instance.UIManager.OnButtonNextLv();
        MusicManager.Instance.PlayWinMusic();
    }
    protected void ActiveAfter()
    {
        this.after.SetActive(true);
        this.before.SetActive(false);
        if (otherafter == null) return;
        this.otherafter.SetActive(true);
    }
    IEnumerator Fx()
    {
        var Fxs = FindObjectsOfType<PlayFx>();
        foreach (var child in Fxs)
        {
            child.PlayParticleEffect();
        }
        yield return new WaitForSeconds(1);
        foreach (var child in Fxs)
        {
            child.StopFx();
        }
    }
    protected void CheckCanvas()
    {
        var canvas = FindObjectsOfType<Canvas>();
        if (canvas == null) return;
        else
        {
            foreach (var child in canvas)
            {
                RectTransform childCanvasRectTransform = child.GetComponent<RectTransform>();
                childCanvasRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                childCanvasRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                childCanvasRectTransform.anchoredPosition = new Vector2(0, 0);
            }
        }
    }
}
