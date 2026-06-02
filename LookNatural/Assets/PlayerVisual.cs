using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{   
    public GameObject playerModel;
    public GameObject propModel;


    public void SetAsPlayer()
    {
        playerModel.SetActive(true);
        propModel.SetActive(false);
        NetworkMessenger.Instance.PrintIfProp(false);
    }

    public void SetAsProp()
    {
        playerModel.SetActive(false);
        propModel.SetActive(true);
        NetworkMessenger.Instance.PrintIfProp(true);
    }
}
