import sys
import json
from concurrent.futures import ThreadPoolExecutor
from playwright.sync_api import sync_playwright
from scrapers.packlink import cerca_packlink
from scrapers.spediscoIo import cerca_SpediscoIo
from scrapers.paccofacile import cercaPaccoFacile
import os
import subprocess

#  funzione  per ogni thread
def esegui_task(nome_scraper, funzione_scraper, dati):
    print(f"Avvio {nome_scraper}...")
    try:
        with sync_playwright() as p:
            # Ogni thread apre il suo browser indipendente
            browser = p.chromium.launch(headless=True)
            page = browser.new_page()
            
            risultato = funzione_scraper(page, dati)
            
            browser.close()
            return risultato
    except Exception as e:
        print(f"Errore in {nome_scraper}: {e}")
        return []

# utilizziamo i thread per eseguire contemporaneamente i vari siti
def main():
    num_thread=3
    try:
        input_data = sys.stdin.read()
        if not input_data: return
        dati_csharp = json.loads(input_data)
        
        # percorso per salvare i dati
        cartella_script = os.path.dirname(os.path.abspath(__file__))
        percorso_file = os.path.join(cartella_script, "sessione_spedizione.json")
    
    # Salviamo i dati su disco esclusivamente per la funziona acquista_paccofacile
        with open(percorso_file, "w", encoding="utf-8") as f:
            json.dump(dati_csharp, f, indent=4)
        
        lista_totale = []

        # Utilizzo dei Thread per eseguire gli scraper contemporaneamente
        
        with ThreadPoolExecutor(num_thread) as executor:
            # Inviamo i lavori ai thread
            future_pack = executor.submit(esegui_task, "Packlink", cerca_packlink, dati_csharp)
            future_io = executor.submit(esegui_task, "SpediscoIo", cerca_SpediscoIo, dati_csharp)
            future_pacco = executor.submit(esegui_task, "PaccoFacile", cercaPaccoFacile, dati_csharp)

            # Recuperiamo i risultati (il programma aspetta qui finché tutti non hanno finito)
            lista_totale.extend(future_pack.result())
            lista_totale.extend(future_io.result())
            lista_totale.extend(future_pacco.result())

        # 3. Invio al C++ 
        json_finale = json.dumps(lista_totale)


      # percorso universale per windows
        cartella_corrente = os.path.dirname(os.path.abspath(__file__))
        cartella_base = os.path.dirname(cartella_corrente)

        # Componiamo il percorso dinamicamente
        
        percorso_cpp = os.path.join(cartella_base, "Modulo_C++","ordinatore_offerte.exe")
        
        if not os.path.exists(percorso_cpp):
    # Inviamo un messaggio di errore strutturato che il C# possa leggere
            errore = (
        "\nERRORE CRITICO: Compilazione C++ mancante!\n"
        "Il file 'ordinatore_offerte.exe' non è stato trovato.\n"
        "Per favore, esegui il comando 'make' nella cartella 'Modulo_C++' prima di continuare."
        )
            print(errore)
            sys.exit(1)
        

        # processo
        processo_cpp = subprocess.Popen(
            [percorso_cpp],
            stdin=subprocess.PIPE,
            stdout=subprocess.PIPE,
            text=True,
            encoding='utf-8',
            creationflags=0x08000000
        )
        # risposta dal c++
    
        risposta_dal_cpp, errori = processo_cpp.communicate(input=json_finale)

        if risposta_dal_cpp:
            print(f"{risposta_dal_cpp.strip()}")

    except Exception as e:
        print(f"Errore nello scambio: {e}")

if __name__ == "__main__":
    main()