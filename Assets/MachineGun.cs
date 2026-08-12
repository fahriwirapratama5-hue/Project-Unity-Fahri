using UnityEngine;
using UnityEngine.Pool;

public class GatlingGun : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float fireRate = 20f; // 20 peluru per detik
    private float fireTimer;

    private ObjectPool<Bullet> bulletPool;

    void Awake()
    {
        // Step A: Inisialisasi pool
        bulletPool = new ObjectPool<Bullet>(
            createFunc: CreateBullet,
            actionOnGet: OnGetBullet,
            actionOnRelease: OnReleaseBullet,
            actionOnDestroy: OnDestroyBullet,
            collectionCheck: true,
            defaultCapacity: 20,
            maxSize: 50
        );
    }

    // Dipanggil HANYA saat pool butuh objek baru (misal pool kosong)
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        return bullet;
    }

    // Dipanggil setiap kali Get() dipanggil — objek diaktifkan
    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    // Dipanggil setiap kali Release() dipanggil — objek dinonaktifkan
    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    // Dipanggil kalau pool sudah penuh (jarang terjadi kalau maxSize cukup)
    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        float interval = 1f / fireRate; // jarak waktu antar tembakan

        if (Input.GetMouseButton(0) && fireTimer >= interval)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        Bullet bullet = bulletPool.Get(); // AMBIL dari pool, bukan Instantiate
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        // Kasih tahu peluru cara "minta dikembalikan" ke pool ini
        bullet.Init(transform.right, (b) => bulletPool.Release(b));
    }
}