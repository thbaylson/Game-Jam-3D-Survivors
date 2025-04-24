using UnityEngine;

public class ECSAnimatorPrefabManager : MonoBehaviour
{
    public static ECSAnimatorPrefabManager Instance;

    public GameObject animatorPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
