using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DeathMatchLogic: MonoBehaviour
{
    private int _finishGameWithDeaths;
    private float _timeForGame;
    private Dictionary<string, int> _players = new Dictionary<string, int>();
    private IDeathMatch _deathMatchMediator;

    public void CharacterDead(string playerName) => AddKilledInPlayer(playerName);
    public void CheckTimeForFinishGame() => CheckTime();

    public float GetCurrentTime() => _timeForGame;

    public void Configure(IDeathMatch deathMatchMediator, DeathMatchConfiguration config , Dictionary<string, int> players)
    {
        _deathMatchMediator = deathMatchMediator;
        _finishGameWithDeaths = config.finishGameWithDeaths;
        _timeForGame = config.timeForGame;
        _players = players;
    }

    private void AddKilledInPlayer(string playerName)
    {
        if (_players[playerName].Equals(null)) _players[playerName] = 0;

        _players[playerName] += 1;

        var value = SendInfo(playerName);

        _deathMatchMediator.RefreshKillsPlayer(value);

        CheckFinishGame(playerName);
    }


    private KeyValuePair<string,int> SendInfo(string playerName)
    {
        var player = new KeyValuePair<string, int>();

        foreach (var item in _players)
        {
          if( item.Key.Contains(playerName))
            {
                player = item;
            }
        }

        return player;
    }


    private void CheckFinishGame(string playerName)
    {
        if (_players[playerName].Equals(_finishGameWithDeaths))
        {
            _deathMatchMediator.FinishGame();
        }
    }

    private void CheckTime()
    {
        _timeForGame -= Time.deltaTime;
        if (_timeForGame <= 0) _deathMatchMediator.FinishGame();
    }

}
