using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterstitialDemo : MonoBehaviour
{
    private InterstitialAd interstitial;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();
    }

    private void OnDestroy()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
    }
    
    public void OnClickedBack()
    {
        SceneManager.LoadScene("MainScene");
    }


    private void RequestInterstitial()
    {
        StartCoroutine(CoRequestInterstitial());
    }

    IEnumerator CoRequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdLoaded += this.HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleOnAdOpened;
        this.interstitial.OnAdClosed += this.HandleOnAdClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);

        yield return new WaitUntil(() => interstitial.IsLoaded());

        this.interstitial.Show();
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
