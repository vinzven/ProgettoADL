import sys
import os
import json
from playwright.sync_api import sync_playwright
from checkout.packlink import acquisto_packlink 
from checkout.spediscoio import acquisto_spediscoio
from checkout.paccofacile import acquisto_paccofacile





def recupera_sessione():
    # Individua il percorso del file (deve essere lo stesso usato per salvare)
    
    cartella_script = os.path.dirname(os.path.abspath(__file__))
    percorso_file = os.path.join(cartella_script, "sessione_spedizione.json")
    
    try:
        with open(percorso_file, "r", encoding="utf-8") as f:
            # Questa riga trasforma il file in un dizionario Python
            dati = json.load(f)
            return dati
    except FileNotFoundError:
        return None  

# mi indirizza all'offerta
def acquista_migliore_da_url(url_target):
   
    print(f"--- AVVIO MODALITÀ ACQUISTO ---", file=sys.stderr)
    
    with sync_playwright() as p:
        
        # browser visibile cosi l'utente può vedere l'offerta e usarla
        browser = p.chromium.launch(headless=False , channel="chrome", args=["--start-maximized"])
        context = browser.new_context(no_viewport=True)
        page = context.new_page()
        
        try:
            # funzione diversa in base al sito
            if "packlink.it" in url_target:
                acquisto_packlink(page, url_target,prezzo_da_csharp,corriere_da_csharp)
                
            elif "iospedisco.it" in url_target:
                acquisto_spediscoio(page, url_target,prezzo_da_csharp,corriere_da_csharp)
                
            elif "paccofacile.it" in url_target:
                acquisto_paccofacile(page, url_target,prezzo_da_csharp,corriere_da_csharp,dati_sessione)
                pass 
                
            else:
                
                print("Sito non riconosciuto Lo apro in modalità manuale.", file=sys.stderr)

                
        except Exception as e:
            print(f"Errore critico acquisto: {e}", file=sys.stderr)
            page.wait_for_timeout(30000)
            
        try:
            page.wait_for_event("close", timeout=0) 
        except:
            
            # Serve a evitare errori se l'utente chiude il browser proprio mentre lo script sta finendo
            pass
            


if __name__ == "__main__":
    # argomenti passati dal c#
    if len(sys.argv) > 3:
        url_da_csharp = sys.argv[1]
        prezzo_da_csharp = sys.argv[2]
        corriere_da_csharp=sys.argv[3]
        dati_sessione = recupera_sessione()
        acquista_migliore_da_url(url_da_csharp)
    else:
        print("Errore: Nessun URL ricevuto da C#", file=sys.stderr)