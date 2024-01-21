using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHomework
{
    public class Rezervasyon
    {
        public Ucus Ucus { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public Boolean RezervasyonYap(Ucus ucus)
        {
            if (!ucus.VarisLokasyon.AktifPasif || !ucus.KalkisLokasyon.AktifPasif)
            {
                Console.WriteLine("Lokasyon Pasif Olduğundan Rezervasyon yapılamadı.");
                return false;
            }

            if (Yas >= 18 && Ucus.UcakBilgisi.KoltukKapasitesi > 0)
            {
                string FilePath = AppDomain.CurrentDomain.BaseDirectory;
                Ucus.UcakBilgisi.KoltukKapasitesi--;
                Console.WriteLine("Rezervasyon başarıyla yapıldı.");

                // Nesneleri JSON formatına çevirip dosyaya yazma
                string ucakJson = JsonConvert.SerializeObject(ucus.UcakBilgisi);
                File.AppendAllText(Path.Combine(FilePath, "Ucak.json"), ucakJson + Environment.NewLine);

                string ucusJson = JsonConvert.SerializeObject(ucus);
                File.AppendAllText(Path.Combine(FilePath, "Ucus.json"), ucusJson + Environment.NewLine);

                // Rezervasyon bilgilerini dosyaya yazma
                string rezervasyonJson = JsonConvert.SerializeObject(this);
                File.AppendAllText(Path.Combine(FilePath, "Rezervasyonlar.json"), rezervasyonJson + Environment.NewLine);

                Console.WriteLine("Rezervasyon bilgileri dosyalara kaydedildi.");

                return true;
            }
            else
            {
                if (Yas < 18)
                {
                    Console.WriteLine("Yaşınız 18'den Küçük Olduğu İçin Rezervasyon yapılamadı.");
                }
                else if (Ucus.UcakBilgisi.KoltukKapasitesi <= 0)
                {
                    Console.WriteLine("Boş Koltuk Kalmadığı için Rezervasyon yapılamadı.");
                }

                return false;
            }
        }
    }
}
