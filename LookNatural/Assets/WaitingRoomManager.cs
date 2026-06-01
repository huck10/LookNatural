using NetcodePlus;
using NetcodePlus.Demo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitingRoomManager : MonoBehaviour
{
    public GameObject waitPanel;
    public int maxPlayerNeeded = 2;
    public TextMeshProUGUI playersUIText;
    private float timer = 0f;
    private SNetworkActions actions;

    private void Start()
    {
        actions = new SNetworkActions(null);
    }

    private void Update()
    {
        if(playersUIText == null || waitPanel == null)
        {
            Debug.Log("empty reference in Update()!");
            return;
        }

        if (!TheNetwork.Get().IsServer)
        {
            Debug.Log("not server!");
            return;
        }

        timer += Time.deltaTime;
        if (timer < 2f)
        {
            return;
        }

        timer = 0f;

        int count = GameData.Get().CountConnected();
        int max = NetworkData.Get().players_max;

        playersUIText.text = "lobby: " + count;

        if(count >= maxPlayerNeeded)
        {
            waitPanel.SetActive(false);
        }
    }
}
