using System;
using System.Collections.Generic;
using System.IO;
using FinalHomework;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        while (true)
        {
            try
            {
                // Uçak bilgilerini kullanıcıdan alma
                Console.WriteLine("\nUçak Bilgileri");
                Console.Write("Model: ");
                string model = ReadNonEmptyInput();

                Console.Write("Marka: ");
                string marka = ReadNonEmptyInput();

                Console.Write("Seri No: ");
                string seriNo = ReadNonEmptyInput();

                Console.Write("Koltuk Kapasitesi: ");
                int koltukKapasitesi;
                while (!int.TryParse(ReadNonEmptyInput(), out koltukKapasitesi))
                {
                    Console.WriteLine("Geçerli bir sayı giriniz.");
                }

                Ucak ucak = new Ucak { UcakModel = model, Marka = marka, SeriNo = seriNo, KoltukKapasitesi = koltukKapasitesi };

                // Lokasyon bilgilerini kullanıcıdan alma
                Console.WriteLine("\nLokasyon Bilgileri");
                Console.Write("Kalkış Ülke: ");
                string kalkisUlke = ReadNonEmptyInput();

                Console.Write("Kalkış Şehir: ");
                string kalkisSehir = ReadNonEmptyInput();

                Console.Write("Varış Ülke: ");
                string varisUlke = ReadNonEmptyInput();

                Console.Write("Varış Şehir: ");
                string varisSehir = ReadNonEmptyInput();

                Console.Write("Kalkış Havaalanı: ");
                string kalkisHavaalani = ReadNonEmptyInput();

                Console.Write("Varış Havaalanı: ");
                string varisHavaalani = ReadNonEmptyInput();

                Console.Write("Kalkış Lokasyon Aktif/Pasif (True/False): ");
                bool kalkisAktifPasif;
                while (!bool.TryParse(ReadNonEmptyInput(), out kalkisAktifPasif))
                {
                    Console.WriteLine("Geçerli bir boolean değeri giriniz.");
                }

                Console.Write("Varış Lokasyon Aktif/Pasif (True/False): ");
                bool varisAktifPasif;
                while (!bool.TryParse(ReadNonEmptyInput(), out varisAktifPasif))
                {
                    Console.WriteLine("Geçerli bir boolean değeri giriniz.");
                }

                Lokasyon kalkis = new Lokasyon { Ulke = kalkisUlke, Sehir = kalkisSehir, Havaalani = kalkisHavaalani, AktifPasif = kalkisAktifPasif };
                Lokasyon varis = new Lokasyon { Ulke = varisUlke, Sehir = varisSehir, Havaalani = varisHavaalani, AktifPasif = varisAktifPasif };

                // Uçuş bilgilerini kullanıcıdan alma
                Console.WriteLine("\nUçuş Bilgileri");
                Console.Write("Saat: ");
                string saat = ReadNonEmptyInput();

                Ucus ucus = new Ucus { KalkisLokasyon = kalkis, VarisLokasyon = varis, Saat = saat, UcakBilgisi = ucak };

                // Rezervasyon bilgilerini kullanıcıdan alma
                Console.WriteLine("\nRezervasyon Bilgileri");
                Console.Write("Ad: ");
                string ad = ReadNonEmptyInput();

                Console.Write("Soyad: ");
                string soyad = ReadNonEmptyInput();

                int yas;
                while (!int.TryParse(ReadNonEmptyInput("Yaş"), out yas))
                {
                    Console.WriteLine("Geçerli bir sayı giriniz.");
                }

                Rezervasyon rezervasyon = new Rezervasyon { Ucus = ucus, Ad = ad, Soyad = soyad, Yas = yas };

                if (!rezervasyon.RezervasyonYap(ucus))
                {
                    Console.WriteLine("Yeni uçuş bilgisi girerek rezervasyon yapabilirsiniz.");
                    continue;
                }

                // Kullanıcının girdiği bilgileri ekrana yazdırma
                Console.WriteLine("\nGirilen Bilgiler:");
                Console.WriteLine($"Uçak: {ucak.UcakModel} - {ucak.Marka} - {ucak.SeriNo} - {ucak.KoltukKapasitesi} koltuk");
                Console.WriteLine($"Kalkış Lokasyon: {kalkis.Ulke} - {kalkis.Sehir} - {kalkis.Havaalani} - Aktif: {kalkis.AktifPasif}");
                Console.WriteLine($"Varış Lokasyon: {varis.Ulke} - {varis.Sehir} - {varis.Havaalani} - Aktif: {varis.AktifPasif}");
                Console.WriteLine($"Uçuş: Saat {ucus.Saat} - {ucus.KalkisLokasyon.Ulke} - {ucus.KalkisLokasyon.Sehir} -> {ucus.VarisLokasyon.Ulke} - {ucus.VarisLokasyon.Sehir}");
                Console.WriteLine($"Rezervasyon: {rezervasyon.Ad} {rezervasyon.Soyad} - Yaş: {rezervasyon.Yas}");

                // Kullanıcıdan çıkış yapmak isteyip istemediğini sorma
                Console.Write("\n");
                // Kullanıcıdan çıkış yapmak isteyip istemediğini sorma
                Console.Write("\nDevam etmek istiyor musunuz? (Evet/Hayır): ");
                string devamEt = Console.ReadLine().ToLower();

                if (devamEt != "evet")
                    break;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                Console.WriteLine("Lütfen doğru formatta veri girdiğinizden emin olun.");
            }
        }
    }

    // Boş input kontrolü
    static string ReadNonEmptyInput(string prompt = null)
    {
        string input;
        do
        {
            if (!string.IsNullOrEmpty(prompt))
                Console.Write(prompt + ": ");
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("Bu alan boş bırakılamaz. Lütfen tekrar girin.");
        } while (string.IsNullOrEmpty(input));
        return input;
    }
}

