using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{

    protected static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] protected UIManager uiManager;
    public UIManager UIManager => uiManager;
    protected int levelGame;
    public int LevelGame => levelGame;
    protected bool isSoundBg;
    public bool IsSoundBg => isSoundBg;
    protected bool isSound;
    public bool IsSound => isSound;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        LoadGameSettings();
    }    protected void Start()
    {
        Application.targetFrameRate = 180;
        SpawnLevel();
    }
    protected void LoadGameSettings()
    {
        this.levelGame = PlayerPrefs.GetInt("LevelGame", 1);
        this.isSound = PlayerPrefs.GetInt("IsSound", 1) == 1;
        this.isSoundBg = PlayerPrefs.GetInt("IsSoundBg", 1) == 1;
    }
    protected void SpawnLevel()
    {
        Debug.Log(this.levelGame);
      uiManager.SpawnLevel(this.levelGame);
    }
    public void SetLevel(int level)
    {
        this.levelGame = level;
        PlayerPrefs.SetInt("LevelGame", this.levelGame);
        PlayerPrefs.Save();
    }
    public void SetSoundBg(bool SoundBg)
    {
        this.isSoundBg = SoundBg;
        PlayerPrefs.SetInt("IsSoundBg", this.isSoundBg?1:0);
        PlayerPrefs.Save();
    }
    public void SetSound(bool Sound)
    {
        this.isSound = Sound;
        PlayerPrefs.SetInt("IsSound", this.isSound ? 1 : 0);
        PlayerPrefs.Save();
    }
}
