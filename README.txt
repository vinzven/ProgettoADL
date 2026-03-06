----- GUIDA INSTALLAZIONE PROGETTO SHIPFINDER -----

PREREQUISITI:

	1) Avere installato Python e eventualmente installarlo da https://www.python.org/, Durante l'installazione, spuntare "Add Python to PATH"
    2) utilizzare windows
    3) connesione ad internet

INSTALLAZIONE:
	1) Andare nel percorso file ProgettoADL/modulo_C#/Module_Python ed eseguire
	installa_dipendenze.bat
	
	2)Eseguire il Makefile situato nel percorso ProgettoADL/modulo_C#/Modulo_C++

	2- GUIDA EXTRA) Su Windows il Makefile è stato eseguito tramite l'ambiente di 	sviluppo MSYS2 MINGW64 :

    installare MSYS2 MINGW64 da https://www.msys2.org/

	Aprire il terminale MSYS2 MinGW64 e eseguire :

    $ pacman -Syu

	$ pacman -S mingw-w64-x86_64-toolchain

    $ pacman -S make

    -----verificare una volta completato che si trovi nel PATH---

	----Spostarsi nella cartella ProgettoADL/modulo_C#/Modulo_C++ ed eseguire----

	$ make 
	
	----In alternativa, in caso di errore

	$ mingw32-make

	----(OPZIONALE)Esecuzione del test-----

	Per eseguire l’esempio minimale lanciabile da terminale:

	$ make test

	----oppure:--

    $ mingw32-make test

        
ESECUZIONE (consigliata):
	Aprire con l'IDE Visual Studio la cartella ProgettoADL, spostarsi tramite
	Esplora Soluzioni e cliccare su ProgettoGUI.slnx ed eseguire il programma (debug). Se tutto corretto, si dovrebbe avviare il form principale (GUI)


---ALTERNATIVA--------
Installare l'estensione "C# Dev Kit" 
Assicurarsi di avere installato l'SDK di .NET da https://dotnet.microsoft.com/en-us/download
aprire con l'IDE Visual Studio code la cartella ProgettoADL 
aprire il terminale e lanciare da ProgettoADL dotnet run --project "modulo_C#/ProgettoGUI.csproj"
Se tutto corretto, si dovrebbe avviare il form principale (GUI)

