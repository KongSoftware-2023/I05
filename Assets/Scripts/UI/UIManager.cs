using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected GameObject buttonHint;
    [SerializeField] protected GameObject buttonAskFriend;
    [SerializeField] protected GameObject buttonNextLv;
    [SerializeField] protected GameObject parentLevel;
    [SerializeField] protected Text textLv;
    [SerializeField] protected RectTransform pannelSetting;
    [SerializeField] protected Transform setting;
    [SerializeField] protected GameObject musicBgOn;
    [SerializeField] protected GameObject musicBgOff;
    [SerializeField] protected bool isMusicBg;
    [SerializeField] protected GameObject soundOn;
    [SerializeField] protected GameObject soundOff;
    [SerializeField] protected bool isSound;
    //[SerializeField] protected GameObject vibrationOn;
    //[SerializeField] protected GameObject vibrationOff;
    //[SerializeField] protected bool isVibartion;
    protected Text txtLevel;
    protected bool isOpen = false;
    public bool isFadding = false;
    public Tweener isTween;

    protected void Start()
    {
        textLv.text = "LEVEL " + GameManager.Instance.LevelGame.ToString();
        LoadUiButton();
    }
    public void NextLevel()
    {
        Debug.Log("da vao chuwa");
        this.LoadGameScreen();
    }
    public void LoadGameScreen()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void SpawnLevel(int lv)
    {
        string levelPath = "Level/" + "Lv" + lv.ToString();
        GameObject levelPrefab = Resources.Load<GameObject>(levelPath);
        if (levelPrefab != null)
        {
            GameObject ObjLevel = Instantiate(levelPrefab, transform.position, transform.rotation);
            ObjLevel.SetActive(true);
            ObjLevel.transform.SetParent(parentLevel.transform);
            RectTransform rectTransform = ObjLevel.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = new Vector3(1, 1, 1);
        }
    }
    protected void LoadUiButton()
    {
        this.isMusicBg = GameManager.Instance.IsSoundBg;
        this.isSound= GameManager.Instance.IsSound;
        this.SetStartButton();
    }
    protected void SetStartButton()
    {
        if(isMusicBg)
        {
            this.musicBgOn.SetActive(true);
            this.musicBgOff.SetActive(false);
        }      
        else
        {
            this.musicBgOn.SetActive(false);
            this.musicBgOff.SetActive(true);
        }
        if (isSound)
        {
            this.soundOn.SetActive(true);
            this.soundOff.SetActive(false);
        }
        else
        {
            this.soundOn.SetActive(false);
            this.soundOff.SetActive(true);
        }
    }
    public void OnButtonNextLv()
    {

        this.buttonHint.SetActive(false);
        this.buttonAskFriend.SetActive(false);
        this.buttonNextLv.SetActive(true);
    }
    public void ToggleSetting()
    {
        MusicManager.Instance.PlayClickMusic();
        this.isOpen = !this.isOpen;
        if (isOpen)
        {
            pannelSetting.DOAnchorPos(new Vector3(0, 0f, 0), duration: 0.5f);
            setting.DORotate(new Vector3(0f, 0f, 360), 0.3f, RotateMode.FastBeyond360)
          .SetEase(Ease.Linear);

        }
        else
        {
            pannelSetting.DOAnchorPos(new Vector3(0, 680, 0), duration: 0.5f);
            setting.DORotate(new Vector3(0f, 0f, -360f), 0.3f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear);
        }
    }
    public void ToggleMusicBg()
    {
        MusicManager.Instance.PlayClickMusic();
        if (this.isMusicBg)
        {
            this.isMusicBg = !this.isMusicBg;
            this.musicBgOn.SetActive(false);
            this.musicBgOff.SetActive(true);
            GameManager.Instance.SetSoundBg(isMusicBg);
            MusicManager.Instance.ToggleMusicBg();

        }
        else
        {
            this.isMusicBg = !this.isMusicBg;
            this.musicBgOn.SetActive(true);
            this.musicBgOff.SetActive(false);
            GameManager.Instance.SetSoundBg(isMusicBg);
            MusicManager.Instance.ToggleMusicBg();
        }

    }
    public void ToggleSound()
    {
        MusicManager.Instance.PlayClickMusic();
        if (this.isSound)
        {
            this.isSound = !this.isSound;
            this.soundOn.SetActive(false);
            this.soundOff.SetActive(true);
            GameManager.Instance.SetSound(isSound);

        }
        else
        {
            this.isSound = !this.isSound;
            this.soundOn.SetActive(true);
            this.soundOff.SetActive(false);
            GameManager.Instance.SetSound(isSound);
        }

    }
    public void ActiveHint()
    {
        MusicManager.Instance.PlayClickMusic();
        this.isFadding = true;
        this.Fadding();
    }
    public void Fadding()
    {
        Image image = this.FindCanScratch();
        if (image == null) return;
        isTween = image.DOFade(0f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
    public void StopFadding()
    {
        Image image = this.FindCanScratch();
        if (image == null) return;
        isTween.Kill();
        image.DOColor(new Color(image.color.r, image.color.g, image.color.b, 1f), 0.1f);
    }
    protected Image FindCanScratch()
    {
        Transform CansCratch = parentLevel.GetComponentInChildren<ScratchImage>().transform;
        return CansCratch.GetChild(0).GetComponent<Image>();
    }

}
