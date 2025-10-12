using System.Collections.Generic;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    private Dictionary<Land, LandController> lands;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LandSpaceSuccessGameEvent>(OnLandSpaceSuccessChanged);
        EventManager.Instance.AddListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
    }

    private void OnLandSpaceSuccessChanged(LandSpaceSuccessGameEvent info)
    {

    }

    private void OnLandPlantedSuccessChanged(LandPlantedSuccessGameEvent info)
    { 

    }
}
