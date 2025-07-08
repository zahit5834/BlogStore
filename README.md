# BlogStore - Modern Blog Yönetim Sistemi

## 📋 Proje Hakkında

BlogStore, .NET 9.0 kullanılarak geliştirilmiş modern bir blog yönetim sistemidir. Clean Architecture (Temiz Mimari) prensiplerine uygun olarak tasarlanmış, kullanıcı dostu arayüzü ve gelişmiş özellikleri ile dikkat çeken bir web uygulamasıdır.

## 🏗️ Mimari Yapı

Proje, N-Tier (Çok Katmanlı) mimari pattern'i kullanılarak geliştirilmiştir:

### 📁 Katmanlar

- **BlogStore.EntityLayer**: Veritabanı entity'leri ve domain modelleri
- **BlogStore.DataAccessLayer**: Veri erişim katmanı (Entity Framework Core)
- **BlogStore.BusinessLayer**: İş mantığı katmanı ve servisler
- **BlogStore.PresentationLayer**: Web arayüzü (ASP.NET Core MVC)

## 🚀 Özellikler

### 👥 Kullanıcı Yönetimi
- **Identity Framework** ile güvenli kimlik doğrulama
- Kullanıcı kayıt ve giriş sistemi
- Şifre değiştirme özelliği
- Kullanıcı profil yönetimi

### 📝 İçerik Yönetimi
- **Makale Oluşturma ve Düzenleme**: Yazarlar kategorilere göre makale oluşturabilir
- **Kategori Yönetimi**: Admin panelinden kategori ekleme/düzenleme
- **SEO Dostu URL'ler**: SlugHelper ile otomatik slug oluşturma
- **Resim Yükleme**: Makaleler için görsel desteği

### 💬 Yorum Sistemi
- **Gerçek Zamanlı Yorumlar**: AJAX ile dinamik yorum ekleme
- **Toxicity Detection**: Hugging Face API ile zararlı içerik kontrolü
- **Yorum Moderasyonu**: Admin panelinden yorum yönetimi

### 🌐 Çok Dilli Destek
- **Google Translate API** entegrasyonu
- Türkçe-İngilizce çeviri desteği
- Otomatik çeviri servisleri

### 🎨 Modern UI/UX
- **Bootstrap 5** ile responsive tasarım
- **Flexy Bootstrap Lite** admin teması
- **Blogy** blog teması
- Modern ve kullanıcı dostu arayüz

## 🛠️ Teknolojiler

### Backend
- **.NET 9.0** - En güncel .NET framework
- **ASP.NET Core MVC** - Web framework
- **Entity Framework Core** - ORM
- **Identity Framework** - Kimlik doğrulama
- **FluentValidation** - Veri doğrulama

### Frontend
- **Bootstrap 5** - CSS framework
- **jQuery** - JavaScript kütüphanesi
- **AOS (Animate On Scroll)** - Animasyonlar
- **Custom CSS/SCSS** - Özel stiller

### Veritabanı
- **SQL Server** - Ana veritabanı
- **Entity Framework Migrations** - Veritabanı versiyonlama

### API Entegrasyonları
- **Google Translate API** - Çeviri servisleri
- **Hugging Face API** - AI tabanlı içerik analizi

## 📊 Veritabanı Yapısı

### Ana Tablolar
- **Articles**: Makale bilgileri (ID, başlık, içerik, slug, tarih, kategori, yazar)
- **Categories**: Kategori bilgileri
- **Comments**: Yorum sistemi
- **AppUsers**: Kullanıcı bilgileri (Identity tabanlı)
- **Tags**: Etiket sistemi

### İlişkiler
- Makale ↔ Kategori (Many-to-One)
- Makale ↔ Kullanıcı (Many-to-One)
- Makale ↔ Yorum (One-to-Many)
- Kullanıcı ↔ Yorum (One-to-Many)

## 🔧 Kurulum ve Çalıştırma

### Gereksinimler
- .NET 9.0 SDK
- SQL Server
- Visual Studio 2022 veya VS Code

### Kurulum Adımları

1. **Projeyi klonlayın**
   ```bash
   git clone [repository-url]
   cd BlogStore
   ```

2. **Veritabanı bağlantısını yapılandırın**
   - `BlogStore.DataAccessLayer/Context/BlogContext.cs` dosyasında connection string'i güncelleyin
   - Migration'ları çalıştırın:
   ```bash
   dotnet ef database update
   ```

3. **API Anahtarlarını yapılandırın**
   - `appsettings.json` dosyasında:
     - Google Translate API Key
     - Hugging Face API Key

4. **Projeyi çalıştırın**
   ```bash
   dotnet run --project BlogStore.PresentationLayer
   ```

## 🔐 Güvenlik Özellikleri

- **Identity Framework** ile güvenli kimlik doğrulama
- **Authorization** ile rol tabanlı erişim kontrolü
- **HTTPS** zorunluluğu
- **Anti-forgery token** koruması
- **Input validation** ile güvenlik kontrolleri

## 📱 Responsive Tasarım

- Mobil uyumlu tasarım
- Bootstrap grid sistemi
- Esnek layout yapısı
- Touch-friendly arayüz

## 🎯 Kullanım Senaryoları

### 👤 Normal Kullanıcı
- Makaleleri görüntüleme
- Yorum yapma
- Kategori bazlı arama
- Kullanıcı kaydı ve girişi

### ✍️ Yazar
- Makale oluşturma ve düzenleme
- Kendi makalelerini yönetme
- Profil bilgilerini güncelleme

### 👨‍💼 Admin
- Kategori yönetimi
- Yorum moderasyonu
- Kullanıcı yönetimi
- Sistem ayarları

## 🔄 Geliştirme Süreci

### Katmanlı Mimari Avantajları
- **Separation of Concerns**: Her katmanın kendi sorumluluğu
- **Maintainability**: Kolay bakım ve güncelleme
- **Testability**: Birim testleri için uygun yapı
- **Scalability**: Ölçeklenebilir mimari

### Dependency Injection
- **Microsoft.Extensions.DependencyInjection** kullanımı
- Loose coupling (gevşek bağlılık)
- Test edilebilir kod yapısı

## 📈 Gelecek Planları

- [ ] **Real-time notifications** - WebSocket entegrasyonu
- [ ] **Advanced search** - Elasticsearch entegrasyonu
- [ ] **Social media integration** - Sosyal medya paylaşımı
- [ ] **Analytics dashboard** - İstatistik paneli
- [ ] **Multi-language support** - Çoklu dil desteği
- [ ] **API documentation** - Swagger entegrasyonu

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 📞 İletişim

Proje hakkında sorularınız için:
- **Email**: [your-email@example.com]
- **GitHub**: [your-github-profile]

---

**Not**: Bu proje eğitim amaçlı geliştirilmiştir ve production ortamında kullanmadan önce güvenlik testlerinden geçirilmelidir.