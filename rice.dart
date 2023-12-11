import 'dart:io';

void choisirMode() {
  print('Modes disponibles :');
  print('1. Riz Blanc');
  print('2. Riz Complet');
  print('3. Cuisson Vapeur');
  print('4. Autre aliment');

  var choix = '2';

  var tempsCuisson = 0;

  switch (choix) {
    case '1':
      print('Mode Riz Blanc sélectionné');
      tempsCuisson = 2;
      break;
    case '2':
      print('Mode Riz Complet sélectionné');
      tempsCuisson = 2;
      break;
    case '3':
      print('Mode Cuisson Vapeur sélectionné');
      tempsCuisson = 2;
      break;
    case '4':
      var tempsPersonnalise = 120;
      if (tempsPersonnalise != null && tempsPersonnalise > 0) {
        print('Mode Autre Aliment sélectionné - Cuisson pendant $tempsPersonnalise secondes.');
        tempsCuisson = tempsPersonnalise;
      } else {
        print('Temps invalide.');
      }
      break;
    default:
      print('Choix non valide');
      break;
  }

  if (tempsCuisson > 0) {
    print('Types d\'alertes disponibles :');
    print('1. Son');
    print('2. Lumières clignotantes');

    var choixAlerte = '1';

    print('La cuisson se déroulera pendant $tempsCuisson secondes.');

    switch (choixAlerte) {
      case '1':
        Future.delayed(Duration(seconds: tempsCuisson), () {
          print('*BIP*BIP*BIP* La cuisson est terminée !');
        });
        
        break;
      case '2':
        Future.delayed(Duration(seconds: tempsCuisson), () {
          print('*lumières clignotantes* La cuisson est terminée !');
        });
 
        break;
      default:
        print('Choix non valide. Aucune alerte ne sera déclenchée.');
        break;
    }

    Future.delayed(Duration(seconds: tempsCuisson), () {
      var choixApresCuisson = '2';

      switch (choixApresCuisson) {
        case '1':
          print('Le rice cooker a été éteint.');
         
          break;
        case '2':
          print('Le riz est maintenu au chaud.');
      
          break;
        default:
          print('Choix non valide. Le rice cooker sera éteint par défaut.');
     
          break;
      }
    });
  }
}

void main() {
  choisirMode();
}
