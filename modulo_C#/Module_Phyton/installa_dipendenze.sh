#!/bin/bash
set -e  # esce se un comando fallisce

echo "=== Installer Dipendenze - Progetto ADL ==="
echo

# --- 1. Creazione ambiente virtuale ---
echo "[STEP 1/4] Creazione ambiente virtuale 'env' in corso..."
python3 -m venv env || { echo "ERRORE: Assicurati che Python sia installato."; exit 1; }

# --- 2. Attivazione e installazione librerie ---
echo
echo "[STEP 2/4] Installazione librerie da 'requirements.txt'..."
echo "(playwright==1.57.0, deep-translator==1.11.4)"
source env/bin/activate
pip install -r requirements.txt

# --- 3. Setup specifico per Playwright ---
echo
echo "[STEP 3/4] Installazione browser Chromium per lo scraping..."
playwright install chromium

# --- 4. Verifica finale ---
echo
echo "[STEP 4/4] Verifica versioni installate..."
pip show playwright deep-translator | grep -E "Name|Version"

echo
echo "=== INSTALLAZIONE COMPLETATA CON SUCCESSO! ==="