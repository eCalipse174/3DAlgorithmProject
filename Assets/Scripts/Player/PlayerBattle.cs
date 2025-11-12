using UnityEngine;

public class PlayerBattle : MonoBehaviour, ICoroutineHost
{
    

    public void Hit(BehaviourInfo pInfo, int pHitIndex, Transform pTrans)
    {
        Collider[] hits;


        hits = Physics.OverlapSphere(pTrans.position, pInfo.AreaRadius);
        foreach (var hit in hits)
        {
            // 에너미 때리기
        }
    }
}
