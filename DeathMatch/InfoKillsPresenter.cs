using System;
using System.Collections.Generic;
using Fusion;
using GameSource.Scripts.GameEventSystem.Events;
using UnityEngine;

public class InfoKillsPresenter : NetworkBehaviour
{
    [Fusion.Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void SendInformationKillRpc(string player, int kills)
    => UIEvent.Trigger(UIEvents.RefreshKills, new KeyValuePair<string, int>(player, kills));

    [Fusion.Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void SendPlayersInitGameRpc()
    => UIEvent.Trigger(UIEvents.AddPlayer, null);

    public void SendTimeCountRpc(float time)
    => UIEvent.Trigger(UIEvents.RefreshTime, time);
}