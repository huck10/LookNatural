using NetcodePlus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class NetworkMessenger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI isPropUIText;
    public static NetworkMessenger Instance;

    private bool isProp;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PrintIfProp(bool _isProp)
    {
        isProp = _isProp;
        if (isProp)
        {
            isPropUIText.text = "Props";
        }
        else
        {
            isPropUIText.text = "Hunter";
        }

    }

}
