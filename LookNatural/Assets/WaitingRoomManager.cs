using NetcodePlus;
using NetcodePlus.Demo;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class WaitingRoomManager : NetworkBehaviour
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
        if (!TheNetwork.Get().IsServer)
            return;

        timer += Time.deltaTime;
        if (timer < 2f)
            return;

        timer = 0f;

        int count = GameData.Get().CountConnected();

        UpdateLobbyUIClientRpc(count, count >= maxPlayerNeeded);
    }

    [ClientRpc]
    void UpdateLobbyUIClientRpc(int count, bool isFull)
    {
        playersUIText.text = "lobby: " + count;

        if (isFull)
        {
            waitPanel.SetActive(false);
        }
    }
}
