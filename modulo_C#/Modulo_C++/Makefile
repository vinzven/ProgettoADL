# --- CONFIGURAZIONE ---

# Compilatore da utilizzare
CXX = g++

# Flag di compilazione:

CXXFLAGS = -g -Wall -Iinclude

# Nome dell'eseguibile finale
TARGET = ordinatore_offerte

# file sorgente principale
SRC = Modulo_C++.cpp

# Regola di default: compila il progetto
all: $(TARGET)

$(TARGET): $(SRC)
	$(CXX) $(CXXFLAGS) $(SRC) -o $(TARGET)

# Regola per pulire la cartella dai file compilati (consigliato per la consegna)
clean:
	rm -f $(TARGET)

# Esempio lanciabile da terminale 
test: $(TARGET)
	@echo "--- TEST MODULO C++ ---"
	@echo '[{"nome_sito":"Sito1","corriere":"SDA","prezzo_iva":"12,00","tempo":"3 gg"},{"nome_sito":"Sito2","corriere":"BRT","prezzo_iva":"15,50","tempo":"1 gg"},{"nome_sito":"Sito3","corriere":"Poste","prezzo_iva":"9,00","tempo":"5 gg"}]' | ./$(TARGET)