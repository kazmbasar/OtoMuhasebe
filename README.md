
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
