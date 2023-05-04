using UnityEngine;

public class GameModeStrategy : MonoBehaviour
{
    [SerializeField] GameObject _deathMathMediator;
    [SerializeField] GameObject _battleRoyaleMediator;
    [SerializeField] private DeathMatchConfiguration _deathMathConfiguration;
    [SerializeField] private BattleRoyaleConfiguration _battleRoyaleConfiguration;

    private void Start()
    {
        SessionProps props = App.Instance.Session.Props;
        CreateGame(props.PlayMode);
    }
    public void CreateGame(PlayMode mode) => CreateGameStrategy(mode);

    private void CreateGameStrategy(PlayMode mode)
    {
        if (mode == PlayMode.BattleRoyale)
        {
            _deathMathMediator.GetComponent<DeathMatchMediator>().Init(_deathMathConfiguration);
        }
        if (mode == PlayMode.BattleRoyale)
        {
            _battleRoyaleMediator.GetComponent<BattleRoyaleGamemode>().Init(_battleRoyaleConfiguration);
        }
    }
}