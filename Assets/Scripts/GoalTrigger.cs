using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [Header("Effect Prefab")]
    public GameObject confettiPrefab;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            PlayConfetti(other.transform.position);
        }
    }

    private void PlayConfetti(Vector3 position)
    {
        if (confettiPrefab != null)
        {
            Vector3 spawnPos = position + Vector3.up * 1.5f;

            GameObject effect = Instantiate(confettiPrefab, spawnPos, Quaternion.identity);

            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            Destroy(effect, 2f); // hủy sau 2 giây
        }
    }

}
