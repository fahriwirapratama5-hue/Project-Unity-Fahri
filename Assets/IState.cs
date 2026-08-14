public interface IState
{
    void Enter();   // dipanggil SEKALI saat state ini mulai aktif
    void Execute(); // dipanggil TERUS-MENERUS tiap frame selama state ini aktif
    void Exit();    // dipanggil SEKALI saat state ini akan digantikan state lain
}