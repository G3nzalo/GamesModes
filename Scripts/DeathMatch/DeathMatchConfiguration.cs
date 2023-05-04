using UnityEngine;

[CreateAssetMenu(fileName = "DeathMatch", menuName = "GameConfigurations/DeathMatch")]
public class DeathMatchConfiguration : ScriptableObject
{
    public int finishGameWithDeaths;
    public float timeForGame;
}
