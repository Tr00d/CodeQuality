# Évaluation du cours de qualité de code

## Objectif

L’objectif de cet exercice est de refactorer le contenu de ce projet, principalement les fichiers `Bank.cs` et `BankTest.cs`, en appliquant les principes vus cette semaine lors du cours.

Le but est de :
* Rendre le code compréhensible pour les autres (écriture déclarative, code exprimant clairement les enjeux métier).
* Appliquer les principes de **Clean Code** (fonctions courtes, complexité cyclomatique basse, nommage explicite, absence de commentaires superflus, réduction de duplication).
* Garantir le bon fonctionnement du projet (tous les tests doivent continuer à passer et valider les comportements attendus).

Vous êtes autorisés à **modifier** le contrat public de la classe `Bank` si vous le jugez nécessaire.
Vous pouvez également **ajouter**, **modifier** ou **supprimer** des tests.

Il est important d’apporter le même niveau de qualité au code de production qu’au code de test.

## Objectif additionnel

Une fois le code dans un état satisfaisant, vous devrez ajouter un nouveau comportement.

Actuellement, tenter de retirer de l’argent sans solde suffisant ne produit aucun effet.

Exemples :
* Retirer `150` alors que votre solde est de `100` ne génère aucune ligne d’opération, et votre solde reste à `100`.

Nous souhaitons désormais autoriser un **découvert** maximal de `400` pour nos clients.
Un utilisateur est donc autorisé à atteindre un solde minimal de `–400`.

Exemples :
* Retirer 150 avec un solde de `100` génère une ligne de retrait et le solde devient `–50`.
* Retirer 350 avec un solde de `–50` génère une ligne de retrait et le solde devient `–400`.
* Retirer 100 avec un solde de `–350` ne génère aucune ligne d’opération et le solde reste à `–350`.