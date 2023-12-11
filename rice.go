package main

import (
  "fmt"
  "time"
)

func choisirMode() {
  fmt.Println("Modes disponibles :")
  fmt.Println("1. Riz Blanc")
  fmt.Println("2. Riz Complet")
  fmt.Println("3. Cuisson Vapeur")
  fmt.Println("4. Autre aliment")

  var choix string
  fmt.Print("Choisissez un mode de cuisson (1/2/3/4) : ")
  fmt.Scanln(&choix)

  var tempsCuisson int

  switch choix {
  case "1":
    fmt.Println("Mode Riz Blanc sélectionné")
    tempsCuisson = 2
  case "2":
    fmt.Println("Mode Riz Complet sélectionné")
    tempsCuisson = 2
  case "3":
    fmt.Println("Mode Cuisson Vapeur sélectionné")
    tempsCuisson = 2
  case "4":
    var tempsPersonnalise int
    fmt.Print("Entrez le temps de cuisson en secondes pour l'autre aliment : ")
    fmt.Scanln(&tempsPersonnalise)
    if tempsPersonnalise > 0 {
      fmt.Printf("Mode Autre Aliment sélectionné - Cuisson pendant %d secondes.\n", tempsPersonnalise)
      tempsCuisson = tempsPersonnalise
    } else {
      fmt.Println("Temps invalide.")
    }
  default:
    fmt.Println("Choix non valide")
  }

  if tempsCuisson > 0 {
    fmt.Println("Types d'alertes disponibles :")
    fmt.Println("1. Son")
    fmt.Println("2. Lumières clignotantes")

    var choixAlerte string
    fmt.Print("Choisissez le type d'alerte pour signaler la fin de la cuisson (1/2) : ")
    fmt.Scanln(&choixAlerte)

    fmt.Printf("La cuisson se déroulera pendant %d secondes.\n", tempsCuisson)

    switch choixAlerte {
    case "1":
      time.Sleep(time.Duration(tempsCuisson) * time.Second)
      fmt.Println("*BIP*BIP*BIP* La cuisson est terminée !")
      
    case "2":
      time.Sleep(time.Duration(tempsCuisson) * time.Second)
      fmt.Println("*lumières clignotantes* La cuisson est terminée !")
      
    default:
      fmt.Println("Choix non valide. Aucune alerte ne sera déclenchée.")
    }

    var choixApresCuisson string
    fmt.Print("Que voulez-vous faire maintenant? (1. Éteindre / 2. Maintenir au chaud) : ")
    fmt.Scanln(&choixApresCuisson)

    switch choixApresCuisson {
    case "1":
      fmt.Println("Le rice cooker a été éteint.")
      
    case "2":
      fmt.Println("Le riz est maintenu au chaud.")
      
    default:
      fmt.Println("Choix non valide. Le rice cooker sera éteint par défaut.")
      
    }
  }
}

func main() {
  choisirMode()
}
