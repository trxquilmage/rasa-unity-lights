um das Projekt zum laufen zu bekommen, wird benötigt:

Rasa 2.2.0
Python 3.8.6
Unity 2020.1.17f1

Starte RasaShell, RunActions & die Unity Szene. Dann gib in Rasa Shell "kannst du licht 1 rot machen?" ein
und ein Licht sollte sich rot färben. Dieses Projekt hat sehr viele Probleme, also wird er bei vielen Dingen
Errors werfen, aber kann (theoretisch):
- Färbe (Licht: alle Lichter, licht 1, licht 2, licht 3) (Farbe: rot, orange, gelb, gruen, blau, pink, lila, schwarz, weiss, grau)
- Mach ein (Licht) heller
- Mach ein (Licht) dunkler
- Mach ein (Licht) aus

Beachte, dass du immer spezifizieren musst, welches licht, also "faerbe das licht rot" lässt rasa nicht erkennen,
welches Licht du rot färben willst. Theoretisch erkennt rasa auch die wörter "RGB Lichter" und "Bewegliche Lichter"
aber Unity verarbeitet diese zurzeit nicht.