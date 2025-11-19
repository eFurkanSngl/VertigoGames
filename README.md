📌 Wheel of Fortune – Technical Summary

Bu proje, Vertigo Games Case Study kapsamında geliştirilen data-driven, event-based ve mobil uyumlu bir Wheel of Fortune oyun sistemidir. Kod yapısı; OOP, SOLID, Zenject ve ScriptableObject prensipleriyle inşa edilmiştir.

🚀 Öne Çıkan Teknikler
🧩 Data-Driven Architecture (ScriptableObject)

Tüm slice içerikleri (SliceData) ve wheel konfigürasyonları (WheelDataSet) SO ile yönetilir.

Bronze / Silver / Gold wheel'ler tamamen editörden değiştirilebilir.

🔔 Event-Driven Flow (Zenject SignalBus)

Spin, sonuç, bomb, leave ve revive tüm akışları SignalBus üzerinden yürür.

UI → Gameplay arasında loosely coupled mimari sağlanır.

🎡 Wheel Animation System

DOTween ile smooth dönen wheel animasyonu

Indicator altındaki doğru slice matematiksel açı ile tespit edilir

Knob’lar stabilizasyon sistemiyle ters dönmez

📦 Inventory & Leave System

Her ödül run boyunca RunInventoryManager içinde tutulur

Leave seçildiğinde ödüller Reward Panel’de prefab tabanlı olarak gösterilir

Bomb gelince tüm ödüller temizlenir

Revive (gold) opsiyonu mevcuttur (bonus)

🖥 Mobile-Ready UI

SafeArea desteği

TMP kullanımı

_value naming standartları

OnClick kullanılmaz; UIBTN + OnValidate ile otomatik button binding

20:9, 16:9 ve 4:3 aspect ratio uyumluluğu sağlanmıştır

⚡ Performans

Gereksiz coroutine/update yok

SO ve event-driven mimari ile GC düşük

Instantiation minimal (reward ekranı)

Pool gerektirecek yoğunluk olmadığı için sade ve hızlı yap
