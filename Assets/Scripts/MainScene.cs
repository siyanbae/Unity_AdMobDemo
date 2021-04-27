using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void OnClickedBanner()
    {
        SceneManager.LoadScene("BannerScene");
    }

    public void OnClickedInterstitial()
    {
        SceneManager.LoadScene("InterstitialScene");
    }

    public void OnClickedRewarded()
    {
        SceneManager.LoadScene("RewardedScene");
    }
}
