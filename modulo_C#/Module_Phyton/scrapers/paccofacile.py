import sys
from deep_translator import GoogleTranslator
from datetime import datetime


def traduci_dato(testo, destinazione='en'):
    # Traduce da qualsiasi lingua (auto) all'inglese (en)
    traduzione = GoogleTranslator(source='auto', target=destinazione).translate(testo)
    return traduzione


from datetime import datetime, timedelta



def converti_data_in_giorni_lavorativi(giorno_str, mese_str):
    anno_corrente = datetime.now().year
    
    mesi = {
        'gennaio': 1, 'febbraio': 2, 'marzo': 3, 'aprile': 4,
        'maggio': 5, 'giugno': 6, 'luglio': 7, 'agosto': 8,
        'settembre': 9, 'ottobre': 10, 'novembre': 11, 'dicembre': 12
    }
    
    num_mese = mesi.get(mese_str.lower().strip())
    
    # 1. Creiamo le date (senza orario)
    data_scadenza = datetime(anno_corrente, num_mese, int(giorno_str)).date()
    oggi = datetime.now().date()
    
    # Controllo rapido: se la data è oggi o passata
    if data_scadenza <= oggi:
        return "Consegna oggi" 

    # --- LISTA FESTIVI (aggiornata con Pasquetta 2026) ---
    festivi = [
        (1, 1),   # Capodanno
        (6, 1),   # Epifania
        (6, 4),   # Pasquetta 2026 (Variabile)
        (25, 4),  # Liberazione
        (1, 5),   # Festa del Lavoro
        (2, 6),   # Festa della Repubblica
        (15, 8),  # Ferragosto
        (1, 11),  # Ognissanti
        (8, 12),  # Immacolata
        (25, 12), # Natale
        (26, 12)  # Santo Stefano
    ]

    giorni_lavorativi = 0
    giorno_corrente = oggi + timedelta(days=1)
    
    # --- CALCOLO GIORNI LAVORATIVI ---
    while giorno_corrente <= data_scadenza:
        # 5 = Sabato, 6 = Domenica
        is_weekend = giorno_corrente.weekday() >= 5
        is_festivo = (giorno_corrente.day, giorno_corrente.month) in festivi
        
        # Se è un giorno utile, contiamolo
        if not is_weekend and not is_festivo:
            giorni_lavorativi += 1
            
        giorno_corrente += timedelta(days=1)
    
        giorni_lavorativi=int(giorni_lavorativi)
    return f"{(giorni_lavorativi)} giorni lavorativi"



# funzione per impostare i dati

def impostazione(page,input,selettore,nazione,citta,cap):
    try:
        
        if  nazione != "Italia" :
            
            citta=traduci_dato(citta)
            
        # inserimento nazione
        page.select_option(input, label=nazione)
        selettore.click()
        page.wait_for_timeout(2000)
        
        #scrittura
        selettore.press_sequentially(citta, delay=100)
        page.wait_for_timeout(2000)
     # seleziona solo il cap coretto
        suggerimento = page.locator(".tt-suggestion", has_text=f"({cap})")
        
        if suggerimento.count() > 0 :
    # 3. Aspettiamo che sia visibile e ci clicchiamo
            suggerimento.first.click()
        else:
            
            return "il cap inserito non è disponibile su www.paccoFacile.it"
        

    except Exception as e:
        print(f"Errore Nazione: {e}", file=sys.stderr)



def cercaPaccoFacile(page,dati):
    
    offerte = []

    try:
        # --- 1. AVVIO ---
        page.goto("https://www.paccofacile.it/")
    
        try:
            page.get_by_role("button", name="Accetta tutti").click(timeout=3000)
    
        except:
            pass
        
        
        # dati da inserire per compilazione
        nazMit= dati['sender']['country'].split(" -")[0]
        citMit= dati['sender']['city']
        capMit= dati['sender']['ZIP']
        nazDest=dati['receiver']['country'].split(" -")[0]
        citDest=dati['receiver']['city']
        capDest=dati['receiver']['ZIP']
        
        #selettori da utilizzare
        selettoreMit= page.get_by_role("searchbox", name="Luogo e Cap")
        selettoreDest=page.get_by_role("searchbox", name="Cap destinazione")
        inputMit="#input-shipment-country-partenza"
        inputDest="#input-shipment-country-destinazione"
        
        peso=page.get_by_role("textbox", name="peso in kg")
        lunghezza=page.get_by_role("textbox", name="Lato 1 in cm")
        larghezza=page.get_by_role("textbox", name="Lato 2 in cm")
        altezza = page.get_by_role("textbox", name="Lato 3 in cm")
        # inserimento dati mittente e destinatario
        impostazione(page,inputMit,selettoreMit,nazMit,citMit,capMit)
        page.wait_for_timeout(2000)
        impostazione(page,inputDest,selettoreDest,nazDest,citDest,capDest)
        page.wait_for_timeout(2000)
        
        # inserimento dimensioni
        peso.fill(
            str(dati['package']['weight']))
        lunghezza.fill(
            str(dati['package']['dimensions']['l']))
        larghezza.fill(
            str(dati['package']['dimensions']['w']))
        altezza.fill(
            str(dati['package']['dimensions']['h']))
        
        page.wait_for_timeout(1000)
        
        # click bottone 
        page.get_by_role("button", name="CALCOLA TARIFFA").click()
        page.wait_for_timeout(1000)
        bottone = page.locator("#btn-shipment-calcola-prezzo")

# Aspetta che diventi visibile 
        bottone.wait_for(state="visible")

# Ora clicca
        bottone.click()
        page.wait_for_timeout(1000)
        page.get_by_role("link", name="Scegli il servizio").click()
       
       # raccolta dati 
        page.wait_for_selector("div.form_spedizione_container_corriere_servizio_order", state="visible", timeout=15000)
        
        page.wait_for_timeout(1000)
        immagini = page.locator("div.form_spedizione_container_corriere_servizio_order img[alt^='logo']").all()
        # raccolta corrieri
        lista_corrieri = [img.get_attribute("alt").replace("logo ", "").strip() for img in immagini]
       
       # prezzi
        lista_prezzi   = page.locator("div.form_spedizione_container_corriere_servizio_order span[id*='form_spedizione_prezzo_totale']").all_inner_texts()
        
        # dati di input per la funzione per la data corretta
        lista_giorni = page.locator("div.form_spedizione_container_corriere_servizio_order div.col-lg-4.col-6.pt-2.destination_column p[class='m-0'] strong").all_inner_texts()

        lista_mesi  = page.locator("div.form_spedizione_container_corriere_servizio_order p.m-0:nth-of-type(3) small").all_inner_texts()

        
        # aggregazione offerte
        for prezzo,corriere, giorni,mesi, in zip( lista_prezzi, lista_corrieri,lista_giorni ,lista_mesi):
            # Pulizia stringhe
            p = prezzo.strip()
            c= corriere.strip()
            data=converti_data_in_giorni_lavorativi(giorni.strip(),mesi.strip())
        
        
           # json finale 
            offerte.append({
                "nome_sito": "paccofacile",
                "sito": page.url,
                "corriere" : c,
                "prezzo": p,
                "prezzo_iva":p, 
                "tempo": data 
            })
        
    except Exception as e:
        print(f"Errore ricerca in paccofacile: {e}", file=sys.stderr)
        
    return offerte
   
    
            
    
    
  
    
   
         
    
        
            
           
        
 
           
        
        
    