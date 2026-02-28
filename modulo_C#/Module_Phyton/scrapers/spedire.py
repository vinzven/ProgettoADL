import sys



def cercaSpedire(page,dati):
    
    print("Scraping io spedire...", file=sys.stderr)
    offerte = []

    try:
        # --- 1. AVVIO ---
        page.goto("https://www.spedire.com/")
    
    except Exception as e:

        
        print(f"Errore spediscoIo: {e}", file=sys.stderr)
        
    
    try:
        try:
             page.get_by_role("button", name="Accetta tutto").click()(timeout=3000)
    
    
        except:
            pass

        nazMit= dati['sender']['country'].split(" -")[0]
        citMit= dati['sender']['city']
        capMit= dati['sender']['ZIP']
        nazDest=dati['receiver']['country'].split(" -")[0]
        citDest=dati['receiver']['city']
        capDest=dati['receiver']['ZIP']
        
        
        selettoreDest=page.get_by_role("searchbox", name="Cap destinazione")
        inputMit=page.locator("input[placeholder='Seleziona Nazione']")
        inputDest="#input-shipment-country-destinazione"
        
        peso=page.get_by_role("textbox", name="peso in kg")
        lunghezza=page.get_by_role("textbox", name="Lato 1 in cm")
        larghezza=page.get_by_role("textbox", name="Lato 2 in cm")
        altezza = page.get_by_role("textbox", name="Lato 3 in cm")
        
        
        page.get_by_role("link", name="Cambia nazione").first.click()
        page.wait_for_timeout(1000)
        page.get_by_role("link", name="Cambia nazione").click()
        page.wait_for_timeout(1000)
        inputMit.click()
        
        inputMit.press_sequentially(nazMit, delay=100)
        
        page.wait_for_timeout(2000)
        
        page.keyboard.press("Enter")
        
        
        
        
        
    except Exception as e:
        print(f"Errore Packlink: {e}", file=sys.stderr)
        
    return offerte