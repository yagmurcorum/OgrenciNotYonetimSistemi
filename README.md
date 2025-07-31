# Öğrenci Not Yönetim Sistemi (C# Windows Forms)

Bu proje, **C# Windows Forms** ve **Microsoft Access (OLEDB)** kullanılarak geliştirilmiş bir öğrenci not yönetim sistemidir.  
Proje, öğrencilerin notlarını yönetmek, geçme notlarını hesaplamak ve çeşitli işlemleri kolayca gerçekleştirmek için tasarlanmıştır.
Proje, temel CRUD işlemleri, not hesaplama, filtreleme ve SQL işlemleri gibi önemli kavramları içermektedir.

## Özellikler

- Öğrenci Ekle / Güncelle / Sil  
- Rastgele Öğrenci Üretimi (Benzersiz ID ataması)  
- Rastgele Vize, Final, Ödev Notu Ekleme  
- Geçme Notu Hesaplama  
  - Formül:  
    `GeçmeNotu = Vize * 0.3 + Final * 0.5 + Ödev * 0.2`  
- Ortalama Üstü Öğrencileri Listeleme  
- Kalan Öğrencileri Listeleme  
- Tüm Öğrencileri Görüntüleme  

##  Arayüz
Projede Windows Forms kullanılmıştır.  

## Kullanılan Teknolojiler

- Programlama Dili: **C# (.NET Framework)**  
- Arayüz: **Windows Forms**  
- Veritabanı: **Microsoft Access (.accdb)**  
- Veri Bağlantısı: **OLEDB**

##  Proje Dosya Yapısı

- `Form1.cs`: Projenin tüm mantık kodlarını ve event handler’larını içerir.  
- `database6.accdb`: Microsoft Access veritabanı dosyası. Öğrenci bilgileri ve notlar bu dosyada saklanır.  
- `bin/Debug`: Projenin derlenmiş çalıştırılabilir dosyalarını içerir.


## Veritabanı (SQL) Hakkında

- Öğrenci verileri `Ogrenciler` tablosunda tutulmaktadır.  
- Tabloda sütunlar şunlardır:  
  - `ID` (int, benzersiz öğrenci numarası)  
  - `Vize` (int)  
  - `Final` (int)  
  - `Ödev` (int)  
  - `GeçmeNotu` (double) — Hesaplanan geçme notu.  
- SQL sorguları Access veritabanına OLEDB üzerinden gönderilmektedir.  
- Örnek SQL sorguları:  
  ```sql
  SELECT * FROM Ogrenciler WHERE ID = @id
  UPDATE Ogrenciler SET Vize = @vize, Final = @final, Ödev = @odev WHERE ID = @id
  DELETE FROM Ogrenciler WHERE ID = @id
  
## Nasıl Kullanılır?
Öğrenci Üret: Girilen sayı kadar rastgele benzersiz öğrenci ID’si oluşturur.
Ara: Girilen ID’ye göre öğrenci bilgilerini getirir.
Kayıt Ekle: Manuel olarak yeni öğrenci ve notları ekler.
Kayıt Güncelle: Seçilen öğrencinin notlarını günceller.
Kayıt Sil: Seçilen öğrenciyi siler.
Rastgele Vize / Final / Ödev: Tablodaki tüm öğrencilere rastgele notlar atar.
Geçme Notu Hesapla: Tüm öğrencilerin geçme notlarını hesaplar ve veritabanına kaydeder.
Ortalama Üstü Öğrenciler: Ortalama geçme notunun üzerinde olan öğrencileri listeler.
Kalan Öğrenciler: Geçme notu 60’ın altında olan öğrencileri gösterir.

## NOT : Bu proje, eğitim amaçlı geliştirilmiştir ve gerçek dünya uygulamalarında güvenlik, hata kontrolü gibi ek önlemler alınmalıdır.
