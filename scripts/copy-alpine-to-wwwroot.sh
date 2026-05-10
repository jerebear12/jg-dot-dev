#!/bin/sh
# Copy Alpine.js from node_modules to wwwroot for self-hosting
set -e

SRC="node_modules/alpinejs/dist/cdn.min.js"
DEST="wwwroot/js/alpine.js"

if [ ! -f "$SRC" ]; then
    echo "Error: $SRC not found. Run 'aube add alpinejs && aube install' first."
    exit 1
fi

cp "$SRC" "$DEST"
echo "Copied Alpine.js to $DEST"
