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
            LayananMotor lm1 = new LayananMotor("rossi", "0001", "bwi", 20000);
            lm1.HitungTarif(10);
            PesananTansportasi pt1 = new PesananTansportasi("rossi", "0001", "bwi", lm1);
            pt1.nama = "rossi";
            pt1.idpesanan = "0001";
            pt1.lokasitujuan = "Bali";

            pt1.TampilkanInfo();




        }
    }
    public class PesananTansportasi
    {
        protected string _namaPenumpang;
        protected string _idPesanan;
        protected string _lokasiTujuan;
        public int jarakKm = 10000;
        public decimal total;

        new List<LayananMotor>

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


        public PesananTansportasi(string nm, string id, string lokasitujuan, LayananMotor p)
        {
            this._namaPenumpang = nm;
            this._idPesanan = id;
            this._lokasiTujuan = lokasitujuan;
            this.pesanMobil = p;

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
        public List<LayananMotor> layananmtr = new List<LayananMotor>();

        //constructor
        public LayananMotor(string nm, string id, string lokasitujuan, int tarif) : base(nm, id, lokasitujuan, LayananMotor)
        {
            this.tarifPerKm = tarif;
            this._namaPenumpang = nm;
            this._idPesanan = id;
            this._lokasiTujuan = lokasitujuan;
        }


        public override void HitungTarif(int jarak)
        {
            Console.WriteLine(total = jarak * tarifPerKm);

        }

        public void TampilkanInfo()
        {
            Console.WriteLine($"total pengeluaran {total}");
        }
    }

    //public class LayananMobil : PesananTansportasi
    //{
    //    public int tarifPerKm;
    //    public int biayaTol;
    //    //constructor


    //    public override void HitungTarif(int jarak)
    //    {
    //        Console.WriteLine(total = (jarak * tarifPerKm) + BiayaTol);

    //    }

    //    public void TampilkanInfo()
    //    {
    //        Console.WriteLine($"total pengeluaran {total}");
    //    }
    //}

    public class RiwayatPerjalanan//optional
    {
        //berisi keseluruhan layanan transportasi
    }
}

