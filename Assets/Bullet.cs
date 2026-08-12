using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f; // otomatis kembali ke pool setelah sekian detik

    private float timer;
    private System.Action<Bullet> releaseAction;

    // Dipanggil oleh sistem gun saat peluru diambil dari pool
    public void Init(Vector2 direction, System.Action<Bullet> onRelease)
    {
        timer = 0f;
        releaseAction = onRelease;
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            releaseAction?.Invoke(this); // minta dikembalikan ke pool
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // contoh: kalau kena musuh, langsung release juga
        if (other.CompareTag("Enemy"))
        {
            releaseAction?.Invoke(this);
        }
    }
}