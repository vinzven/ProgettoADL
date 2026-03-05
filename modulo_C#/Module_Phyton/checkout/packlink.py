
import sys


def acquisto_packlink(page, url_target,prezzo_target,corriere_target):
    
    try:
        page.goto(url_target)

        try:
            page.wait_for_timeout(1000)
            page.get_by_role("button", name="Accetta e chiudi").click(timeout=3000)
        except:
            pass 
        
        page.wait_for_selector("article[data-id^='service-']", state="visible", timeout=15000)

    
        immagini=  page.locator("article[data-id^='service-'] img[class^='giger-1awiii4']").all()
        lista_corrieri = [img.get_attribute("src").split("/")[-1].split(".")[0].replace("-", " ").title() for img in immagini]

                    

        lista_prezzi = page.locator("article[data-id^='service-'] h2[class*='giger-14rg4q7']").filter(has_text="€").all_inner_texts()

        # Recupera tutti i bottoni di acquisto
        bottoni = page.locator("article[data-id^='service-'] button[data-id='book-service-button']").all()

        # Ciclo di confronto usando zip per mantenere l'indice corretto
        successo = False
        prezzo_in = prezzo_target.replace(".", ",")
        
        for corriere, prezzo, bottone in zip(lista_corrieri, lista_prezzi, bottoni):
            p = prezzo.replace("€", "").replace("\xa0", "").strip()
        
            # Confronto (target corriere e target prezzo)
            if corriere_target.lower() in corriere.lower()  and prezzo_in == p:
                    
                    bottone.click()
                    successo = True
                    break # Esci dal ciclo una volta cliccato

        if not successo:
            print(f"Nessun match per {corriere_target} a {prezzo_target}€")
    
    except Exception as e:
        print(f"Errore acquisto packlink: {e}", file=sys.stderr)