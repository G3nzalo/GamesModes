using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fusion;
using UnityEngine;


public class DeathMatchMediator : MonoBehaviour, IDeathMatch
{

    [SerializeField] private DeathMatchLogic _deathMatchLogic;
    [SerializeField] private EndGameScene _endGameScene;
    [SerializeField] private InfoKillsPresenter _infoKillPresenter;

    private Dictionary<string, int> _players = new Dictionary<string, int>();

    public static DeathMatchMediator instance = null;

    public void Init(DeathMatchConfiguration config) => InitConfiguration(config);

    public void CharacterDead(string playerName) => PostCharacterDead(playerName);

    public void RefreshKillsPlayer(KeyValuePair<string, int> player) => PostRefreshKillsPlayer(player);

    public Dictionary<string, int> GetPlayers() => _players;

    public void PlayersInitGame() => PostSendPlayersInitGame(GetPlayers());

    public void GetCurrentTimeInGame() => PostCurrentTimeForFinishGame(_deathMatchLogic.GetCurrentTime());

    public void FinishGame() => PostFinishGame();

    private void Awake() => Initialize();

    private void Update() => _deathMatchLogic.CheckTimeForFinishGame();

    private void InitConfiguration(DeathMatchConfiguration config)
    {
        CreatePlayesInGame();
        _deathMatchLogic.Configure(this , config , _players);
    }

    private void PostCharacterDead(string playerName)
            => _deathMatchLogic.CharacterDead(playerName);

    private void PostFinishGame() => _endGameScene.FinishGame();

    private void PostRefreshKillsPlayer(KeyValuePair<string , int> player)
            =>_infoKillPresenter.SendInformationKillRpc(player.Key, player.Value);

    private void PostSendPlayersInitGame(Dictionary<string, int> players)
        => _infoKillPresenter.SendPlayersInitGameRpc();

    private void PostCurrentTimeForFinishGame(float time)
    => _infoKillPresenter.SendTimeCountRpc(time);

    private void CreatePlayesInGame()
    {
        foreach (var type in from Player player in App.Instance.Players
                             let type = player.GetComponent<Player>()
                             select type)
        {
            _players.Add(type.Name.ToString(), 0);
        }
    }

    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
