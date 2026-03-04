----- GUIDA INSTALLAZIONE PROGETTO SHIPFINDER -----

PREREQUISITI:
	1) Avere installato Python

INSTALLAZIONE:
	1) Andare nel percorso file ProgettoADL/modulo_C#/Module_Python ed eseguire
	installa_dipendenze.bat
	
	2)Eseguire il Makefile situato nel percorso ProgettoADL/modulo_C#/Modulo_C++

	2-EXTRA) Su Windows il Makefile è stato eseguito tramite l'ambiente di 	sviluppo:
 
	MSYS2 MINGW64

	Aprire il terminale MSYS2 MinGW64 e installare compilatore e tool di build 	con:

	$ pacman -S mingw-w64-x86_64-gcc mingw-w64-x86_64-make

	Compilazione del progetto

	----Spostarsi nella cartella del modulo C++ ed eseguire----

	$ mingw32-make clean
	$ mingw32-make

	----In alternativa, se il comando make è configurato correttamente----

	$ make clean
	$ make

	----(OPZIONALE)Esecuzione del test-----

	Per eseguire l’esempio minimale lanciabile da terminale:

	$ mingw32-make test

	oppure:

	$ make test
        
ESECUZIONE:
	Aprire con l'IDE Visual Studio la cartella ProgettoADL, spostarsi tramite
	Esplora Soluzioni e cliccare su ProgettoGUI.slnx ed eseguire il programma 	(debug). Se tutto corretto, si dovrebbe avviare il form principale (GUI)