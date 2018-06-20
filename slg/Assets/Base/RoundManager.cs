public class RoundManager {
    private static RoundManager Instance = null;
    private bool isEnemyRound = false;

    private RoundManager()
    {

    }

    static public RoundManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new RoundManager();
        }
        return Instance;
    }

    public void SetEnemyRound(bool isenemyRound) {
        isEnemyRound = isenemyRound;
    }

    public bool IsEnemyRound() {
        return isEnemyRound;
    }


}