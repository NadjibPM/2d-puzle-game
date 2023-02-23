using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour
{
    public string myGameIdAndroid = "4951561";
public string adUnitIdAndroid = "Interstitial_Android";
public string adUnitIdAndroidtwo = "Banner_Android";
public string adUnitIdIOS = "Interstitial_iOS";
public string myAdUnitId;
public string myAdUnitIdtwo; 
public bool adStarted;
private bool testMode = false;
    // Start is called before the first frame update
    void Start()
    {
	Advertisement.Initialize(myGameIdAndroid, testMode);
	myAdUnitId = adUnitIdAndroid;
    myAdUnitIdtwo = adUnitIdAndroidtwo;
    Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);

    
    }

    // Update is called once per frame
    public void showAdButton()
    {
        if (Advertisement.isInitialized &&  !adStarted)
            {
            	Advertisement.Load(myAdUnitId);
                Advertisement.Show(myAdUnitId);
            	adStarted = true;
            }
    }
    private void Update() {
        Advertisement.Banner.Load(myAdUnitIdtwo);
        Advertisement.Banner.Show(myAdUnitIdtwo);
    }
}
