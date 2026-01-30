
import sys
from playwright.sync_api import sync_playwright
import re


def cerca_packlink(page, dati):
    print("Scraping Packlink...", file=sys.stderr)
    offerte = []

    def compila_smart(selettore, cap, citta):
        try:
            # "CAP - Città"

            testo_esatto = f"{cap} - {citta}"

            print(
                f"Inserimento smart in {selettore}: '{testo_esatto}'", file=sys.stderr)

            # 1. Click e Pulizia
            page.locator(selettore).click()
            page.locator(selettore).clear()

            # 2. Scrittura Lenta
            # Scriviamo la stringa ESATTA con il trattino
            page.locator(selettore).press_sequentially(testo_esatto, delay=100)

            # 3. ATTESA MENU
            # Aspettiamo che il sito elabori e mostri il menu a tendina
            page.wait_for_timeout(2000)

            # 4. SELEZIONE CON TASTIERA
            # Freccia Giù -> Evidenzia il risultato (che ora sarà perfetto perché il testo è esatto)
            page.keyboard.press("ArrowDown")
            page.wait_for_timeout(200)

            # Invio -> Conferma la scelta
            page.keyboard.press("Enter")

            # Tab -> Esce dal campo (Doppia sicurezza)
            page.keyboard.press("Tab")

            print("Campo confermato.", file=sys.stderr)

        except Exception as e:
            print(f"Errore Smart Input per {citta}: {e}", file=sys.stderr)

    def imposta_nazione(selettore, nazione):
        try:
            print(f"Imposto nazione {selettore}: {nazione}", file=sys.stderr)

            # Clicca sul box della nazione
            page.locator(selettore).click()

            # Proviamo a scrivere direttamente:

            page.locator(selettore).press_sequentially(nazione, delay=100)

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

    try:
        # --- 1. AVVIO ---
        page.goto("https://www.packlink.it/")

        # Cookie
        try:
            page.get_by_role(
                "button", name="Accetta e chiudi").click(timeout=3000)
        except:
            pass

        # --- 2. COMPILAZIONE ---

        # MITTENTE
        imposta_nazione("[id=\"from.country\"]", dati['sender']['country'])
        compila_smart(
            "[id=\"from.code\"]",
            dati['sender']['ZIP'],
            dati['sender']['city']
        )

        # DESTINATARIO
        imposta_nazione("input[name=\"to.country\"]",
                        dati['receiver']['country'])
        compila_smart(
            "input[name=\"to.code\"]",
            dati['receiver']['ZIP'],
            dati['receiver']['city']
        )
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
        
        try:
            page.wait_for_url("**packlink.it**", timeout=3000)
            page.wait_for_selector("article", timeout=15000)
            link_pagina = page.url

            # Prendiamo tutti gli elementi 'article' (ogni article è un'offerta)
            cards = page.locator("article").all()

            for card in cards:
                try:
                    # CORRIERE:

                    nome_corriere = card.locator(
                        "img").first.get_attribute("alt")
                    if not nome_corriere:
                        nome_corriere = "Standard"

                    # PREZZO:

                    prezzo_raw = card.locator(
                        "h2, [class*='price']").filter(has_text="€").first.inner_text()

                    prezzo = float(prezzo_raw.replace(
                        "€", "").replace(",", ".").strip())
                    
                    
                    testo_card = card.inner_text()
                    
                    # 2. Usiamo una Regex per cercare un numero seguito da "Ore" e "STIMATO"
                    # Spiegazione Regex:
                    # (\d+)       -> Cerca uno o più numeri (es. 48)
                    # \s* -> Cerca spazi o a capo opzionali
                    # (Ore|Giorni)-> Cerca la parola "Ore" oppure "Giorni"
                    # \s* -> Spazi o a capo
                    # STIMATO     -> La parola STIMATO
                    match_tempo = re.search(r"(\d+)\s*(Ore|Giorni)\s*STIMATO", testo_card, re.IGNORECASE)
                    
                    if match_tempo:
                        # Se lo trova, costruiamo la stringa pulita (es. "48 Ore STIMATO")
                        tempo = f"{match_tempo.group(1)} {match_tempo.group(2)} STIMATO"
                    else:
                        tempo = "Non dichiarato"

                    offerte.append({
                        "sito": "Packlink",
                        "corriere": nome_corriere,
                        "prezzo": prezzo,
                        "tempo" : tempo,
                        "link": link_pagina

                    })
                except Exception as e:
                    # Se una card è strana, la saltiamo
                    continue
                         

        except Exception as e:
            print(f"Nessuna offerta trovata su Packlink: {e}", file=sys.stderr)

    except Exception as e:
        print(f"Errore Packlink: {e}", file=sys.stderr)

    return offerte
