#!/bin/bash
# Build script for Jellyfin Sticker Album Plugin

set -e

PROJECT_NAME="JellyfinStickerAlbum"
FRAMEWORK="net6.0"
OUTPUT_DIR="bin/Release/${FRAMEWORK}/publish"

echo "🔨 Building ${PROJECT_NAME}..."
dotnet restore
dotnet publish -c Release -f "${FRAMEWORK}" -o "${OUTPUT_DIR}" --no-self-contained

echo ""
echo "✅ Build complete! Files in: ${OUTPUT_DIR}"
echo ""
echo "Installation:"
echo "  Linux:  sudo cp ${OUTPUT_DIR}/${PROJECT_NAME}.dll /var/lib/jellyfin/plugins/StickerAlbum/"
echo "          sudo systemctl restart jellyfin"
echo "  Docker: docker cp ${OUTPUT_DIR}/${PROJECT_NAME}.dll jellyfin:/jellyfin/plugins/StickerAlbum/"
echo "          docker restart jellyfin"
