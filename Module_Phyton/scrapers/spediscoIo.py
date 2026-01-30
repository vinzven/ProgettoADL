import sys
from playwright.sync_api import sync_playwright



def imposta_nazione(page,selettore, nazione):
    try:
        
        nazione_pulita = nazione.split(" -")[0]

            # Clicca sul box della nazione
        page.locator(selettore).click()
        page.wait_for_timeout(2000)

            # Proviamo a scrivere direttamente:
        page.locator(selettore).press_sequentially(nazione_pulita, delay=100)

            # Aspettiamo che filtri la lista
        page.wait_for_timeout(1000)

            # Freccia Giù + Invio (Standard Packlink)
        page.keyboard.press("ArrowDown")
        page.wait_for_timeout(200)
        page.keyboard.press("Enter")

            # Usciamo dal campo
        page.keyboard.press("Tab")
    except Exception as e:
        print(f"Errore Nazione: {e}", file=sys.stderr)
        
        
        
        
def compila_smart(page,selettore, cap, citta):
    try:
           
        
        page.locator(selettore).click()
       
        page.wait_for_timeout(1000)
        page.locator(selettore).press_sequentially(citta, delay=100)

            # 3. ATTESA MENU
            # Aspettiamo che il sito elabori e mostri il menu a tendina
        page.wait_for_timeout(3000)
        
        opzione_corretta=page.locator("li.select2-results__option", has_text=cap)
        
        if opzione_corretta.count() > 0:
            # Se ne trova più di uno, clicca il primo che corrisponde
            opzione_corretta.first.click()
            print(f"Trovato e cliccato: {cap}", file=sys.stderr)
        else:
            # Piano B: Se il filtraggio esatto fallisce, prova l'invio standard
            print("Corrispondenza esatta non trovata, provo Invio standard", file=sys.stderr)
            page.keyboard.press("Enter")
         

            # Invio -> Conferma la scelta
        page.keyboard.press("Enter")

            # Tab -> Esce dal campo (Doppia sicurezza)
        page.keyboard.press("Tab")

        print("Campo confermato.", file=sys.stderr)

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
        
      
        imposta_nazione(page,"#select2-cf-from-naz-container", dati['sender']['country'])
        page.keyboard.press("Escape")
        page.wait_for_timeout(1000)
        compila_smart(page,
            "#select2-cf-from-cap-container",
            dati['sender']['ZIP'],
            dati['sender']['city']
        )
        
        #  compilazione dati destinatario
        page.keyboard.press("Escape")
        imposta_nazione(page,"#select2-cf-to-naz-container",
                        dati['receiver']['country'])
        page.keyboard.press("Escape")
        compila_smart(page,
            "#select2-cf-to-cap-container",
            dati['receiver']['ZIP'],
            dati['receiver']['city']
        )
        
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
            
        
        try:  
            
            page.wait_for_url("**iospedisco.it**",timeout=3000)
            page.wait_for_selector("tr.listaComparazione.z-row", timeout=15000)
            cards = page.locator("tr.listaComparazione.z-row").all()
            for card in cards :
                try:
                    nome_corriere = card.locator(
                'span.z-label[style*="font-size: 15px"]'
                ).first.inner_text().strip()
                    
                    prezzo = card.locator(
            'div.bg-primary span.z-label[style*="font-size: 32px"]').first.inner_text().strip()
                    
                    tempo = card.locator(
                 'span.z-label[style*="font-size: 32px"]'
                 ).first.inner_text().strip()

                    offerte.append({
                "sito": "SpediscoIo",
                 "corriere": nome_corriere,
                 "prezzo": prezzo,
                  "tempo": tempo,
                  
                     })
                except Exception as e:
                    
                    continue
        except Exception as e :
             print(f"Nessuna offerta trovata su Packlink: {e}", file=sys.stderr)
                 
    except Exception as e :
    
        print(f"Errore spediscoIo: {e}", file=sys.stderr)
               
             
    return offerte
