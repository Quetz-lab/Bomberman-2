using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType Type;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out GMBomb playerBombManager)) return;
        
            switch (Type)
            {
                case PowerUpType.ExtraBomb:
                    playerBombManager.AddExtraBomb();
                    break;
                case PowerUpType.ExtraRange:
                    playerBombManager.AddExtraRange();
                    break;
            } 
        gameObject.SetActive(false);
    }
}

public enum PowerUpType
{
    ExtraBomb,
    ExtraRange
}
