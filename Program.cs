namespace Kütüphane_Yönetim_Sistemi_Library_Management_System_
{
    class Program
    {
        // Kitap sınıfı
        class Kitap
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public string Yazar { get; set; }
            public string Tur { get; set; }
            public int YayinYili { get; set; }
        }

        // Kitap listesi
        static List<Kitap> kitaplar = new List<Kitap>();
        static int kitapIdSayaci = 1;

        static void Main()
        {
            while (true)
            {
                AnaMenu();
            }
        }

        // Ana Menü
        static void AnaMenu()
        {
            Console.WriteLine("\n=== Kütüphane Yönetim Sistemi ===");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Güncelle");
            Console.WriteLine("5. Kitap Sil");
            Console.WriteLine("6. Çıkış");
            Console.Write("Seçiminizi yapın: ");

            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    KitapEkle();
                    break;
                case "2":
                    KitaplariListele();
                    break;
                case "3":
                    KitapAra();
                    break;
                case "4":
                    KitapGuncelle();
                    break;
                case "5":
                    KitapSil();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;
            }
        }

        // Kitap Ekle
        static void KitapEkle()
        {
            Console.WriteLine("\n=== Yeni Kitap Ekle ===");
            Kitap yeniKitap = new Kitap
            {
                Id = kitapIdSayaci++
            };

            Console.Write("Kitap Adı: ");
            yeniKitap.Ad = Console.ReadLine();

            Console.Write("Yazar: ");
            yeniKitap.Yazar = Console.ReadLine();

            Console.Write("Tür: ");
            yeniKitap.Tur = Console.ReadLine();

            Console.Write("Yayın Yılı: ");
            yeniKitap.YayinYili = int.Parse(Console.ReadLine());

            kitaplar.Add(yeniKitap);
            Console.WriteLine("Kitap başarıyla eklendi.");
        }

        // Kitapları Listele
        static void KitaplariListele()
        {
            Console.WriteLine("\n=== Tüm Kitaplar ===");
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Henüz hiç kitap eklenmedi.");
                return;
            }

            foreach (var kitap in kitaplar)
            {
                Console.WriteLine($"ID: {kitap.Id}, Ad: {kitap.Ad}, Yazar: {kitap.Yazar}, Tür: {kitap.Tur}, Yayın Yılı: {kitap.YayinYili}");
            }
        }

        // Kitap Ara
        static void KitapAra()
        {
            Console.Write("\nAramak istediğiniz kitabın adını yazın: ");
            string arama = Console.ReadLine()?.ToLower();

            var sonuc = kitaplar.FindAll(k => k.Ad.ToLower().Contains(arama));
            if (sonuc.Count == 0)
            {
                Console.WriteLine("Aradığınız kitap bulunamadı.");
            }
            else
            {
                Console.WriteLine("\nArama Sonuçları:");
                foreach (var kitap in sonuc)
                {
                    Console.WriteLine($"ID: {kitap.Id}, Ad: {kitap.Ad}, Yazar: {kitap.Yazar}, Tür: {kitap.Tur}, Yayın Yılı: {kitap.YayinYili}");
                }
            }
        }

        // Kitap Güncelle
        static void KitapGuncelle()
        {
            Console.Write("\nGüncellemek istediğiniz kitabın ID'sini girin: ");
            int id = int.Parse(Console.ReadLine());

            var kitap = kitaplar.Find(k => k.Id == id);
            if (kitap == null)
            {
                Console.WriteLine("Kitap bulunamadı.");
                return;
            }

            Console.Write("Yeni Kitap Adı (boş bırakılırsa değişmez): ");
            string yeniAd = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yeniAd))
            {
                kitap.Ad = yeniAd;
            }

            Console.Write("Yeni Yazar (boş bırakılırsa değişmez): ");
            string yeniYazar = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yeniYazar))
            {
                kitap.Yazar = yeniYazar;
            }

            Console.Write("Yeni Tür (boş bırakılırsa değişmez): ");
            string yeniTur = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yeniTur))
            {
                kitap.Tur = yeniTur;
            }

            Console.Write("Yeni Yayın Yılı (boş bırakılırsa değişmez): ");
            string yeniYayinYili = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(yeniYayinYili))
            {
                kitap.YayinYili = int.Parse(yeniYayinYili);
            }

            Console.WriteLine("Kitap başarıyla güncellendi.");
        }

        // Kitap Sil
        static void KitapSil()
        {
            Console.Write("\nSilmek istediğiniz kitabın ID'sini girin: ");
            int id = int.Parse(Console.ReadLine());

            var kitap = kitaplar.Find(k => k.Id == id);
            if (kitap == null)
            {
                Console.WriteLine("Kitap bulunamadı.");
                return;
            }

            kitaplar.Remove(kitap);
            Console.WriteLine("Kitap başarıyla silindi.");
        }
    }
}
