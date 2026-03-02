
import sys
from playwright.sync_api import sync_playwright
import re

def calcola_giorni_lavorativi(valore, unita):

    try:
        
    
        if "Ore" in unita:
            giorni_calcolati = valore / 24
        
        else:
            # Se c'è scritto "GIORNI" o altro, assumiamo siano già giorni
            giorni_calcolati = valore

        return f"{int(giorni_calcolati)} giorni lavorativi"

    except (ValueError, TypeError):
        # Se qualcosa va storto (es. stringa vuota), restituisci un valore di default
        return "Tempo N/D"




def impostazione(page,input,selettore,nazione, citta, cap):
    try:
          
        page.locator(input).click()
          
        page.wait_for_timeout(1000)

        page.locator(input).press_sequentially(nazione, delay=100)

            # Aspettiamo che filtri la lista
        page.wait_for_timeout(1000)

       
        page.keyboard.press("Enter")

            # "CAP - Città"

        testo_esatto = f"{cap} - {citta}"


        page.locator(selettore).click()
        

        page.locator(selettore).press_sequentially(testo_esatto, delay=100)

           
        page.wait_for_timeout(2000)

            # Freccia Giù -> Evidenzia il risultato (che ora sarà perfetto perché il testo è esatto)
        page.keyboard.press("ArrowDown")
        
            # Invio -> Conferma la scelta
        page.keyboard.press("Enter")
       

    except Exception as e:
        print(f"Errore Nazione: {e}", file=sys.stderr)





def cerca_packlink(page, dati):
    print("Scraping Packlink...", file=sys.stderr)
    offerte = []


    try:
        # --- 1. AVVIO ---
        page.goto("https://www.packlink.it/")

        # Cookie
        try:
            page.wait_for_timeout(1000)
            page.get_by_role(
                "button", name="Accetta e chiudi").click(timeout=3000)
        except:
            pass
    
    
        nazMit= dati['sender']['country'].split(" -")[0]
        citMit= dati['sender']['city']
        capMit= dati['sender']['ZIP']
        nazDest=dati['receiver']['country'].split(" -")[0]
        citDest=dati['receiver']['city']
        capDest=dati['receiver']['ZIP']    
        inputMit= "[id=\"from.country\"]"
        inputDest="input[name=\"to.country\"]"
        selettoreMit="[id=\"from.code\"]"
        selettoreDest="input[name=\"to.code\"]"
        # --- 2. COMPILAZIONE ---
        
        # MITTENTE
        page.wait_for_timeout(1000)
        impostazione(page,inputMit,selettoreMit,nazMit,citMit,capMit)
        page.wait_for_timeout(1000)
        impostazione(page,inputDest,selettoreDest,nazDest,citDest,capDest)
        
        # 4. Pacco (Peso e Dimensioni)
        page.get_by_role("textbox", name="Peso").fill(
            str(dati['package']['weight']))
        page.get_by_role("textbox", name="Lunghezza").fill(
            str(dati['package']['dimensions']['l']))
        page.get_by_role("textbox", name="Larghezza").fill(
            str(dati['package']['dimensions']['w']))
        page.get_by_role("textbox", name="Altezza").fill(
            str(dati['package']['dimensions']['h']))

        # 5. Cerca
        page.get_by_role("button", name="Spedisci ora").click()

        # 6. ESTRAZIONE 
        
    
            #page.wait_for_url("**packlink.it**")
        page.wait_for_selector("article[data-id^='service-']",state="visible", timeout=15000)
        
        page.wait_for_timeout(1000)
          
        
                    # CORRIERE:

        immagini=  page.locator("article[data-id^='service-'] img[class^='giger-1awiii4']").all()
        lista_corrieri = [img.get_attribute("src").split("/")[-1].split(".")[0].replace("-", " ").title() for img in immagini]

                    # PREZZO:

        lista_prezzi = page.locator("article[data-id^='service-'] h2[class*='giger-14rg4q7']").filter(has_text="€").all_inner_texts()

       
                    
        lista_valori = page.locator("article[data-id^='service-'] p[class='giger-m1r6m0'] ").all_inner_texts()
        
    
    
        lista_durata = page.locator("article[data-id^='service-'] small[class='giger-10mxsa9'] ").all_inner_texts()
    
        
       
        for corrieri, valori, tempi,prezzi in zip(lista_corrieri,lista_valori, lista_durata, lista_prezzi):
            
            tempi= calcola_giorni_lavorativi(int(valori.strip()),tempi)
            c=corrieri.strip()
            p=prezzi.replace("€", "").strip()
            
            
            
            offerte.append({
                "sito": page.url,
                "corriere" :c,
                "prezzo": p,
                "tempo": tempi
            })
    
    except Exception as e:
        print(f"Errore Packlink: {e}", file=sys.stderr)

    return offerte
