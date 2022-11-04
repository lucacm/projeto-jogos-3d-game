using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "maoInimigo")
        {
            Debug.Log("hit");
            SceneManager.LoadScene("GameOver");
        }
    }
}
