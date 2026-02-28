import sys
import json
from playwright.sync_api import sync_playwright
from scrapers.packlink import cerca_packlink
from scrapers.spediscoIo import cerca_SpediscoIo
from scrapers.paccofacile import cercaPaccoFacile
from scrapers.spedire import cercaSpedire
import os
import subprocess

# MAIN

def main():
       
    try:
        input_data = sys.stdin.read()
        if not input_data: return
        dati_csharp = json.loads(input_data)
        
        lista_totale = []

        with sync_playwright() as p:
            # APRIAMO IL BROWSER IN MODO VISIBILE PER ORA
            browser = p.chromium.launch(headless=False)
            page = browser.new_page()

            # Eseguiamo i siti in sequenza
            offerte_pack = cerca_packlink(page, dati_csharp)
            offerte_ioSpedisco = cerca_SpediscoIo(page,dati_csharp)
            offerte_paccoFacile= cercaPaccoFacile(page,dati_csharp)
            #offerte_spedire = cercaSpedire(page,dati_csharp)
            lista_totale.extend(offerte_pack)
            lista_totale.extend(offerte_ioSpedisco)
            lista_totale.extend(offerte_paccoFacile)
            #lista_totale.extend(offerte_spedire)
            
            # Opzionale: Puliamo i cookie o ricarichiamo pagina tra un sito e l'altro
            page.goto("about:blank") 

            browser.close()
            
            
            json_finale = json.dumps(lista_totale)
            #dati_finti_da_mandare = json.dumps({"messaggio": "Ciao C++, sono Python e ti mando dei dati!"})

# Trovo il percorso dell'eseguibile C++ (basato sulla tua foto)
            cartella_corrente = os.path.dirname(os.path.abspath(__file__))
            cartella_base = os.path.dirname(cartella_corrente)
            percorso_cpp = os.path.join(cartella_base, "Modulo_C++", "x64", "Debug", "Modulo_C++.exe")

            # Configuro il processo (Esattamente come StartInfo in C#)
            processo_cpp = subprocess.Popen(
                [percorso_cpp],
                stdin=subprocess.PIPE,  # RedirectStandardInput = true
                stdout=subprocess.PIPE, # RedirectStandardOutput = true
                text=True,# Per mandare stringhe e non byte
                encoding='utf-8',
                creationflags=subprocess.CREATE_NEW_CONSOLE
            )

            risposta_dal_cpp, errori = processo_cpp.communicate(input=json_finale)

            if risposta_dal_cpp:
                print(f"SCAMBIO COMPLETATO! Python ha questa risposta in mano:\n{risposta_dal_cpp.strip()}")

    except Exception as e:
        print(f"Errore nello scambio: {e}")

    except Exception as e:
        print(json.dumps([{"error": f"Fatal Error Python: {str(e)}"}]))

if __name__ == "__main__":
    main()