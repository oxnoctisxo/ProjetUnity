using UnityEngine;
using System.Collections;

public class ScoreManager : AbstractSingleton<ScoreManager>
{
    [SerializeField]
    private int score;
    [SerializeField]
    private int hiScore;

    private string hiScorePlayerPrefsKey;

    public delegate void ScoreAction(int score);
    public event ScoreAction OnScore;
    public event ScoreAction OnHiScore;

    public int GetScore()
    {
        return score;
    }

    public int GetHiScore()
    {
        return hiScore;
    }

    // Sets the score and notify listeners
    public void SetScore(int newScore)
    {
        int scoreDiff = newScore - score;
        score = newScore;
        if (score > hiScore)
        {
            SetHiScore(score);
        }
        NotifyScoreMod(scoreDiff);
    }

    public void SetHiScore(int newHiScore)
    {
        int hiScoreDiff = newHiScore - hiScore;
        hiScore = newHiScore;
        NotifyHiScoreMod(hiScoreDiff);
        SaveHiScore();
    }

    public void AddScore(int scoreDiff)
    {
        SetScore(score + scoreDiff);
    }

    private void NotifyScoreMod(int scoreDiff)
    {
        if (OnScore != null)
        {
            OnScore(scoreDiff);
        }
    }
    private void NotifyHiScoreMod(int scoreDiff)
    {
        if (OnHiScore != null)
        {
            OnHiScore(scoreDiff);
        }
    }

    private void SaveHiScore()
    {
        PlayerPrefs.SetInt(hiScorePlayerPrefsKey, hiScore);
        PlayerPrefs.Save();
    }

    private void LoadHiScore()
    {
        hiScore = PlayerPrefs.GetInt(hiScorePlayerPrefsKey, 0);
    }

    #region implemented abstract members of AbstractSingleton
    public override void Initialize()
    {
        hiScorePlayerPrefsKey = PlayerPrefsKeys.Keys.HiScore.TooltipToString();
        LoadHiScore();
    }
    #endregion

}
