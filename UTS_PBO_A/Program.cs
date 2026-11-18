
using System;
using System.Collections.Generic;

namespace SistemMBG
{
   
    class Sekolah
    {
        public string idSekolah;
        public string namaSekolah;
        public int jumlahPaketDiterima;

        public Sekolah(string id, string nama, int jumlah)
        {
            idSekolah = id;
            namaSekolah = nama;
            jumlahPaketDiterima = jumlah;
        }

        public void TampilInfo()
        {
            Console.WriteLine("ID Sekolah       : " + idSekolah);
            Console.WriteLine("Nama Sekolah     : " + namaSekolah);
            Console.WriteLine("Paket Diterima   : " + jumlahPaketDiterima);
        }
    }

    abstract class PaketMBG
    {
        private string idPaket;
        private string namaPaket;
        private int stokDapur;

        public string IdPaket
        {
            get { return idPaket; }
            set { idPaket = value; }
        }

        public string NamaPaket
        {
            get { return namaPaket; }
            set { namaPaket = value; }
        }

        public int StokDapur
        {
            get { return stokDapur; }
            private set
            {
                if (value >= 0)
                    stokDapur = value;
            }
        }

        public PaketMBG(string id, string nama, int stok)
        {
            idPaket = id;
            namaPaket = nama;
            stokDapur = Math.Max(0, stok);
        }

        public bool KurangiStok(int jumlah)
        {
            if (jumlah <= 0)
            {
                Console.WriteLine("Gagal: Jumlah pengurangan harus lebih dari 0.");
                return false;
            }

            if (jumlah > stokDapur)
            {
                Console.WriteLine("Gagal: Stok dapur tidak mencukupi.");
                return false;
            }

            stokDapur -= jumlah;
            return true;
        }

        public abstract decimal HitungBiaya(int jumlah);

        public void TampilPaket()
        {
            Console.WriteLine("ID Paket     : " + idPaket);
            Console.WriteLine("Nama Paket   : " + namaPaket);
            Console.WriteLine("Stok Dapur   : " + stokDapur);
        }
    }

    class PaketReguler : PaketMBG
    {
        public PaketReguler(string id, string nama, int stok)
            : base(id, nama, stok)
        {
        }

        public override decimal HitungBiaya(int jumlah)
        {
            return jumlah * 15000;
        }
    }

    class PaketKhusus : PaketMBG
    {
        public string JenisDiet { get; set; }

        public PaketKhusus(string id, string nama, int stok, string diet)
            : base(id, nama, stok)
        {
            JenisDiet = diet;
        }

        public override decimal HitungBiaya(int jumlah)
        {
            return jumlah * 20000;
        }
    }

    interface DapatDidistribusikan
    {
        void KirimPaket();
    }

    class DistribusiMBG : DapatDidistribusikan
    {
        private Sekolah sekolahTujuan;
        private PaketMBG paket;
        private int jumlah;

        public DistribusiMBG(Sekolah sekolah, PaketMBG paketMBG, int jumlahKirim)
        {
            sekolahTujuan = sekolah;
            paket = paketMBG;
            jumlah = jumlahKirim;
        }

        public void KirimPaket()
        {
            Console.WriteLine("\nProses Distribusi MBG");

            if (jumlah <= 0)
            {
                Console.WriteLine("Distribusi gagal: Jumlah paket harus lebih dari 0.");
                return;
            }

            if (jumlah > paket.StokDapur)
            {
                Console.WriteLine("Distribusi gagal: Stok dapur tidak mencukupi.");
                return;
            }

            if (paket.KurangiStok(jumlah))
            {
                sekolahTujuan.jumlahPaketDiterima += jumlah;

                Console.WriteLine(
                    "Distribusi MBG berhasil! Sebanyak " +
                    jumlah + " paket makanan telah dikirim ke sekolah " +
                    sekolahTujuan.namaSekolah
                );

                Console.WriteLine("Total biaya: Rp" +
                    paket.HitungBiaya(jumlah).ToString("N0"));
            }
        }
    }

    class PengelolaMBG
    {
        private List<Sekolah> daftarSekolah = new List<Sekolah>();
        private List<PaketMBG> daftarPaket = new List<PaketMBG>();
        public void TambahSekolah(Sekolah sekolah)
        {
            daftarSekolah.Add(sekolah);
        }

        public void TambahPaket(PaketMBG paket)
        {
            daftarPaket.Add(paket);
        }

        public void TampilkanDataMBG()
        {
            Console.WriteLine("\nData Sekolah");

            foreach (Sekolah sekolah in daftarSekolah)
            {
                sekolah.TampilInfo();
            }

            Console.WriteLine("\nData Paket MBG");
            foreach (PaketMBG paket in daftarPaket)
            {
                paket.TampilPaket();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" SISTEM MANAJEMEN DISTRIBUSI MBG");

            Sekolah sekolah1 = new Sekolah("S001", "SMA Negeri 1 Lamongan", 0);
            Sekolah sekolah2 = new Sekolah("S002", "SMP Negeri 2 Lamongan", 0);

            Console.WriteLine("\nData Sekolah");
            sekolah1.TampilInfo();
            sekolah2.TampilInfo();

            PaketReguler reguler = new PaketReguler(
                "P001", "Paket Reguler", 100
            );

            PaketKhusus khusus = new PaketKhusus(
                "P002", "Paket Khusus", 50, "Rendah Gula"
            );

            PaketMBG paket1 = reguler;
            PaketMBG paket2 = khusus;

            Console.WriteLine("\nPerhitungan Biaya");
            Console.WriteLine("Biaya Reguler (10 paket): Rp" +
                paket1.HitungBiaya(10).ToString("N0"));

            Console.WriteLine("Biaya Khusus (10 paket): Rp" +
                paket2.HitungBiaya(10).ToString("N0"));

            DistribusiMBG distribusi1 = new DistribusiMBG(
                sekolah1, reguler, 30
            );

            DistribusiMBG distribusi2 = new DistribusiMBG(
                sekolah2, khusus, 20
            );

            distribusi1.KirimPaket();
            distribusi2.KirimPaket();

            PengelolaMBG pengelola = new PengelolaMBG();

            pengelola.TambahSekolah(sekolah1);
            pengelola.TambahSekolah(sekolah2);

            pengelola.TambahPaket(reguler);
            pengelola.TambahPaket(khusus);

            pengelola.TampilkanDataMBG();

            Console.WriteLine("\nProgram Selesai");
            Console.ReadKey();
        }
    }
}
