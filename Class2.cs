//Agregasi penumpang
//jenis layanan
//menghitung tarif perjalanan based jarak tempuh dan jenis kendaraan yg dipesan
//
namespace PBO
{

    class Program
    {
        static void Main(string[] args)
        {
            LayananMotor lm1 = new LayananMotor("rossi", "001", "BWI", 10000);
            lm1.HitungTarif(10);
            lm1.TampilkanInfo();

            LayananMobil lm2 = new LayananMobil("Zahid", "0001", "BWI", 50000, 10000);
            lm2.HitungTarif(20);
            lm2.TampilkanInfo();

            RiwayatPerjalanan rw1 = new RiwayatPerjalanan("1", "Mobil", "10-10-2025", "10", lm2);
            rw1.TambahPerjalanan();
            rw1.cetakRiwayat();
        }
    }
    public class PesananTansportasi
    {
        protected string _namaPenumpang;
        protected string _idPesanan;
        protected string _lokasiTujuan;
        public int jarakKm = 10000;
        public decimal total;

        public string nama
        {
            get { return _namaPenumpang; }
            set
            {
                nama = _namaPenumpang;
            }
        }

        public string idpesanan
        {
            get { return _idPesanan; }
            set { idpesanan = _idPesanan; }
        }

        public string lokasitujuan
        {
            get { return _lokasiTujuan; }
            set { lokasitujuan = _lokasiTujuan; }
        }


        public PesananTansportasi(string nm, string id, string lokasitujuan)
        {
            this._namaPenumpang = nm;
            this._idPesanan = id;
            this._lokasiTujuan = lokasitujuan;

        }
        public void TampilkanInfo()
        {
            Console.WriteLine($"Nama: {nama} | ID: {idpesanan} | Tujuan: {lokasitujuan}");
        }

        public virtual void HitungTarif(int jarak) { }
    }

    public class LayananMotor : PesananTansportasi
    {
        public int tarifPerKm;


        //constructor
        public LayananMotor(string nm, string id, string lokasitujuan, int tarif) : base(nm, id, lokasitujuan)
        {
            this.tarifPerKm = tarif;
            this._namaPenumpang = nm;
            this._idPesanan = id;
            this._lokasiTujuan = lokasitujuan;
        }


        public override void HitungTarif(int jarak)
        {
            total = jarak * tarifPerKm;

        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"Nama: {nama} | ID: {idpesanan} | Tujuan: {lokasitujuan}");
            Console.WriteLine($"Total: {total}");
        }
    }

    public class LayananMobil : PesananTansportasi
    {
        public int tarifPerKm;
        public int biayaTol;
        //constructor


        public LayananMobil(string nm, string id, string lokasitujuan, int tarifPerKm, int biayatol) : base(nm, id, lokasitujuan)
        {
            this.tarifPerKm = tarifPerKm;
            this.biayaTol = biayatol;
            this._namaPenumpang = nm;
            this._idPesanan = id;
            this._lokasiTujuan = lokasitujuan;
        }

        public override void HitungTarif(int jarak)
        {
            total = (jarak * tarifPerKm) + biayaTol;

        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"Nama: {nama} | ID: {idpesanan} | Tujuan: {lokasitujuan}");
            Console.WriteLine($"Total: {total}");
        }
    }

    public class RiwayatPerjalanan//optional
    {
        //berisi keseluruhan layanan transportasi
        public PesananTansportasi history;
        public string jenisKendaraan;
        public string tanggal;
        public string no;
        public string jarakkm;

        public RiwayatPerjalanan(string no, string jenisK, string tgl, string jarakkm, PesananTansportasi daftarK)
        {
            this.jenisKendaraan = jenisK;
            this.tanggal = tgl;
            this.history = daftarK;
            this.no = no;
            this.jarakkm = jarakkm;
        }

        public void TambahPerjalanan()
        {

        }
        public void cetakRiwayat()
        {
            Console.WriteLine($"Nama: {history.nama} | ID: {history.idpesanan} | Tujuan: {history.lokasitujuan}");
            Console.WriteLine($"Total: {history.total}");
            Console.WriteLine($"{no}. {jenisKendaraan} | {jarakkm} KM | {tanggal}");
        }
    }
}

