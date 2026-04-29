# 🎬 Jellyfin Sticker Album Plugin

[![Build & Release](https://github.com/joy423/jellyfin-sticker-album/actions/workflows/release.yml/badge.svg)](https://github.com/joy423/jellyfin-sticker-album/actions)
[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.8+-purple)](https://jellyfin.org)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](LICENSE)

Sammle Sticker während du Videos in Jellyfin schaust! 🎮

## ✨ Features

| Seltenheit | Chance | Animation |
|---|---|---|
| 👑 Legendär | 2 % | Spektakulär |
| ⚡ Episch | 8 % | Power-Effekt |
| ✨ Premium | 30 % | Glatte Animation |
| ⭐ Normal | 60 % | Standard |

- 20 Sticker-Slots zum Sammeln
- Automatischer Timer (Standard: 15 Minuten)
- Sound-Effekte via Tone.js
- Konfigurierbar über Jellyfin Plugin-Settings

## 🚀 Installation (über Jellyfin Plugin-Katalog)

1. Öffne **Jellyfin → Dashboard → Plugins → Katalog**
2. Klicke auf das ⚙️ Icon → **Repositories verwalten**
3. Füge diese URL hinzu:
   ```
   https://raw.githubusercontent.com/joy423/jellyfin-sticker-album/main/manifest.json
   ```
4. Suche nach **"Sticker Album"** → Installieren
5. Jellyfin neustarten

## 🔧 Manuell bauen

```bash
git clone https://github.com/joy423/jellyfin-sticker-album.git
cd jellyfin-sticker-album
dotnet publish -c Release -f net6.0 -o publish --no-self-contained
sudo cp publish/JellyfinStickerAlbum.dll /var/lib/jellyfin/plugins/StickerAlbum/
sudo systemctl restart jellyfin
```

## ⚙️ Konfiguration

`/etc/jellyfin/plugins/JellyfinStickerAlbum/config.xml`

```xml
<PluginConfiguration>
  <WatchDurationMinutes>15</WatchDurationMinutes>
  <TotalStickerSlots>20</TotalStickerSlots>
  <EnableSoundEffects>true</EnableSoundEffects>
  <LegendaryProbability>0.02</LegendaryProbability>
  <EpicProbability>0.08</EpicProbability>
  <PremiumProbability>0.30</PremiumProbability>
</PluginConfiguration>
```

## 📡 API

| Method | Endpoint | Beschreibung |
|---|---|---|
| GET | `/api/plugins/stickeralbum/album/{userId}` | Album laden |
| POST | `/api/plugins/stickeralbum/album/{userId}` | Album speichern |
| POST | `/api/plugins/stickeralbum/earn/{userId}` | Sticker verdienen |
| GET | `/api/plugins/stickeralbum/config` | Konfiguration lesen |
| DELETE | `/api/plugins/stickeralbum/album/{userId}` | Album zurücksetzen |

## 📁 Projektstruktur

```
jellyfin-sticker-album/
├── .github/workflows/release.yml   # Auto-Build bei Tag-Push
├── Configuration/
│   └── PluginConfiguration.cs
├── Controllers/
│   └── StickerController.cs
├── Models/
│   └── StickerAlbumData.cs
├── web/
│   └── index.html
├── Plugin.cs
├── JellyfinStickerAlbum.csproj
├── manifest.json
└── build.sh
```

## 📄 Lizenz

MIT © joy423
