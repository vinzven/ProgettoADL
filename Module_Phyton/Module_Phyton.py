import sys
import json
from playwright.sync_api import sync_playwright
from scrapers.packlink import cerca_packlink
from scrapers.spediscoIo import cerca_SpediscoIo


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
            #offerte_pack = cerca_packlink(page, dati_csharp)
            offerte_pack = cerca_SpediscoIo(page,dati_csharp)
           
            lista_totale.extend(offerte_pack)
            
            # Opzionale: Puliamo i cookie o ricarichiamo pagina tra un sito e l'altro
            page.goto("about:blank") 

            browser.close()

        # OUTPUT FINALE PER C++
        print(json.dumps(lista_totale))

    except Exception as e:
        print(json.dumps([{"error": f"Fatal Error Python: {str(e)}"}]))

if __name__ == "__main__":
    main()