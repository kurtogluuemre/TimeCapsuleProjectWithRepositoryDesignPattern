using EFQuiz.CORE.Enums;
using EFQuiz.REPO.Contexts;
using EFQuiz.REPO.UnitOfWorks;
using EFQuiz.SERVICE.IUnitOfWorks;

namespace EFQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Veritabanı işlemleri için  önce bir Context nesnemi oluşturuyorum.
            // Bu contexti kullanarak ManagerRepo nesnemi oluşturuyorum. ve ardından bu ManagerREpoyla bir UnitOFWorks nesnemi oluşturuyorum
            // UnitOfWorks doğrudan repositoryle değilde oluşturduğum Servis Katmaıyla database işlemlerimi gerçekleştirmemi sağlar.
            var context = new TimeCapDbContext();
            var manager = new ManagerRepo(context);
            var unitOfWorks = new UnitOfWorks(manager);
            var capsuleService = unitOfWorks.CapsuleService;

            bool islemeDevamMi = true;

            while (islemeDevamMi)
            {
                Console.WriteLine(new string('*',35));
                Console.WriteLine("--- Hoş Geldiniz ---");
                Console.WriteLine("1 - Yeni kapsül oluştur/2 - Kapsüle içerik ekle/3 - Tüm kapsülleri listele/4 - Açılma tarihi geçmiş kapsülleri görüntüle/5 - Kapsül Detayları/6 - Rapor: En fazla içeriğe sahip kapsüller/7 - Rapor: En çok kullanılan içerik türü/0 - Çıkış");
                Console.Write("Seçiminiz: ");
                var secim = Console.ReadLine();

                try
                {
                    switch (secim)
                    {
                        case "1":
                            Console.Write("Kapsül Başlığı: ");
                            string title = Console.ReadLine();
                            Console.Write("Açılma Tarihi (yıl-gün-ay): ");
                            DateTime openDate = DateTime.Parse(Console.ReadLine());

                            capsuleService.CreateCapsule(title, openDate);
                            Console.WriteLine("Kapsül oluşturuldu.");
                            break;

                        case "2":
                            Console.Write("Kapsül ID: ");
                            int capId = int.Parse(Console.ReadLine());
                            Console.Write("İçerik Metni: ");
                            string text = Console.ReadLine();
                            Console.WriteLine("İçerik Türü (1:Text, 2:Image, 3:Thought, 4:Memory): ");
                            ContentType contentType = (ContentType)int.Parse(Console.ReadLine());

                            capsuleService.AddContentToCapsule(capId, text, contentType);
                            Console.WriteLine("İçerik eklendi.");
                            break;

                        case "3":
                            var all = capsuleService.GetAllCapsules();
                            Console.WriteLine("--- Tüm Kapsüller ---");
                            foreach (var item in all)
                            {
                                Console.WriteLine($"{item.Id} - {item.Title} (Açılma: {item.OpenDate})");
                            }
                            break;

                        case "4":
                            var acilmis = capsuleService.GetOpenedCapsules();
                            Console.WriteLine("--- Açılmış Kapsüller ---");
                            foreach (var item in acilmis)
                            {
                                Console.WriteLine($"{item.Id} - {item.Title}  Açıldığı tarih: {item.OpenDate}");
                            }
                            break;

                        case "5":
                            Console.Write("Kapsül ID: ");
                            int detailId = int.Parse(Console.ReadLine());
                            var kapsul = capsuleService.GetCapsuleDetails(detailId);

                            if (kapsul != null)
                            {
                                Console.WriteLine($"Başlık: {kapsul.Title} - Açılma Tarihi: {kapsul.OpenDate}");
                                foreach (var item in kapsul.Contents)
                                {
                                    Console.WriteLine($"- {item.ContentType}: {item.Text}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Kapsül bulunamadı.");
                            }
                            break;

                        case "6":
                            var toplamKapsul = capsuleService.GetTopCapsulesByContentCount(3);
                            Console.WriteLine("--- En Fazla İçeriğe Sahip Kapsüller ---");
                            foreach (var item in toplamKapsul)
                            {
                                Console.WriteLine($"{item.Id} - {item.Title} | İçerik Sayısı: {item.Contents.Count}");
                            }
                            break;

                        case "7":
                            var enCokKullanilan = capsuleService.GetMostUsedContentType();
                            Console.WriteLine($"En çok kullanılan içerik türü: {enCokKullanilan}");
                            break;

                        case "0":
                            islemeDevamMi = false;
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçim.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }
        }
    }
}
