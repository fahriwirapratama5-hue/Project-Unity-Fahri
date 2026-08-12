using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public bool pakaiFixedUpdate = true;

    private Rigidbody2D rb;
    private Animator anim; // 1. Tambahkan variabel Animator
    private float inputX;
    private float inputY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // 2. Ambil komponen Animator dari objek
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        // 3. HITUNG KECEPATAN GERAK & KIRIM KE ANIMATOR
        // Vector2.sqrMagnitude menghitung apakah ada pergerakan (Horizontal / Vertical)
        float totalGerakan = new Vector2(inputX, inputY).sqrMagnitude;
        anim.SetFloat("Speed", totalGerakan);

        if (!pakaiFixedUpdate) MenjalankanGerakan();
    }

    private void FixedUpdate()
    {
        if (pakaiFixedUpdate) MenjalankanGerakan();
    }

    private void MenjalankanGerakan()
    {
        if (inputX != 0 || inputY != 0)
        {
            rb.linearVelocity = new Vector2(inputX * speed, inputY * speed); // Gunakan rb.velocity jika Unity versi lama
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}