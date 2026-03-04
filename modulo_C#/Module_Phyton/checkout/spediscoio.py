import sys

# vado alla pagina dell'offerta
def acquisto_spediscoio(page, url_target,prezzo_target,corriere_target):


    try:
        page.goto(url_target)

        # salvo come precedentemente fatto i dati
        page.wait_for_selector("tr.listaComparazione.z-row", state="visible", timeout=15000)
                
            
        lista_corrieri = page.locator("tr.listaComparazione.z-row span[style*='font-size: 15px']").all_inner_texts()
            
        lista_prezzi = page.locator("tr.listaComparazione.z-row .bg-primary span[style*='font-size: 32px']").all_inner_texts()
        # salvo i bottoni di tutte le offerte
        bottoni = page.locator("tr.listaComparazione.z-row").get_by_text("SELEZIONA >").all()
        
        # variabile flag 
        sucesso = False
        
        # convertiamo il prezzo 
        prezzo_in = prezzo_target.replace(".", ",")
        
        for corriere, prezzo, bottone in zip(lista_corrieri, lista_prezzi, bottoni):
            # pulizia
            c = corriere.strip()
                
            p=prezzo.replace("€", "").strip()
        
            # Confronto (target corriere e target prezzo)
            if corriere_target.lower() in c.lower() and  prezzo_in == p:
                    
                    # clicchiamo l'offerta corretta
                    bottone.click()
                    page.get_by_role("link", name="AVANTI").click()
                    sucesso = True
                    break # Esci dal ciclo una volta cliccato
                
        if not sucesso:
            print(f"Nessun match per {corriere_target} a {prezzo_target}€")
      
    except Exception as e:
        print(f"Errore acquisto spediscoio: {e}", file=sys.stderr)  
    
    
  