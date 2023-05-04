using System.Collections.Generic;

public interface IDeathMatch
{
    public void CharacterDead(string name);
    public void RefreshKillsPlayer(KeyValuePair<string,int> player);
    public void PlayersInitGame();
    public void FinishGame();
}
