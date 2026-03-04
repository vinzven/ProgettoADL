# --- CONFIGURAZIONE ---

# Compilatore da utilizzare
CXX = g++

# Flag di compilazione:
# Aggiunti flag -static per incorporare le librerie ed evitare errori DLL
CXXFLAGS = -g -Wall -Iinclude -static -static-libgcc -static-libstdc++

# Nome dell'eseguibile finale 
TARGET = ordinatore_offerte

# File sorgente principale
SRC = Modulo_C++.cpp

# Regola di default: compila il progetto
all: $(TARGET)

$(TARGET): $(SRC)
	$(CXX) $(CXXFLAGS) $(SRC) -o $(TARGET)

# Regola per pulire la cartella dai file compilati 
clean:
	rm -f $(TARGET)

# Esempio lanciabile da terminale 
test: $(TARGET)
	@echo "--- TEST MODULO C++ ---"
	@echo '[{"nome_sito":"Sito1","corriere":"SDA","prezzo_iva":"12,00","tempo":"3 gg"},{"nome_sito":"Sito2","corriere":"BRT","prezzo_iva":"15,50","tempo":"1 gg"},{"nome_sito":"Sito3","corriere":"Poste","prezzo_iva":"9,00","tempo":"5 gg"}]' | ./$(TARGET)