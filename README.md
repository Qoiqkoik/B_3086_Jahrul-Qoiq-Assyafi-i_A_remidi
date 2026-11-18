# Sistem Manajemen Distribusi MBG

## 1. Deskripsi Project

Sistem Manajemen Distribusi MBG merupakan program berbasis Console Application yang dibuat menggunakan bahasa pemrograman C# dengan menerapkan konsep Pemrograman Berorientasi Objek (Object-Oriented Programming).

Program ini dibuat untuk membantu pengelolaan distribusi Makan Bergizi Gratis (MBG), mulai dari pengelolaan data sekolah penerima, jenis paket makanan, perhitungan biaya, hingga proses pengiriman paket makanan ke sekolah.

Sistem ini juga memiliki fitur pengelolaan data menggunakan List untuk menyimpan kumpulan objek sekolah dan paket makanan.

## 2. Tujuan Project

Tujuan pembuatan program ini adalah:

- Menerapkan konsep Pemrograman Berorientasi Objek menggunakan C#.
- Mengelola data sekolah penerima paket MBG.
- Mengelola jenis paket makanan dan stok dapur.
- Menghitung biaya berdasarkan jenis paket makanan.
- Melakukan proses distribusi berdasarkan ketersediaan stok.
- Memahami penerapan hubungan antarclass dalam pemrograman berorientasi objek.

## 3. Penerapan Konsep PBO

Program ini menerapkan beberapa konsep utama Pemrograman Berorientasi Objek, yaitu:

### A. Class dan Object

Class merupakan cetakan atau blueprint untuk membuat objek.

Pada program ini terdapat class `Sekolah` yang memiliki atribut:

- `idSekolah`: menyimpan ID sekolah.
- `namaSekolah`: menyimpan nama sekolah.
- `jumlahPaketDiterima`: menyimpan jumlah paket yang diterima.

Object dibuat berdasarkan class Sekolah menggunakan constructor. Contohnya adalah objek `sekolah1` dan `sekolah2`.

Method `TampilInfo()` digunakan untuk menampilkan informasi sekolah.

### B. Encapsulation

Encapsulation merupakan konsep untuk melindungi data agar tidak dapat diakses atau diubah secara langsung dari luar class.

Pada class `PaketMBG`, atribut `idPaket`, `namaPaket`, dan `stokDapur` dibuat menggunakan access modifier `private`.

Untuk mengakses data digunakan Properties yang memiliki `get` dan `set`.

Stok dapur hanya dapat dikurangi melalui method `KurangiStok(int jumlah)`. Method ini melakukan validasi agar jumlah pengurangan lebih dari nol dan tidak melebihi stok yang tersedia.

### C. Inheritance

Inheritance merupakan konsep pewarisan atribut dan method dari class induk kepada class turunan.

Pada program ini, class `PaketMBG` menjadi class induk yang diwariskan kepada:

- `PaketReguler`: jenis paket makanan dengan harga Rp15.000 per paket.
- `PaketKhusus`: jenis paket makanan dengan harga Rp20.000 per paket.

Class `PaketKhusus` juga memiliki atribut tambahan `JenisDiet`, seperti Rendah Gula.

### D. Polymorphism

Polymorphism merupakan kemampuan suatu method untuk memiliki perilaku yang berbeda berdasarkan objek yang menjalankannya.

Pada program ini, method `HitungBiaya(int jumlah)` diimplementasikan pada class `PaketReguler` dan `PaketKhusus` menggunakan keyword `override`.

Perhitungan biaya:
- Paket Reguler = jumlah paket × Rp15.000.
- Paket Khusus = jumlah paket × Rp20.000.

Pemanggilan dilakukan menggunakan variabel bertipe `PaketMBG`, sehingga method yang dijalankan menyesuaikan jenis objeknya.

### E. Abstract Class

Abstract Class merupakan class yang tidak dapat dibuat menjadi objek secara langsung dan digunakan sebagai dasar bagi class turunannya.

Class `PaketMBG` menggunakan keyword `abstract`.

Di dalamnya terdapat abstract method `HitungBiaya(int jumlah)` yang wajib diimplementasikan oleh class `PaketReguler` dan `PaketKhusus`.

### F. Interface

Interface merupakan kontrak yang menentukan method yang harus diimplementasikan oleh sebuah class.

Pada program ini terdapat interface `DapatDidistribusikan` yang memiliki method `KirimPaket()`.

Interface tersebut diimplementasikan oleh class `DistribusiMBG`, yang bertugas menjalankan proses pengiriman paket makanan ke sekolah penerima.

### G. List dan Aggregation

List digunakan untuk menyimpan kumpulan objek dalam satu struktur data.

Pada class `PengelolaMBG` terdapat dua List:

- `daftarSekolah`: menyimpan kumpulan objek Sekolah.
- `daftarPaket`: menyimpan kumpulan objek PaketMBG.

Class ini memiliki tiga method utama:

- `TambahSekolah()`: menambahkan data sekolah.
- `TambahPaket()`: menambahkan data paket.
- `TampilkanDataMBG()`: menampilkan seluruh data sekolah dan paket makanan.

Hubungan antara `PengelolaMBG` dan `Sekolah` termasuk Aggregation karena objek sekolah dapat tetap berdiri sendiri meskipun tidak dimasukkan ke dalam objek pengelola.

## 4. Alur Kerja Program

Berikut merupakan alur kerja Sistem Manajemen Distribusi MBG:

1. Program membuat dua objek sekolah sebagai penerima paket makanan.
2. Program membuat dua jenis paket makanan, yaitu Paket Reguler dan Paket Khusus.
3. Program menghitung biaya masing-masing jenis paket.
4. Program melakukan proses distribusi paket ke sekolah tujuan.
5. Program memeriksa jumlah pengiriman dan ketersediaan stok dapur.
6. Jika distribusi berhasil, stok dapur berkurang dan jumlah paket yang diterima sekolah bertambah.
7. Data sekolah dan paket dimasukkan ke dalam List melalui class PengelolaMBG.
8. Program menampilkan seluruh data sekolah dan paket makanan.

## 5. Contoh Perhitungan

Program menggunakan dua jenis paket makanan dengan ketentuan:

| Jenis Paket | Harga per Paket | Stok Awal |
|---|---:|---:|
| Paket Reguler | Rp15.000 | 100 |
| Paket Khusus | Rp20.000 | 50 |

Contoh distribusi:

| Sekolah | Jenis Paket | Jumlah Dikirim | Total Biaya |
|---|---|---:|---:|
| SMA Negeri 1 Lamongan | Reguler | 30 | Rp450.000 |
| SMP Negeri 2 Lamongan | Khusus | 20 | Rp400.000 |

Setelah distribusi berhasil, stok Paket Reguler menjadi 70 paket dan stok Paket Khusus menjadi 30 paket.

## 6. Teknologi yang Digunakan

- Bahasa Pemrograman: C#
- Platform: .NET
- IDE: Microsoft Visual Studio
- Jenis Aplikasi: Console Application

## 7. Kesimpulan

Sistem Manajemen Distribusi MBG merupakan implementasi sederhana Pemrograman Berorientasi Objek menggunakan C#.

Melalui program ini, konsep Class, Object, Encapsulation, Inheritance, Polymorphism, Abstract Class, Interface, List, dan Aggregation diterapkan dalam sebuah sistem pengelolaan distribusi makanan.

Program ini diharapkan dapat membantu memahami bagaimana konsep Pemrograman Berorientasi Objek diterapkan untuk menyelesaikan permasalahan pengelolaan data dan distribusi paket makanan secara terstruktur.
