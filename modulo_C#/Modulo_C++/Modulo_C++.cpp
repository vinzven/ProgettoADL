#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include "json.hpp"

using json = nlohmann::json;

// --- FUNZIONI DI AIUTO PER PULIRE I DATI ---

// 1. Trasforma "4,00" in 4.00 (numero reale)
double estrai_prezzo(std::string prezzo_str) {
    // Sostituisce la virgola col punto se presente (per compatibilità locale)
    std::replace(prezzo_str.begin(), prezzo_str.end(), ',', '.');

    try {
        return std::stod(prezzo_str);
    }
    catch (...) {
        return 999999.0; // In caso di errore, sposta l'elemento in fondo alla lista
    }
}

// 2. Estrae il numero da " 2 giorni lavorativi" -> restituisce 2
int estrai_tempo(const std::string& tempo_str) {
    std::string solo_numeri = "";
    for (char c : tempo_str) {
        if (isdigit(c)) {
            solo_numeri += c;
        }
        else if (!solo_numeri.empty()) {
            break; // Si ferma appena finisce il primo numero (es. legge "2" e si ferma allo spazio)
        }
    }
    try {
        return solo_numeri.empty() ? 999 : std::stoi(solo_numeri); // Converte in numero intero
    }
    catch (...) {
        return 999;
    }
}

// --- PROGRAMMA PRINCIPALE ---

int main() {
    std::string stringa_json_da_python;

    // C++ si mette in ascolto di Python
    if (std::getline(std::cin, stringa_json_da_python)) {
        try {
            // 1. Leggiamo l'array originale di offerte
            json lista_originale = json::parse(stringa_json_da_python);

            // Trasformiamo il JSON in vettori (liste) manipolabili dal C++
            std::vector<json> offerte_prezzo = lista_originale.get<std::vector<json>>();
            std::vector<json> offerte_tempo = offerte_prezzo; // Creiamo una copia per il secondo ordinamento

            // 2. ORDINAMENTO PER PREZZO (Crescente: dal più basso al più alto)
            std::sort(offerte_prezzo.begin(), offerte_prezzo.end(), [](const json& a, const json& b) {

                return estrai_prezzo(a["prezzo_iva"]) < estrai_prezzo(b["prezzo_iva"]);

                });

            // 3. ORDINAMENTO PER TEMPO (Crescente: dal più veloce al più lento)
            std::sort(offerte_tempo.begin(), offerte_tempo.end(), [](const json& a, const json& b) {
                
                return estrai_tempo(a["tempo"]) < estrai_tempo(b["tempo"]);
                });

            // 4. COSTRUZIONE DEL JSON FINALE
            json risultato_finale;
            risultato_finale["ordinate_per_prezzo"] = offerte_prezzo;
            risultato_finale["ordinate_per_tempo"] = offerte_tempo;
            risultato_finale["totale_offerte"] = lista_originale.size();

            // 5. STAMPA IL RISULTATO PER MANDARLO A C# (tramite Python)
            std::cout << risultato_finale.dump(4) << std::endl;

        }
        catch (std::exception& e) {
            // In caso di errore (es. JSON malformato)
            json errore = { {"stato", "errore"}, {"dettaglio", e.what()} };
            std::cout << errore.dump(4) << std::endl;
        }
    }

    return 0;
}
