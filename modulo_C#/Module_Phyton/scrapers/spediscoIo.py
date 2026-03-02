import sys
from playwright.sync_api import sync_playwright


def converti_ore_in_giorni(ore):
    giorni = int(ore / 24)

    return f"{giorni} giorni lavorativi"





def impostazione(page,input,selettore,nazione,citta,cap):
    try:
        
        # Clicca sul box della nazione
        input.click()
        page.wait_for_timeout(2000)
        
        input.press_sequentially(nazione, delay=100)
        page.keyboard.press("Enter")
        
        page.wait_for_timeout(2000)
        selettore.press_sequentially(citta, delay=100)
        
        # Aspettiamo che il sito elabori e mostri il menu a tendina
        page.wait_for_timeout(3000)
        opzione_corretta=page.locator("li.select2-results__option", has_text=cap)
        
        if opzione_corretta.count() > 0:

            opzione_corretta.first.click()
            
        else:
           return "il cap inserito non è disponibile su www.paccoFacile.it"
        
        page.keyboard.press("Enter")

         
    except Exception as e:
        print(f"Errore Smart Input per {citta}: {e}", file=sys.stderr)



def cerca_SpediscoIo(page, dati):
    
   
    print("Scraping spediscoIo...", file=sys.stderr)
    offerte = []

    try:
        # --- 1. AVVIO ---
         page.goto("https://www.iospedisco.it/")

    except Exception as e:

        print(f"Errore spediscoIo: {e}", file=sys.stderr)
        
    try :
        try:
         # chiudiamo la iframe dell'assistenza 
            chat_frame = page.frame_locator('iframe[data-test-id="chat-widget-iframe"]')
            chat_frame.locator('[data-test-id="welcome-message-close-button"]').click(timeout=3000)
        except:
            pass
        
        # chiudiamo i cookie
        try:
            page.get_by_role("button", name="Accetta tutto").click()(timeout=3000)
        except:
            pass
        
        #  compilazione dati mittente
        
        nazMit= dati['sender']['country'].split(" -")[0]
        citMit= dati['sender']['city']
        capMit= dati['sender']['ZIP']
        nazDest=dati['receiver']['country'].split(" -")[0]
        citDest=dati['receiver']['city']
        capDest=dati['receiver']['ZIP']
        inputMit=  page.locator("#select2-cf-from-naz-container")
        inputDest= page.locator("#select2-cf-to-naz-container") 
        selettoreMit=page.locator("#select2-cf-from-cap-container")
        selettoreDest=page.locator("#select2-cf-to-cap-container")
    
        impostazione(page,inputMit,selettoreMit,nazMit,citMit,capMit)
        page.wait_for_timeout(1000)
        impostazione(page,inputDest,selettoreDest,nazDest,citDest,capDest)
        page.wait_for_timeout(1000)
        
        # compilazione dati pacco
        page.get_by_role("spinbutton", name="Altezza").fill(
            str(dati['package']['dimensions']['h']))
        page.get_by_role("spinbutton", name="Larghezza").fill(
            str(dati['package']['dimensions']['w']))
        page.get_by_role("spinbutton", name="Profondità").fill(
            str(dati['package']['dimensions']['l']))
        page.get_by_role("spinbutton", name="Peso").fill(
            str(dati['package']['weight']))
        
        #cerca 
       
        page.get_by_role("button", name="Compara").click()
            
        page.wait_for_selector("tr.listaComparazione.z-row", state="visible", timeout=15000)
            
        
        page.wait_for_timeout(1000)
        
        lista_corrieri = page.locator("tr.listaComparazione.z-row span[style*='font-size: 15px']").all_inner_texts()
        
        # 2. Prendiamo TUTTI i prezzi in un colpo solo
        lista_prezzi = page.locator("tr.listaComparazione.z-row .bg-primary span[style*='font-size: 32px']").all_inner_texts()
        
        # 3. Prendiamo TUTTI i tempi in un colpo solo
        lista_tempi = page.locator("tr.listaComparazione.z-row .text-secondary span[style*='font-size: 32px']").all_inner_texts()
        


        # --- UNIONE DEI DATI IN PYTHON ---
        
        for corriere, prezzo, tempo in zip(lista_corrieri, lista_prezzi, lista_tempi):
            # Pulizia stringhe
            p = prezzo.strip()
            c = corriere.strip()
            t = tempo.strip()
            
            # Controllo validità minimo
         
            p_pulito = p.replace("€", "").strip() 
            
    
            t_pulito = converti_ore_in_giorni( int(t.replace("H", "").strip()) )

            offerte.append({
                "sito": page.url,
                "corriere": c,
                "prezzo": p_pulito,
                "tempo": t_pulito
            })
            print(f" -> Preso: {c} a {p}", file=sys.stderr)

    except Exception as e:
        print(f"Errore Playwright: {e}", file=sys.stderr)

    return offerte
        
       
            
            
