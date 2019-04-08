using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour {

    public static AdController instance;

    private string store_id = "3097042";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string scene_switch_ad = "SceneSwitch";
    private string banner_ad = "BannerAd";


    void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        } else if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        Monetization.Initialize(store_id, false); //true for test mode - must be false for release
    }


    void Update() {
        
        if(Input.GetKeyDown(KeyCode.E)) {
            if(Monetization.IsReady(video_ad)) {

                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

                if(ad != null) {
                    ad.Show();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            if (Monetization.IsReady(rewarded_video_ad)) {

                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

                if (ad != null) {
                    ad.Show();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Monetization.IsReady(banner_ad))
            {

                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

                if (ad != null)
                {
                    ad.Show();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (Monetization.IsReady(scene_switch_ad))
            {

                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(scene_switch_ad) as ShowAdPlacementContent;

                if (ad != null)
                {
                    ad.Show();
                }
            }
        }
    }

    public void ShowVideoOrInterstitialAd() {
        if (Monetization.IsReady(video_ad)) {

            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

            if (ad != null) {
                ad.Show();
            }
        }
    }

    public void ShowRewardedVideoAd() {
        if (Monetization.IsReady(rewarded_video_ad)) {

            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

            if (ad != null) {
                ad.Show();
            }
        }
    }

    public void ShowBannerAd() {
        if (Monetization.IsReady(banner_ad)) {

            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

            if (ad != null) {
                ad.Show();
            }
        }
    }

    public void ShowSceneSwitchAd() {
        if (Monetization.IsReady(scene_switch_ad)) {

            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(scene_switch_ad) as ShowAdPlacementContent;

            if (ad != null) {
                ad.Show();
            }
        }
    }
}
