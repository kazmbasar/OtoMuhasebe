
# OtoMuhasebe - Oto Servis Yönetim Sistemi

OtoMuhasebe, oto servisleri için geliştirilmiş, modern web teknolojilerini kullanan kapsamlı bir müşteri ve araç yönetim sistemidir. Müşteri takibi, araç geçmişi, servis işlemleri, fatura oluşturma ve finansal raporlama özelliklerini içerir.

## 🚀 Özellikler

-   **Dashboard (Panel):** Günlük/Toplam ciro, aktif araç sayısı ve son 7 günlük gelir grafiği.
-   **Müşteri Yönetimi:** Müşteri ekleme, düzenleme, borç/alacak takibi ve işlem geçmişi.
-   **Araç Yönetimi:** Plaka bazlı araç takibi, sahibine göre araç listeleme, aktif/pasif durumu.
-   **İşlem Geçmişi:** Yapılan tüm servis işlemlerinin ve ödemelerin detaylı zaman çizelgesi.
-   **Akıllı Fatura Sihirbazı:** Adım adım fatura oluşturma, müşteri ve araç seçimi, hizmet ekleme.
-   **PDF Fatura:** Oluşturulan faturaların PDF olarak indirilmesi ve yazdırılması.
-   **Mobil Uyumlu Arayüz:** Modern, responsive ve kullanıcı dostu tasarım.

## 🛠️ Teknolojiler

**Backend:**
-   .NET 8.0 (Core)
-   Entity Framework Core
-   C#
-   Mimari: Katmanlı Mimari (N-Tier Architecture)

**Frontend:**
-   React (Vite)
-   TypeScript
-   CSS3 (Modern Variables & Layouts)
-   Lucide React (İkonlar)
-   Recharts (Grafikler)

## 📦 Kurulum

Projeyi yerel ortamınızda çalıştırmak için aşağıdaki adımları izleyin.

### Gereksinimler
-   .NET 8.0 SDK
-   Node.js (v18+)

### 1. Backend Kurulumu

```bash
# Ana dizinde
dotnet restore
cd OtoMuhasebe.Api
dotnet run
```
_Backend varsayılan olarak `http://localhost:5044` adresinde çalışacaktır. Veritabanı bağlantı ayarlarını `appsettings.json` dosyasından kontrol edebilirsiniz._

### 2. Frontend Kurulumu

```bash
# Ana dizinden
cd OtoMuhasebe.Web
npm install
npm run dev
```
_Frontend varsayılan olarak `http://localhost:5173` adresinde çalışacaktır._

## 🗂️ Proje Yapısı

-   **OtoMuhasebe.Api:** RESTful API servisi.
-   **OtoMuhasebe.Web:** React tabanlı kullanıcı arayüzü.
-   **Business:** İş mantığı katmanı.
-   **DataAccess:** Veri erişim katmanı (EF Core).
-   **Domain:** Varlıklar (Entities).

## 🔒 Lisans

Bu proje eğitim ve geliştirme amaçlı oluşturulmuştur.
## 📸 Ekran Görüntüleri
<img width="1909" height="900" alt="Ekran görüntüsü 2025-12-28 181120" src="https://github.com/user-attachments/assets/1caddbc7-878c-4738-b122-b9669ef45573" />
<img width="1902" height="896" alt="Ekran görüntüsü 2025-12-28 181320" src="https://github.com/user-attachments/assets/a58708a0-f1d7-4c79-97c7-680df59b27c9" />
<img width="1915" height="901" alt="Ekran görüntüsü 2025-12-28 181419" src="https://github.com/user-attachments/assets/1fc91afc-2ef8-4be0-8456-9d8f654769e1" />
<img width="1914" height="890" alt="Ekran görüntüsü 2025-12-28 181442" src="https://github.com/user-attachments/assets/4c95eb8b-b008-4b7d-b68e-adbf8f25925b" />
<img width="1908" height="892" alt="Ekran görüntüsü 2025-12-28 181452" src="https://github.com/user-attachments/assets/ec2ea649-3d6e-4c2e-9506-1fdf0f7b963c" />





