@echo off
setlocal
title Installer Dipendenze - Progetto ADL

echo   CONFIGURAZIONE AMBIENTE PYTHON 
:: 1. Creazione ambiente virtuale (Isolamento)
echo [STEP 1/4] Creazione ambiente virtuale 'env' in corso...
python -m venv env
if %errorlevel% neq 0 (
    echo ERRORE: Assicurati che Python sia installato e nel PATH.
    pause
    exit /b
)

:: 2. Attivazione e Installazione Librerie
echo.
echo [STEP 2/4] Installazione librerie da 'requirements.txt'...
echo (playwright==1.57.0, deep-translator==1.11.4)
call env\Scripts\activate
pip install -r requirements.txt

:: 3. Setup specifico per Playwright
echo.
echo [STEP 3/4] Installazione browser Chromium per lo scraping...
playwright install chromium

:: 4. Verifica finale
echo.
echo [STEP 4/4] Verifica finale delle versioni installate...
pip show playwright deep-translator | findstr "Name Version"

echo.
echo   INSTALLAZIONE COMPLETATA CON SUCCESSO!
echo.
pause