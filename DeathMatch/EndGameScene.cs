using UnityEngine;

public class EndGameScene : MonoBehaviour
{
    public void FinishGame() => SceneGameOver();
    private void SceneGameOver() => App.Instance.Session.LoadMap(MapIndex.GameOver);
}

