# 1. Ablauf

___
___
___
# 2. Klasse
## 2.1. Player
Ein Player-Objekt hat die folgenden Eigenschaften:
* ``name`` : Der Name des Spielers

* ``countHits``: Die die getroffenen Felder der Schiffe aufzählt und wennn es ``30`` ist, gewinnt der Spieler.

* ``totalShots``: Die die gesamte Schüsse vom Spieler, falsch oder richtig aufzählt.
___
### ``Play()``
Hier wird die Methode ``AskUserToShoot()`` aufgerufen.

Es wird in dieser Methode also überprüft ob der Spieler den Gewinnzustand schon erreicht hat oder nicht.
___

### ``AskUserToShoot()``
Diese Method ist für das Terminal (die Konsole) und die UI zuständing.

Sie erfragt die X und Y Koordination des Schusses und liest die Antwort des Spielers.

Demnach wird die Methode ``CheckShots()`` aus der Klasse ``Board`` aufgerufen zu prüfen ob ein Schiff auf dem Feld getroffen ist oder nicht.
___
___

## 2.2. Board
* In dieser Klasse werden die 10 Schiffe instanziiert.

* ``int[,] field``  
Dort werden die Schiffe auf ein Feld aufgestellt.

* ``int[,] hiddenField``  
Das ist das Feld, das der Spieler sehen kann, natürlich ohne Schiffe.  

   Initialisierung in einem __Statischen Konstruktor__, damit die Schüsse persistiert zu werden.
___

### ``CheckShots()``
#### Argumente
* ``int[] inputPoint``  
Die Koordination des Schusses.

* ``bool hitShip``  
Ob ein Schiff getroffen wurde oder nicht.

#### Umsetzung
Die Methode ordnet einen Wert der Koordination des Schusses auf dem ``int[,] hiddenField`` zu:

``const int OFF_TARGET = 6``  
``const int ON_TARGET = 7``

Danach ruft die Methode eine andere Methode ``MapToConsole()``, die für die Farben der Felder auf dem Terminal zuständing ist.
___

### ``ShowShipsOnField()``
Die Methode setzt die Farben der Felder von ``int[,] field`` erst zu blau.  
Und danach Zur Platzierung jedes Shiffes ruft die Methode ``PlaceShip()`` aus der Klasse ``Ship`` auf.  

Am Ende ruft ``ShowShipsOnField()`` auch die Methode ``MapToConsole()`` auf, um die Schiffe auf dem Terminal darzustellen.
___

### ``CountBlocsToHit()``
Eine einfache Methode die für den Gewinn-Zustand verantwortlich ist, aber irgendwie musste ich am Ende die Zahl ``30`` fest codieren.
___

### ``MapToConsole()``
Diese Methode ist für die Farben und Darstellung der Felder auf dem Terminal bzw. die UI zuständing.
___
___

## 2.3. Ship
Da sind die niedrigsten (low level) Codes und die längste Klasse mit etwa 450 Zeilen in meiner Applikation. 

Die Klasse braucht vielleicht eine Bearbeitung und kann vielleicht auch in mehrere Klassen aufgeteilt werden.

___
___
___
# 3. Die Fragen
## 3.1. Womit hatten Sie Schwierigkeiten und wie haben Sie diese gelöst?
Ich habe mit den Bedingungen Probleme gehabt. Mit sämtlichen boolischen Variablen habe ich das gelöst!
___

## 3.2. Was ist Ihnen besonders gut gelungen?
Ich kann mich nicht erinnern, es ist lange her.
___

## 3.3. Womit sind Sie nicht so zufrieden?
Mit dem Entwurfsmuster meines Programms. Deswegen habe ich teilweise versucht aus dem Code in den sehr langen Methoden kleineren Methoden zu bauen.
___

## 3.4. Was haben Sie als Zusatz in Ihre Lösung hinzugefügt?
Nichts Besonderes.

Aber wenn der Spieler beim Spiel eine falsche Taste oder eine falsche Zahl für die Koordination der Schüsse eingibt, wird er gefragt ob er das Spiel verlassen will oder nicht und das Programm schmeißt ihn dank der ``try/catch``-Anweisung nicht raus.