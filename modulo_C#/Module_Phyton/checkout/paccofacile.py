
from deep_translator import GoogleTranslator
import sys



def traduci_dato(testo, destinazione='en'):
    # Traduce da qualsiasi lingua (auto) all'inglese (en)
    traduzione = GoogleTranslator(source='auto', target=destinazione).translate(testo)
    return traduzione



def impostazione(page,input,selettore,nazione,citta,cap):
    try:
        
        if  nazione != "Italia" :
            
            citta=traduci_dato(citta)
            
        page.select_option(input, label=nazione)
        selettore.click()
        page.wait_for_timeout(2000)
        
        selettore.press_sequentially(citta, delay=100)
        page.wait_for_timeout(2000)
    
        suggerimento = page.locator(".tt-suggestion", has_text=f"({cap})")
        
        if suggerimento.count() > 0 :
    # 3. Aspettiamo che sia visibile e ci clicchiamo
            suggerimento.first.click()
        else:
            
            return "il cap inserito non è disponibile su www.paccoFacile.it"
        
    except Exception as e:
        print(f"Errore Nazione: {e}", file=sys.stderr)



def acquisto_paccofacile(page, url_target,prezzo_target,corriere_target,dati):

# reinserisco i dati come fatto precedentemente
    try:
        # --- 1. AVVIO ---
        page.goto(url_target)
    
        try:
            page.get_by_role("button", name="Accetta tutti").click(timeout=3000)
    
        except:
            pass

        nazMit= dati['sender']['country'].split(" -")[0]
        citMit= dati['sender']['city']
        capMit= dati['sender']['ZIP']
        nazDest=dati['receiver']['country'].split(" -")[0]
        citDest=dati['receiver']['city']
        capDest=dati['receiver']['ZIP']
        
        selettoreMit= page.get_by_role("searchbox", name="Luogo e Cap")
        selettoreDest=page.get_by_role("searchbox", name="Cap destinazione")
        inputMit="#input-shipment-country-partenza"
        inputDest="#input-shipment-country-destinazione"
        
        peso=page.get_by_role("textbox", name="peso in kg")
        lunghezza=page.get_by_role("textbox", name="Lato 1 in cm")
        larghezza=page.get_by_role("textbox", name="Lato 2 in cm")
        altezza = page.get_by_role("textbox", name="Lato 3 in cm")
        
        impostazione(page,inputMit,selettoreMit,nazMit,citMit,capMit)
        page.wait_for_timeout(2000)
        impostazione(page,inputDest,selettoreDest,nazDest,citDest,capDest)
        page.wait_for_timeout(2000)
        
        
        peso.fill(
            str(dati['package']['weight']))
        lunghezza.fill(
            str(dati['package']['dimensions']['l']))
        larghezza.fill(
            str(dati['package']['dimensions']['w']))
        altezza.fill(
            str(dati['package']['dimensions']['h']))
        
        page.wait_for_timeout(1000)
        
        page.get_by_role("button", name="CALCOLA TARIFFA").click()
        page.wait_for_timeout(1000)
        bottone = page.locator("#btn-shipment-calcola-prezzo")

# Aspetta che diventi visibile nel DOM e a schermo
        bottone.wait_for(state="visible")

# Ora clicca
        bottone.click()
        page.wait_for_timeout(1000)
        page.get_by_role("link", name="Scegli il servizio").click()
       
         
    
        
        page.wait_for_selector("div.form_spedizione_container_corriere_servizio_order", state="visible", timeout=15000)
            
        page.wait_for_timeout(1000)
        
        # salvo i dati e tutti i bottini
        immagini = page.locator("div.form_spedizione_container_corriere_servizio_order img[alt^='logo']").all()
            
        lista_corrieri = [img.get_attribute("alt").replace("logo ", "").strip() for img in immagini]
        
        lista_prezzi   = page.locator("div.form_spedizione_container_corriere_servizio_order span[id*='form_spedizione_prezzo_totale']").all_inner_texts()
            
        bottoni = page.locator("div.form_spedizione_container_corriere_servizio_order button.form_spedizione_accessori_btn_scelta_corriere_servizio").all()

        successo = False

    # aggregazione
        for corriere, prezzo, bottone in zip(lista_corrieri, lista_prezzi, bottoni):
            # pulizia
            p = prezzo.strip()
            c= corriere.strip()

            if corriere_target.lower() in c.lower() and prezzo_target == p:
                # clicco l'offerta giusta
                bottone.click()
                successo = True
                break # Esci dal ciclo appena trovi quello giusto

        # Gestione se non viene trovato nulla
        if not successo:
            print(f"Nessun match su PaccoFacile per {corriere_target} a {prezzo_target}€", file=sys.stderr)
            
            
    except Exception as e:
        print(f"Errore acquisto paccofacile: {e}", file=sys.stderr)