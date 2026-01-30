import sys
from playwright.sync_api import sync_playwright

def acquista_migliore_da_url(url_target):
    """
    Funzione dedicata all'acquisto.
    Apre il browser in modo visibile, va all'URL, trova il prezzo minore e clicca.
    """
    print(f"--- AVVIO MODALITÀ ACQUISTO ---", file=sys.stderr)
    
    with sync_playwright() as p:
        # IMPORTANTE: headless=False perché l'utente deve vedere e interagire
        browser = p.chromium.launch(headless=False, channel="chrome", args=["--start-maximized"])
        context = browser.new_context(no_viewport=True)
        page = context.new_page()

        try:
            # 1. Navigazione
            print(f"Apro: {url_target}", file=sys.stderr)
            page.goto(url_target)

            # 2. Cookie
            try:
                page.get_by_role("button", name="Accetta e chiudi").click(timeout=3000)
            except:
                pass

            # 3. Analisi Offerte per trovare la più economica
            print("Analizzo le offerte...", file=sys.stderr)
            page.wait_for_selector("article", timeout=15000)
            
            cards = page.locator("article").all()
            offerte = []

            for card in cards:
                try:
                    # Prezzo
                    prezzo_raw = card.locator("h2, h3, [class*='price']").filter(has_text="€").first.inner_text()
                    prezzo = float(prezzo_raw.replace("€", "").replace(",", ".").strip())
                    
                    # Nome (solo per log)
                    img = card.locator("img[alt]:not([alt=''])").first
                    nome = img.get_attribute("alt") if img.count() > 0 else "Sconosciuto"

                    # Bottone
                    btn = card.locator("button").filter(has_text="Prenota").first

                    offerte.append({"nome": nome, "prezzo": prezzo, "bottone": btn})
                except:
                    continue
            
            if offerte:
                # Trova il minimo
                vincitore = min(offerte, key=lambda x: x['prezzo'])
                
                print(f"SCELTO: {vincitore['nome']} a {vincitore['prezzo']}€", file=sys.stderr)
                
                # CLICCA
                vincitore['bottone'].click()
                
                # Attende cambio pagina
                page.wait_for_load_state("networkidle")
                print("CHECKOUT PRONTO. Il browser resterà aperto per 1 ora.", file=sys.stderr)
            else:
                print("ERRORE: Nessuna offerta trovata.", file=sys.stderr)

            # 4. Blocca lo script per lasciare il browser aperto all'utente
            page.wait_for_timeout(3600000) 

        except Exception as e:
            print(f"Errore critico acquisto: {e}", file=sys.stderr)
            # Resta aperto per debug
            page.wait_for_timeout(30000)